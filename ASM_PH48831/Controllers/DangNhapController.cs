using ASM_PH48831.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASM_PH48831.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly ASMDbContext _context;

        public DangNhapController(ASMDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var foundUser = await _context.Users
                .FirstOrDefaultAsync(u => u.TaiKhoan == model.TaiKhoan && u.MatKhau == model.MatKhau);

            if (foundUser != null)
            {
                HttpContext.Session.SetString("TaiKhoan", foundUser.TaiKhoan);
                HttpContext.Session.SetString("NguoiDungId", foundUser.NguoiDungId.ToString());
                HttpContext.Session.SetString("VaiTro", foundUser.VaiTro);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DangKy(User user)
        {
            var existingUser = _context.Users
            .FirstOrDefault(u => u.TaiKhoan == user.TaiKhoan || u.Email == user.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("", "Tài khoản hoặc email đã tồn tại.");
                return View(user);
            }

            user.VaiTro = "User";

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
