using IsRotasiProje.Models;
using IsRotasiProje.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace IsRotasiProje.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        public ProfileController(AppDbContext context, UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _context = context;
            _userManager = userManager;
            _fileProvider = fileProvider;
        }

        [HttpGet]
        [Authorize(Roles ="Customer")]
        public async Task<IActionResult> AdayCV()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AdayCV(AppUser p,IFormFile photo)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (photo != null)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var img = root.First(x => x.Name == "images");
                var randomImageName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var path = Path.Combine(img.PhysicalPath, randomImageName);
                using var stream = new FileStream(path, FileMode.Create);
                photo.CopyTo(stream);
                user.Image = randomImageName;
            }
            
            user.PhoneNumber = p.PhoneNumber;
            user.DogumTarihi = p.DogumTarihi;
            user.Deneyim = p.Deneyim;
            user.Egitim = p.Egitim;
            user.Bilgisayar = p.Bilgisayar;
            user.Hobi = p.Hobi;
            user.Ozet = p.Ozet;
            await _userManager.UpdateAsync(user);
            return View(user);
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> AdayBasvurular()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var basvurular = _context.Basvurus.Include(x=> x.Ilan).ThenInclude(x=> x.Kategori).Include("User").Where(x => x.UserId == user.Id).ToList();

            return View(basvurular);
        }

        [Authorize(Roles = "Company")]
        public async Task<IActionResult> IsverenIlanlar()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var ilanlar = _context.Ilans.Include("Kategori").Include("Pozisyon").Include("User").Where(x => x.User.Id == user.Id).ToList();

            return View(ilanlar);
        }

        [HttpGet]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> IsverenProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "Company")]
        public async Task<IActionResult> IsverenProfile(AppUser u, IFormFile photo)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (photo != null)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var img = root.First(x => x.Name == "images");
                var randomImageName = Guid.NewGuid() + Path.GetExtension(photo.FileName);
                var path = Path.Combine(img.PhysicalPath, randomImageName);
                using var stream = new FileStream(path, FileMode.Create);
                photo.CopyTo(stream);
                user.Image = randomImageName;
            }

            user.PhoneNumber = u.PhoneNumber;
            user.Website = u.Website;
            user.Ozet = u.Ozet;
            await _userManager.UpdateAsync(user);
            return View(user);
        }


        [Authorize(Roles = "Company")]
        public IActionResult IlanBasvurular(int ilanId)
        {
            var basvurular = _context.Basvurus.Include("User").Where(x => x.IlanId == ilanId).ToList();

            return View(basvurular);
        }

        [Authorize(Roles = "Company")]
        public IActionResult BasvuranDetay(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            return View(user);
        }

        [Authorize(Roles = "Company")]
        [HttpGet]
		public IActionResult IlanOlustur()
		{
            ViewBag.Kategori = _context.Kategoris.ToList();
            ViewBag.Sehir = _context.Sehirs.ToList();
            ViewBag.Maas = _context.MaasAraligis.ToList();
            ViewBag.Pozisyon = _context.Pozisyons.ToList();
            ViewBag.Calisma = _context.CalismaSeklis.ToList();
			return View();
		}

        [Authorize(Roles = "Company")]
        [HttpPost]
        public async Task<IActionResult> IlanOlustur(Ilan ilan)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ilan.Tarih = DateTime.Now;
                ilan.UserId = user.Id;
                _context.Ilans.Add(ilan);
                _context.SaveChanges();
                return RedirectToAction("IlanOlustur");
            }
            catch (Exception ex)
            {
                return RedirectToAction("IlanOlustur");
            }
            
        }

        [Authorize(Roles = "Customer,Company")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = "Customer,Company")]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(string oldPassword, string newPassword, string newPasswordAgain)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (newPassword == newPasswordAgain && newPassword.Length >= 6)
            {
                var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
                if (result.Succeeded)
                {
                    ViewBag.Basarili = "Şifreniz başarılı bir şekilde değiştirildi.";
                    return View();
                }
                else
                {
                    ViewBag.Hata = "Yazdığınız eski şifre yanlış.";
                }
            }
            else if (newPassword != newPasswordAgain)
            {
                ViewBag.Uyusmazlik = "Yazdığınız yeni şifreler birbiriyle uyuşmuyor.";
				return View();
			}
            else
            {
                ViewBag.Length = "Yazdığınız yeni şifre en az 6 karakter olmalı.";
				return View();
			}
            return View();
        }


        [HttpPost]
        public int IlanSil(int id)
        {
            var ilan = _context.Ilans.FirstOrDefault(x => x.IlanId == id);
            try
            {
                _context.Ilans.Remove(ilan);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

    }
}
