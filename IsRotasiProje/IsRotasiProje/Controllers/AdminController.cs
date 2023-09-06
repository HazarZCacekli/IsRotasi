using IsRotasiProje.Classes;
using IsRotasiProje.Models;
using IsRotasiProje.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using System.Security.AccessControl;

namespace IsRotasiProje.Controllers
{
    [Authorize(Roles ="Admin")]
	public class AdminController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;

        public AdminController(AppDbContext context, UserManager<AppUser> userManager, IFileProvider fileProvider)
        {
            _context = context;
            _userManager = userManager;
            _fileProvider = fileProvider;
        }

        public async Task<IActionResult> Index()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            ViewBag.ilan = _context.Ilans.Count();
            ViewBag.user = _context.Users.Count();

            var ilans = _context.Ilans.Include("Kategori").Include("User").ToList();

            return View(ilans);
        }

        public async Task<IActionResult> IlanList()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;

            var ilans = _context.Ilans.Include("Kategori").Include("User").ToList();

            return View(ilans);
        }

        public async Task<IActionResult> AdayList()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;

            var adaylar = (from ur in _context.UserRoles
                           join r in _context.Roles on ur.RoleId equals r.Id
                           join u in _context.Users on ur.UserId equals u.Id
                           select new UserRoleAdminViewModel()
                           {
                               Tarih = u.Tarih,
                               Ad = u.Ad,
                               UserId = u.Id,
                               Email = u.Email,
                               Role = r.Name
                           }).Where(x => x.Role == "Customer").ToList();
            return View(adaylar);
        }

        [HttpGet]
        public async Task<IActionResult> AdayDetay(string id)
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            var aday = await _userManager.FindByIdAsync(id);
            return View(aday);
        }

        [HttpPost]
        public async Task<IActionResult> AdayDetay(AppUser p,IFormFile photo)
        {
            var user = await _userManager.FindByIdAsync(p.Id);

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

            user.Ad = p.Ad;
            user.Email = p.Email;
            user.PhoneNumber = p.PhoneNumber;
            user.DogumTarihi = p.DogumTarihi;
            user.Deneyim = p.Deneyim;
            user.Egitim = p.Egitim;
            user.Bilgisayar = p.Bilgisayar;
            user.Hobi = p.Hobi;
            user.Ozet = p.Ozet;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("AdayDetay", new {id = user.Id });
        }

        public async Task<IActionResult> IsverenList()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;

            var isverenler = (from ur in _context.UserRoles
                           join r in _context.Roles on ur.RoleId equals r.Id
                           join u in _context.Users on ur.UserId equals u.Id
                           select new UserRoleAdminViewModel()
                           {
                               Tarih = u.Tarih,
                               Ad = u.Ad,
                               UserId = u.Id,
                               Email = u.Email,
                               Role = r.Name
                           }).Where(x => x.Role == "Company").ToList();
            return View(isverenler);
        }

        [HttpGet]
        public async Task<IActionResult> IsverenDetay(string id)
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            var isveren = await _userManager.FindByIdAsync(id);
            return View(isveren);
        }

        [HttpPost]
        public async Task<IActionResult> IsverenDetay(AppUser p,IFormFile photo)
        {
            var user = await _userManager.FindByIdAsync(p.Id);

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

            user.Ad = p.Ad;
            user.Email = p.Email;
            user.PhoneNumber = p.PhoneNumber;
            user.DogumTarihi = p.DogumTarihi;
            user.Deneyim = p.Deneyim;
            user.Egitim = p.Egitim;
            user.Bilgisayar = p.Bilgisayar;
            user.Hobi = p.Hobi;
            user.Ozet = p.Ozet;
            await _userManager.UpdateAsync(user);
            return RedirectToAction("IsverenDetay", new { id = user.Id });
        }

        public async Task<IActionResult> MesajList()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            var messages = _context.Iletisims.ToList();
            return View(messages);
        }

        [HttpGet]
        public async Task<IActionResult> MesajDetay(int id)
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            var mesaj = _context.Iletisims.FirstOrDefault(x=> x.IletisimId == id);
            return View(mesaj);
        }

        [HttpGet]
        public IActionResult MesajDetaySil(int id)
        {
            var mesaj = _context.Iletisims.FirstOrDefault(x => x.IletisimId == id);
            _context.Iletisims.Remove(mesaj);
            _context.SaveChanges();
            return RedirectToAction("MesajList");
        }

        [HttpGet]
        public async Task<IActionResult> BultenHesapList()
        {
            var userName = await _userManager.FindByNameAsync(User.Identity.Name);
            TempData["Username"] = userName.Ad;
            TempData["Image"] = userName.Image;
            var bulten = _context.Bulten.ToList();
            return View(bulten);
        }

        [HttpGet]
        public IActionResult BultenMesajYolla()
        {
            return View();
        }

		[HttpPost]
		public IActionResult BultenMesajYolla(string subject,string body)
		{
            var emails = _context.Bulten.ToList();

            try
            {
                foreach (var item in emails)
                {
                    EmailHelper emailHelper = new EmailHelper();
                    emailHelper.SendEmail(item.Email, body, subject);
                }
                ViewBag.Success = "Mailler başarıyla gönderildi.";
                return View();
            }
            catch (Exception exc)
            {
                ViewBag.Error = "Mailler gönderilirken bir hata oluştu.";
                return View();
            }

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

        [HttpPost]
        public async Task<int> KullaniciSil(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            try
            {
                await _userManager.DeleteAsync(user);
                return 1;
            }
            catch (Exception e)
            {

                return 0;
            }
        }

        [HttpPost]
        public int MesajSil(int id)
        {
            var mesaj = _context.Iletisims.FirstOrDefault(x => x.IletisimId == id);
            try
            {
                _context.Iletisims.Remove(mesaj);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        [HttpPost]
        public int BultenHesapSil(int id)
        {
            var email = _context.Bulten.FirstOrDefault(x=> x.Id == id);

            try
            {
                _context.Bulten.Remove(email);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

    }
}
