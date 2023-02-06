using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineSinavSitesi.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;

namespace OnlineSinavSitesi.Controllers
{
    public class KullaniciController : Controller
    {
        private readonly SinavContext _context;
        public KullaniciController(SinavContext context)
        {
            _context = context;
           
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult KullaniciGiris()
        {
            

            return View();


        }


        public IActionResult Kullanicisayfasi()
        {
            var appuserjson = HttpContext.Session.GetString("user");

            var appuser = JsonSerializer.Deserialize<User>(appuserjson);
            return View(appuser);

        }
        [HttpPost]
        public IActionResult KullaniciKontrol(User user)
        {
            //Kullanıcının olup olmadığı ve sifrenin uyuşup uyuşmadığı kontrol ediliyor

            var kullanici = _context.Users.Where(s => s.Mail == user.Mail && s.Password == user.Password).FirstOrDefault();
          
            
            if (kullanici != null)
            {

                //return RedirectToAction("KullaniciSayfasi", "Kullanici", kullanici);

                
                string appUserJson = JsonSerializer.Serialize<User>(kullanici);
                HttpContext.Session.SetString("user", appUserJson);
               
                return RedirectToAction("KullaniciSayfasi");
            }
            else
            {
                TempData["veri"] = "1";

                return View("KullaniciGiris");
            }
        }









    }
}
