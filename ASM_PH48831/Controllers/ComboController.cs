using ASM_PH48831.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASM_PH48831.Controllers
{
    public class ComboController : Controller
    {
        private readonly ASMDbContext _context;

        public ComboController(ASMDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(ComboQueryParameter param)
        {

            var isLoggedIn = !string.IsNullOrEmpty(HttpContext.Session.GetString("TaiKhoan"));
            ViewData["IsLoggedIn"] = isLoggedIn;

            var combos = _context.Combos
                .Include(c => c.ComboChiTiets)
                .ThenInclude(ct => ct.MonAn)
                .AsQueryable(); 

            if (!string.IsNullOrEmpty(param.Keyword))
            {
                combos = combos.Where(c => c.TenCombo.Contains(param.Keyword));
            }

            if (param.FromPrice.HasValue)
            {
                combos = combos.Where(c => c.ComboChiTiets.Sum(ct => ct.MonAn.Gia * ct.SoLuong) >= param.FromPrice.Value);
            }

            if (param.ToPrice.HasValue)
            {
                combos = combos.Where(c => c.ComboChiTiets.Sum(ct => ct.MonAn.Gia * ct.SoLuong) <= param.ToPrice.Value);
            }

            int totalCombos = combos.Count();

            combos = combos
                .Skip((param.PageNumber - 1) * param.PageSize)
                .Take(param.PageSize);

            ViewBag.CurrentPage = param.PageNumber;
            ViewBag.TotalPages = (int)Math.Ceiling(totalCombos / (double)param.PageSize);

            return View(combos.ToList());
        }


        public IActionResult Details(int id)
        {
            var combo = _context.Combos
                .Include(c => c.ComboChiTiets)
                .ThenInclude(ct => ct.MonAn)
                .FirstOrDefault(c => c.ComboId == id);

            if (combo == null)
            {
                return NotFound();
            }

            return View(combo);
        }
    }
}
