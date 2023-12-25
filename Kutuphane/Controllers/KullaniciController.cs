using Kutuphane.Models;
using Kutuphane.Repository.Shared.Abstract;
using Kutuphane.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace Kutuphane.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly IKullaniciService _kullaniciService;
        public KullaniciController(IKullaniciService kullaniciService)
        {
            _kullaniciService = kullaniciService;
        }

        public IActionResult Login() { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Login(Kullanici kul)
        {
           Kullanici kullanici = _kullaniciService.GetUser(kul);

            if (kullanici != null)
            {
                
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name,kullanici.Username));
                claims.Add(new Claim(ClaimTypes.GivenName, kullanici.Ad));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, kullanici.Id.ToString()));

                if(kullanici.IsAdmin)
                {
                    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                }

                var claimsIdenity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdenity), new AuthenticationProperties { IsPersistent=true });
            }
            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
