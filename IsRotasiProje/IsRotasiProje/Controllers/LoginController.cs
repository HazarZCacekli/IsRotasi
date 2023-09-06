using IsRotasiProje.Classes;
using IsRotasiProje.Models;
using IsRotasiProje.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IsRotasiProje.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		public LoginController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
		{
			_context = context;
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		public IActionResult Login()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel p,bool rememberMe)
		{
			var result = await _signInManager.PasswordSignInAsync(p.username, p.password, rememberMe, false);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Home");
			}
			else
			{
				ViewBag.Error = "Email veya şifre yanlış.";
				return View();
			}
		}


		[HttpGet]
		public IActionResult RegisterAday()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegisterAday(RegisterViewModel u)
		{
			if (u.Password.Length >= 6)
			{
				AppUser user = new AppUser()
				{
					Email = u.Email,
					UserName = u.Email,
					Ad = u.Ad,
					Tarih = DateTime.Now,
					Image = "noimage.jpg"
				};

				var result = await _userManager.CreateAsync(user, u.Password);
				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "Customer");
                    TempData["Success"] = "Başarıyla kayıt oldunuz. Lütfen giriş yapınız.";
                    return RedirectToAction("Login");
				}
				else
				{
					ViewBag.Error = "Bu E-Mail'e kayıtlı bir hesap zaten bulunmaktadır.";
					return View();
				}
			}
			else
			{
				ViewBag.Digit = "Şifre en az 6 karakter olmalı";
				return View();
			}

		}

		[HttpGet]
		public IActionResult RegisterIsveren()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> RegisterIsveren(RegisterViewModel u)
		{
            if (u.Password.Length >= 6)
            {
                AppUser user = new AppUser()
                {
                    Email = u.Email,
                    UserName = u.Email,
                    Ad = u.Ad,
                    Tarih = DateTime.Now,
                    Image = "noimage.jpg"
                };

                var result = await _userManager.CreateAsync(user, u.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Company");
					TempData["Success"] = "Başarıyla kayıt oldunuz. Lütfen giriş yapınız.";
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Error = "Bu E-Mail'e kayıtlı bir hesap zaten bulunmaktadır.";
                    return View();
                }
            }
            else
            {
                ViewBag.Digit = "Şifre en az 6 karakter olmalı";
                return View();
            }
        }

		[HttpGet]
		public IActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgotPassword(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user == null)
			{
				TempData["ResetInfo"] = "Şifre sıfırlama linki E-Mail'inize gönderilmiştir.";
				return View();
			}

			var token = await _userManager.GeneratePasswordResetTokenAsync(user);
			var link = Url.Action("ResetPassword", "Login", new { token, email = user.Email }, Request.Scheme);
			string mail = "Şifrenizi sıfırlamak için tıklayın : " + link + " \n Eğer bu işlemi siz yapmadıysanız görmezden gelebilirsiniz. Birisi yanlışlıkla sizin e-mailinizi girmiş olabilir.";

			EmailHelper emailHelper = new EmailHelper();
			bool emailSend = emailHelper.SendEmail(user.Email, mail,"İş Rotası Şifre Sıfırlama");

			if (emailSend)
			{
				TempData["ResetInfo"] = "Şifre sıfırlama linki E-Mail'inize gönderilmiştir.";
				return RedirectToAction("ForgotPassword");
			}
			else
			{
				TempData["ResetError"] = "Bilinmeyen bir hata sebebiyle E-Mail gönderilemedi. Lütfen site yetkilileriyle iletişime geçin";
			}
			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string token, string email)
		{
			ResetPasswordViewModel model = new ResetPasswordViewModel { Token = token, Email = email };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
		{
			if (!ModelState.IsValid)
			{
				return View(resetPassword);
			}

			var user = await _userManager.FindByEmailAsync(resetPassword.Email);
			if (user == null)
			{
				return RedirectToAction("ForgotPassword");
			}

			var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);

			if (result.Succeeded)
			{
				TempData["Info"] = "Şifreniz başarılı bir şekilde değiştirildi.Lütfen giriş yapınız";
				return RedirectToAction("Login");
			}
			else
			{
				ViewBag.Error = "Bu bağlantının süresi dolmuş veya bir hata mevcut.";
				return View();
			}
		}



		[HttpGet]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
