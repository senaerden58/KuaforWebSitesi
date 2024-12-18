using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KuaforWebSitesi.Controllers
{
    [Authorize(Roles = "Admin")]  // Ensures only users with "Admin" role can access the actions in this controller
    public class AdminController : Controller
    {
        private readonly KuaforDBContext db;
        private readonly PasswordHasher<Musteri> _passwordHasher;
        private readonly ILogger<MusteriController> _logger;
        public AdminController(KuaforDBContext context, PasswordHasher<Musteri> passwordHasher, ILogger<MusteriController> logger)
        {
            db = context;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }
        // Admin Paneli sayfasına yönlendiren bir action metodu
        [HttpGet]
        public IActionResult AdminPaneli()
        {
            var kullaniciRol = HttpContext.Session.GetString("RolAdi");

            if (kullaniciRol != "Admin")
            {
                return RedirectToAction("AccessDenied", "Admin");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // AdminPage method can also use role from the session
       

        // Logout action to clear session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clear session data
            return RedirectToAction("Index", "Home"); // Redirect to home page
        }

       



    }
}
