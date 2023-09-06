using IsRotasiProje.Models;
using IsRotasiProje.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace IsRotasiProje.Controllers
{
    public class JobListController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public JobListController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index(int page, int kategori, int sehir, int maas, int pozisyon, int calisma, string search, int sort)
        {
            ViewBag.Kategori = _context.Kategoris.ToList();
            ViewBag.Sehir = _context.Sehirs.ToList();
            ViewBag.Maas = _context.MaasAraligis.ToList();
            ViewBag.Pozisyon = _context.Pozisyons.ToList();
            ViewBag.Calisma = _context.CalismaSeklis.ToList();

            var model = _context.Ilans.Include("Kategori").Include("CalismaSekli").Include("MaasAraligi").Include("Pozisyon").Include("Sehir").Include("User").ToList();

            if (sort == 1)
            {
                ViewBag.Sort = sort;
                model = model.OrderByDescending(x => x.MaasAraligiId).ToList();
            }
            else if (sort == 2)
            {
                ViewBag.Sort = sort;
                model = model.OrderBy(x => x.MaasAraligiId).ToList();
            }

            if (kategori == 0 && search == null )  //PARAMETRESIZ TUM ILANLAR
            {
                var ilanCount = Convert.ToDouble(model.Count);
                double pageDouble = ilanCount / 9;
                int pageCount = Convert.ToInt32(Math.Ceiling(pageDouble));
                ViewBag.PageCount = pageCount;
                ViewBag.Page = page;

                var ilansPaged = model.Skip((page - 1) * 9).Take(9).ToList();
                return View(ilansPaged);
            }
            else if (maas == 0 && search == null )  //HOME SAYFASINDAKI SADECE KATEGORI VE SEHIRLE ARAMA YAPAN YER
            {
                var condition = model.Where(x => x.KategoriId == kategori && x.SehirId == sehir).ToList();

                var ilanCount = Convert.ToDouble(condition.Count);
                double pageDouble = ilanCount / 9;
                double pageRounding = Math.Ceiling(pageDouble);
                int pageCount = Convert.ToInt32(pageRounding);
                ViewBag.PageCount = pageCount;
                ViewBag.Page = page;
                ViewBag.KategoriParam = kategori;
                ViewBag.SehirParam = sehir;
                var ilansPaged = condition.Skip((page - 1) * 9).Take(9).ToList();
                return View(ilansPaged);
            }
            else if (search != null ) //ARAMA KISMINDAN ARAMA YAPILIRSA
            {
                var condition = model.Where(x => x.IlanAd.ToLower().Contains(search.ToLower())).ToList();
                var ilanCount = Convert.ToDouble(condition.Count);
                double pageDouble = ilanCount / 9;
                double pageRounding = Math.Ceiling(pageDouble);
                int pageCount = Convert.ToInt32(pageRounding);
                ViewBag.PageCount = pageCount;
                ViewBag.Page = page;
                ViewBag.SearchParam = search;
                var ilansPaged = condition.Skip((page - 1) * 9).Take(9).ToList();
                return View(ilansPaged);
            }
            else             //BUTUN KATEGORILER SECILDIGINDE
            {
                var condition = model.Where(x => x.KategoriId == kategori && x.SehirId == sehir && x.MaasAraligiId == maas && x.PozisyonId == pozisyon && x.CalismaSekliId == calisma).ToList();
                var ilanCount = Convert.ToDouble(condition.Count);
                double pageDouble = ilanCount / 9;
                double pageRounding = Math.Ceiling(pageDouble);
                int pageCount = Convert.ToInt32(pageRounding);
                ViewBag.PageCount = pageCount;
                ViewBag.Page = page;
                ViewBag.KategoriParam = kategori;
                ViewBag.SehirParam = sehir;
                ViewBag.MaasParam = maas;
                ViewBag.PozisyonParam = pozisyon;
                ViewBag.CalismaParam = calisma;
                ViewBag.SearchParam = search;
                var ilansPaged = condition.Skip((page - 1) * 9).Take(9).ToList();
                return View(ilansPaged);

            }
        }

        public IActionResult SearchTextDirector(string search) 
        {
            return RedirectToAction("Index", new { search = search, page = 1 });
        }

        public IActionResult JobDetails(int ilanId)
        {
            var ilan = _context.Ilans.Include("Kategori").Include("CalismaSekli").Include("MaasAraligi").Include("Pozisyon").Include("Sehir").Include("User").FirstOrDefault(x => x.IlanId == ilanId);
            return View(ilan);
        }


        public async Task<IActionResult> Basvur(int ilanId)
        {
            if (User.Identity.Name != null) 
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (User.IsInRole("Customer"))
                {
                    var anyBasvuru = _context.Basvurus.FirstOrDefault(x => x.IlanId == ilanId && x.UserId == user.Id);
                    if (anyBasvuru == null)
                    {
                        Basvuru newBasvuru = new Basvuru();
                        newBasvuru.IlanId = ilanId;
                        newBasvuru.UserId = user.Id;
                        newBasvuru.Tarih = DateTime.Now;
                        _context.Basvurus.Add(newBasvuru);
                        _context.SaveChanges();
                        TempData["Success"] = "Başarıyla başvuru yaptınız.";
                        return RedirectToAction("JobDetails", new { ilanId = ilanId });
                    }
                    else
                    {
                        TempData["Again"] = "Daha önce bu ilana başvuru yapmışsınız.";
                        return RedirectToAction("JobDetails", new { ilanId = ilanId });
                    }
                }
                else
                {
                    TempData["Error"] = "Hesabınız bir Aday hesabı olmadığı için başvuru yapamazsınız.";
                    return RedirectToAction("JobDetails", new { ilanId = ilanId });
                }
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }


    }
}
