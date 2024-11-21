using ASM_PH48831.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASM_PH48831.Controllers
{
    public class UserController : Controller
    {
        private readonly ASMDbContext _context;

        public UserController(ASMDbContext context)
        {
            _context = context;
        }

        // GET: User/Edit
        public async Task<IActionResult> Edit()
        {
            var taiKhoan = HttpContext.Session.GetString("TaiKhoan");
            if (string.IsNullOrEmpty(taiKhoan))
            {
                return RedirectToAction("Login", "DangNhap");
            }

            // Lấy thông tin người dùng từ tài khoản
            var user = await _context.Users.FirstOrDefaultAsync(u => u.TaiKhoan == taiKhoan);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] User user)
        {
            try
            {
                var existingUser = await _context.Users.FindAsync(user.NguoiDungId);
                if (existingUser == null)
                {
                    ModelState.AddModelError("", "Người dùng không tồn tại.");
                    return View(user);
                }

                // Cập nhật thông tin
                existingUser.TenNguoiDung = user.TenNguoiDung;
                existingUser.NgaySinh = user.NgaySinh;
                existingUser.DiaChi = user.DiaChi;
                existingUser.Email = user.Email;

                if (!string.IsNullOrEmpty(user.MatKhau) && user.MatKhau != existingUser.MatKhau)
                {
                    existingUser.MatKhau = user.MatKhau;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                ModelState.AddModelError("", $"Đã xảy ra lỗi khi cập nhật dữ liệu: {ex.Message}");
                return View(user);
            }
        }

    }
}
