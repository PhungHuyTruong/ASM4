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

        public async Task<IActionResult> LichSuHoaDon()
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

            var hoaDons = await _context.HoaDons
                .Where(hd => hd.NguoiDungId == userId)
                .Include(hd => hd.TrangThaiHoaDon) // Để xem trạng thái hóa đơn
                .Include(hd => hd.HoaDonChiTiets)
                .ThenInclude(hdct => hdct.MonAn)
                .ToListAsync();

            return View(hoaDons);
        }


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

            // Lấy trạng thái "Đang xử lý"
            var trangThaiDangXuLy = await _context.TrangThaiHoaDons.FirstOrDefaultAsync(tt => tt.TenTrangThai == "Đang xử lý");

            if (trangThaiDangXuLy == null)
            {
                return NotFound("Trạng thái 'Đang xử lý' không tồn tại.");
            }

            // Tạo hóa đơn với trạng thái "Đang xử lý"
            var hoaDon = new HoaDon
            {
                NguoiDungId = userId,
                NgayLap = DateTime.Now,
                TrangThaiId = trangThaiDangXuLy.IdTrangThai,
                TongTien = 0 // Sẽ được tính lại sau
            };

            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            var gioHang = await _context.GioHangs.FirstOrDefaultAsync(g => g.NguoiDungId == userId);
            if (gioHang == null)
            {
                gioHang = new GioHang { NguoiDungId = userId };
                _context.GioHangs.Add(gioHang);
                await _context.SaveChangesAsync();
            }

            if (comboId > 0)
            {
                var combo = await _context.Combos.Include(c => c.ComboChiTiets)
                                      .ThenInclude(cc => cc.MonAn)
                                      .FirstOrDefaultAsync(c => c.ComboId == comboId);

                if (combo == null)
                {
                    return NotFound("Combo không tồn tại.");
                }

                foreach (var comboChiTiet in combo.ComboChiTiets)
                {
                    var existingItem = await _context.GioHangChiTiets
                        .FirstOrDefaultAsync(g => g.GioHangId == gioHang.GioHangId && g.MonAnId == comboChiTiet.MonAnId);

                    if (existingItem != null)
                    {
                        existingItem.SoLuong += comboChiTiet.SoLuong * soLuong;
                    }
                    else
                    {
                        var gioHangChiTiet = new GioHangChiTiet
                        {
                            GioHangId = gioHang.GioHangId,
                            MonAnId = comboChiTiet.MonAnId,
                            SoLuong = comboChiTiet.SoLuong * soLuong
                        };

                        _context.GioHangChiTiets.Add(gioHangChiTiet);
                    }

                    // Thêm chi tiết hóa đơn
                    var hoaDonChiTiet = new HoaDonChiTiet
                    {
                        HoaDonId = hoaDon.HoaDonId,
                        MonAnId = comboChiTiet.MonAnId,
                        SoLuong = comboChiTiet.SoLuong * soLuong,
                        DonGia = comboChiTiet.MonAn.Gia
                    };
                    _context.HoaDonChiTiets.Add(hoaDonChiTiet);
                }
            }
            else if (monAnId > 0)
            {
                var monAn = await _context.MonAns.FindAsync(monAnId);
                if (monAn == null)
                {
                    return NotFound("Món ăn không tồn tại.");
                }

                var existingItem = await _context.GioHangChiTiets
                    .FirstOrDefaultAsync(g => g.GioHangId == gioHang.GioHangId && g.MonAnId == monAnId);

                if (existingItem != null)
                {
                    existingItem.SoLuong += soLuong;
                }
                else
                {
                    var gioHangChiTiet = new GioHangChiTiet
                    {
                        GioHangId = gioHang.GioHangId,
                        MonAnId = monAnId,
                        SoLuong = soLuong
                    };

                    _context.GioHangChiTiets.Add(gioHangChiTiet);
                }

                // Thêm chi tiết hóa đơn
                var hoaDonChiTiet = new HoaDonChiTiet
                {
                    HoaDonId = hoaDon.HoaDonId,
                    MonAnId = monAnId,
                    SoLuong = soLuong,
                    DonGia = monAn.Gia
                };
                _context.HoaDonChiTiets.Add(hoaDonChiTiet);
            }

            await _context.SaveChangesAsync();

            // Cập nhật tổng tiền của hóa đơn
            hoaDon.TongTien = _context.HoaDonChiTiets
                .Where(hdct => hdct.HoaDonId == hoaDon.HoaDonId)
                .Sum(hdct => hdct.DonGia * hdct.SoLuong);

            await _context.SaveChangesAsync();

            return RedirectToAction("XemGioHang", "GioHang");
        }


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
                var tongTien = gioHang.GioHangChiTiets.Sum(item => item.MonAn.Gia * item.SoLuong);

                ViewData["TongTien"] = tongTien.ToString("C", new System.Globalization.CultureInfo("vi-VN"));
            }

            return View(gioHang);
        }


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

            // Tìm giỏ hàng của người dùng
            var gioHang = await _context.GioHangs
                .Include(g => g.GioHangChiTiets)
                .ThenInclude(ghct => ghct.MonAn)
                .FirstOrDefaultAsync(g => g.NguoiDungId == userId);

            if (gioHang == null || gioHang.GioHangChiTiets.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }

            // Lấy trạng thái 'Đang xử lý' từ cơ sở dữ liệu
            var trangThaiDangXuLy = await _context.TrangThaiHoaDons
                                                   .FirstOrDefaultAsync(tt => tt.TenTrangThai == "Đang xử lý");

            if (trangThaiDangXuLy == null)
            {
                return NotFound("Trạng thái 'Đang xử lý' không tồn tại.");
            }

            // Tạo hóa đơn với trạng thái "Đang xử lý"
            var hoaDon = new HoaDon
            {
                NguoiDungId = userId,
                NgayLap = DateTime.Now,
                TongTien = gioHang.GioHangChiTiets.Sum(ghct => ghct.MonAn.Gia * ghct.SoLuong),
                TrangThaiId = trangThaiDangXuLy.IdTrangThai // Đặt trạng thái thành 'Đang xử lý'
            };

            _context.HoaDons.Add(hoaDon);
            await _context.SaveChangesAsync();

            // Thêm chi tiết hóa đơn từ giỏ hàng
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

            // Xóa giỏ hàng sau khi thanh toán
            _context.GioHangChiTiets.RemoveRange(gioHang.GioHangChiTiets);
            await _context.SaveChangesAsync();

            // Điều hướng đến trang xem hóa đơn chi tiết
            return RedirectToAction("XemHoaDon", new { hoaDonId = hoaDon.HoaDonId });
        }


        public async Task<IActionResult> XemHoaDon(int hoaDonId)
        {
            var hoaDon = await _context.HoaDons
                .Include(h => h.TrangThaiHoaDon)  // Include trạng thái hóa đơn
                .Include(h => h.HoaDonChiTiets)
                .ThenInclude(hdct => hdct.MonAn)
                .FirstOrDefaultAsync(h => h.HoaDonId == hoaDonId);

            if (hoaDon == null)
            {
                return NotFound("Hóa đơn không tồn tại.");
            }

            return View(hoaDon);
        }

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

                var gioHang = await _context.GioHangs
                    .Include(g => g.GioHangChiTiets)
                    .FirstOrDefaultAsync(g => g.NguoiDungId == userId);

                if (gioHang != null)
                {
                    _context.GioHangChiTiets.RemoveRange(gioHang.GioHangChiTiets);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction("XemGioHang");
            }

        }
    }
