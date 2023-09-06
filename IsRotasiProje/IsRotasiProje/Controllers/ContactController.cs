using IsRotasiProje.Classes;
using IsRotasiProje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace IsRotasiProje.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Iletisim iletisim)
        {
            iletisim.Tarih = DateTime.Now;
            _context.Iletisims.Add(iletisim);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public IActionResult Bulten(Bulten bulten)
        {
            var emailCheck = _context.Bulten.FirstOrDefault(x=> x.Email == bulten.Email);
            if (emailCheck == null)
            {
                EmailHelper email = new EmailHelper();
                string messageBody = "İş Rotası E-Bültenine kayıt olduğunuz için teşekkür ederiz. Gelecekte sitemizde olacak değişiklik ve haberleri memnuniyetle sizlere ileteceğiz.";
                string messageSubject = "İş Rotası E-Bülten Kayıt";
                bool result = email.SendEmail(bulten.Email, messageBody, messageSubject);
                if (result)
                {
                    _context.Bulten.Add(bulten);
                    _context.SaveChanges();
                    TempData["Success"] = "Bültenimize başarıyla kaydoldunuz.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Bilinmeyen bir problem nedeniyle hata oluştu.";
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["AlreadyExist"] = "E-Mailiniz bültenimize zaten kayıtlı.";
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
