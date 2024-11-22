    using ASM_PH48831.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Security.Claims;
    using System.Linq;

    namespace ASM_PH48831.Controllers
    {
        public class GioHangController : Controller
        {
            private readonly ASMDbContext _context;

            public GioHangController(ASMDbContext context)
            {
                _context = context;
            }

        // Thêm món ăn vào giỏ hàng
        // Thêm món ăn hoặc combo vào giỏ hàng
        public async Task<IActionResult> ThemVaoGioHang(int monAnId, int comboId, int soLuong)
        {
            var nguoiDungId = HttpContext.Session.GetString("NguoiDungId");

            if (string.IsNullOrEmpty(nguoiDungId))
            {
                return RedirectToAction("Login", "DangNhap");
            }

            if (!int.TryParse(nguoiDungId, out int userId))
            {
                return NotFound("Session người dùng không hợp lệ.");
            }

            var gioHang = await _context.GioHangs.FirstOrDefaultAsync(g => g.NguoiDungId == userId);
            if (gioHang == null)
            {
                gioHang = new GioHang { NguoiDungId = userId };
                _context.GioHangs.Add(gioHang);
                await _context.SaveChangesAsync();
            }

            if (comboId > 0) // Nếu chọn combo, thêm các món ăn trong combo vào giỏ hàng
            {
                var combo = await _context.Combos.Include(c => c.ComboChiTiets)
                                      .ThenInclude(cc => cc.MonAn)
                                      .FirstOrDefaultAsync(c => c.ComboId == comboId);

                if (combo == null)
                {
                    return NotFound("Combo không tồn tại.");
                }

                // Thêm mỗi món ăn trong combo vào giỏ hàng
                foreach (var comboChiTiet in combo.ComboChiTiets)
                {
                    var existingItem = await _context.GioHangChiTiets
                        .FirstOrDefaultAsync(g => g.GioHangId == gioHang.GioHangId && g.MonAnId == comboChiTiet.MonAnId);

                    if (existingItem != null)
                    {
                        // Nếu món ăn đã có trong giỏ hàng, cộng dồn số lượng
                        existingItem.SoLuong += comboChiTiet.SoLuong * soLuong;
                    }
                    else
                    {
                        // Nếu món ăn chưa có, thêm món ăn mới vào giỏ hàng
                        var gioHangChiTiet = new GioHangChiTiet
                        {
                            GioHangId = gioHang.GioHangId,
                            MonAnId = comboChiTiet.MonAnId,  // Lưu Món ăn từ ComboChiTiet vào giỏ hàng
                            SoLuong = comboChiTiet.SoLuong * soLuong // Tính tổng số lượng món ăn trong combo
                        };

                        _context.GioHangChiTiets.Add(gioHangChiTiet);
                    }
                }

                await _context.SaveChangesAsync();
            }

            else if (monAnId > 0) // Nếu chọn món ăn, thêm món ăn vào giỏ hàng
            {
                var monAn = await _context.MonAns.FindAsync(monAnId);
                if (monAn == null)
                {
                    return NotFound("Món ăn không tồn tại.");
                }

                // Kiểm tra xem món ăn này đã có trong giỏ hàng chưa
                var existingItem = await _context.GioHangChiTiets
                    .FirstOrDefaultAsync(g => g.GioHangId == gioHang.GioHangId && g.MonAnId == monAnId);

                if (existingItem != null)
                {
                    // Nếu có thì cộng thêm số lượng
                    existingItem.SoLuong += soLuong;
                }
                else
                {
                    // Nếu không có thì thêm mới
                    var gioHangChiTiet = new GioHangChiTiet
                    {
                        GioHangId = gioHang.GioHangId,
                        MonAnId = monAnId,
                        SoLuong = soLuong
                    };

                    _context.GioHangChiTiets.Add(gioHangChiTiet);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("XemGioHang", "GioHang");
        }





        // Xem giỏ hàng
        public async Task<IActionResult> XemGioHang()
            {
            var taiKhoan = HttpContext.Session.GetString("TaiKhoan");
            if (taiKhoan == null)
            {
                return RedirectToAction("Login", "DangNhap");
            }

            var userId = await _context.Users
                                        .Where(u => u.TaiKhoan == taiKhoan)
                                        .Select(u => u.NguoiDungId)
                                        .FirstOrDefaultAsync();

            var gioHang = await _context.GioHangs
                                        .Include(g => g.GioHangChiTiets)
                                        .ThenInclude(ghct => ghct.MonAn)
                                        .FirstOrDefaultAsync(g => g.NguoiDungId == userId);

            if (gioHang != null && gioHang.GioHangChiTiets != null)
            {
                // Tính tổng tiền
                var tongTien = gioHang.GioHangChiTiets.Sum(item => item.MonAn.Gia * item.SoLuong);

                // Định dạng tổng tiền thành tiền tệ Việt Nam và gửi đến View
                ViewData["TongTien"] = tongTien.ToString("C", new System.Globalization.CultureInfo("vi-VN"));
            }

            return View(gioHang);
        }

        // Thanh toán và tạo hóa đơn
        public async Task<IActionResult> ThanhToan()
        {
            var nguoiDungId = HttpContext.Session.GetString("NguoiDungId");
            if (string.IsNullOrEmpty(nguoiDungId))
            {
                return RedirectToAction("Login", "DangNhap");
            }

            if (!int.TryParse(nguoiDungId, out int userId))
            {
                return NotFound("Session người dùng không hợp lệ.");
            }

            var gioHang = await _context.GioHangs
                .Include(g => g.GioHangChiTiets)
                .ThenInclude(ghct => ghct.MonAn)
                .FirstOrDefaultAsync(g => g.NguoiDungId == userId);

            if (gioHang == null)
            {
                return RedirectToAction("Index", "Home");
            }

            // Tìm trạng thái "Đang xử lý" trong bảng TrangThaiHoaDon
            var trangThaiDangXuLy = await _context.TrangThaiHoaDons
                                                   .FirstOrDefaultAsync(tt => tt.TenTrangThai == "Đang xử lý");

            if (trangThaiDangXuLy == null)
            {
                return NotFound("Trạng thái 'Đang xử lý' không tồn tại.");
            }

            var hoaDon = new HoaDon
            {
                NguoiDungId = userId,
                NgayLap = DateTime.Now,
                TongTien = gioHang.GioHangChiTiets.Sum(ghct => ghct.MonAn.Gia * ghct.SoLuong),
                TrangThaiId = trangThaiDangXuLy.IdTrangThai // Gán trạng thái "Đang xử lý"
            };

            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            foreach (var item in gioHang.GioHangChiTiets)
            {
                var hoaDonChiTiet = new HoaDonChiTiet
                {
                    HoaDonId = hoaDon.HoaDonId,
                    MonAnId = item.MonAnId ?? 0,
                    SoLuong = item.SoLuong,
                    DonGia = item.MonAn.Gia
                };

                _context.HoaDonChiTiets.Add(hoaDonChiTiet);
            }

            await _context.SaveChangesAsync();

            _context.GioHangChiTiets.RemoveRange(gioHang.GioHangChiTiets);
            await _context.SaveChangesAsync();

            return RedirectToAction("XemHoaDon", new { hoaDonId = hoaDon.HoaDonId });
        }


        // Xem hóa đơn
        public async Task<IActionResult> XemHoaDon(int hoaDonId)
            {
                var hoaDon = await _context.HoaDons
                    .Include(h => h.HoaDonChiTiets)
                    .ThenInclude(hdct => hdct.MonAn)
                    .FirstOrDefaultAsync(h => h.HoaDonId == hoaDonId);

                return View(hoaDon);
            }

            // Hủy giỏ hàng
            public async Task<IActionResult> HuyGioHang()
            {
                var nguoiDungId = HttpContext.Session.GetString("NguoiDungId");

                if (string.IsNullOrEmpty(nguoiDungId))
                {
                    return RedirectToAction("Login", "DangNhap");
                }

                if (!int.TryParse(nguoiDungId, out int userId))
                {
                    return NotFound("Session người dùng không hợp lệ.");
                }

                // Tìm giỏ hàng của người dùng
                var gioHang = await _context.GioHangs
                    .Include(g => g.GioHangChiTiets)
                    .FirstOrDefaultAsync(g => g.NguoiDungId == userId);

                if (gioHang != null)
                {
                    // Xóa tất cả các mục trong giỏ hàng
                    _context.GioHangChiTiets.RemoveRange(gioHang.GioHangChiTiets);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("XemGioHang");
            }

        }
    }
