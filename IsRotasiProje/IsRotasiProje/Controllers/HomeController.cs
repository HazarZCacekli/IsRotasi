using IsRotasiProje.Models;
using IsRotasiProje.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IsRotasiProje.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            ViewBag.Kategori = _context.Kategoris.ToList();
            ViewBag.Sehir = _context.Sehirs.ToList();

            var join = _context.Ilans.Include("Kategori").Include("CalismaSekli").Include("MaasAraligi").Include("Pozisyon").Include("Sehir").Include("User").ToList();

            var ilanCount = Convert.ToDouble(join.Count);
            double pageDouble = ilanCount / 9;
            double pageRounding = Math.Ceiling(pageDouble);
            int pageCount = Convert.ToInt32(pageRounding);
            ViewBag.PageCount = pageCount;
            int a = 0;
            ViewBag.Page = a;

            var ilansPaged = join.Take(9).ToList();

            return View(ilansPaged);
        }



    }
}