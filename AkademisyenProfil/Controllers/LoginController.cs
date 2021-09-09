using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AkademisyenProfil.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

// Burada Giriş Kısmımızı çalıştıran kodlar var giriş olayı session ile yapılmadı claim ile yapıldı yani çerezler de bilgi tutulup kimlik doğrulama o şekilde yapıldı.
namespace AkademisyenProfil.Controllers
{
    public class LoginController : Controller
    {
        context c = new context();

        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GirisYap(Admin P)
        {
            var bilgiler = c.Admins.FirstOrDefault(x => x.Kullanici == P.Kullanici &&
              x.Sifre == P.Sifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,P.Kullanici)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);

                
                return RedirectToAction("Index", "Admin");
                


            }
            return View();

        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("GirisYap", "Login");


        }


        }
}
