using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace KuaforWebSitesi.Controllers
{
    public class CalisanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        private readonly KuaforDBContext db;
        private readonly PasswordHasher<Calisan> _passwordHasher;
        private readonly ILogger<CalisanController> _logger;

        public CalisanController(KuaforDBContext context, PasswordHasher<Calisan> passwordHasher, ILogger<CalisanController> logger)
        {
            db = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }
        public IActionResult CalisanEkle()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalisanKaydet(Calisan calisan)
        {
            // Model validation kontrolü
            if (!ModelState.IsValid)
            {
                TempData["msj"] = "Çalışan ekleme işlemi başarısız. Lütfen alanları kontrol edin.";
                return View("CalisanEkle");
            }

            // Şifreyi hash'le
            calisan.CalisanSifre = _passwordHasher.HashPassword(calisan, calisan.CalisanSifre);

            // Çalışanı veritabanına ekle
           db.Calisanlar.Add(calisan);
            db.SaveChanges();

            TempData["msj"] = $"{calisan.CalisanAd} adlı çalışan başarıyla kaydedildi.";
            return RedirectToAction("CalisanList");
        }
        // POST: Çalışan Kaydetme İşlemi
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CalisanKaydet(Calisan calisan, IFormFile resim)
        //{
            //var adminID = HttpContext.Session.GetString("AdminID");
            //if (string.IsNullOrEmpty(adminID))
            //{
            //    TempData["msj"] = "Sadece admin çalışan ekleyebilir.";
            //    return RedirectToAction("AdminGiris", "Account");
            //}

            //if (!ModelState.IsValid)
            //{
            //    foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            //    {
            //        Console.WriteLine($"Hata: {error.ErrorMessage}");
            //    }
            //    TempData["msj"] = "Çalışan ekleme işlemi başarısız. Lütfen alanları kontrol edin.";
            //    return RedirectToAction("CalisanEkle");
            //}

            //// Şifreyi Hashle
            //calisan.CalisanSifre = _passwordHasher.HashPassword(calisan, calisan.CalisanSifre);

            //// Resim var mı kontrolü
            //if (resim != null && resim.Length > 0)
            //{
            //    // Dosya yolunu belirle
            //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", resim.FileName);

            //    // Resmi kaydet
            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        resim.CopyTo(stream);
            //    }

            //    // Veritabanına resmin yolunu ekle
            //    calisan.ResimYolu = "~/web/images/" + resim.FileName;
            //}

            //// Çalışanı veritabanına kaydet
            //db.Calisanlar.Add(calisan);
            //db.SaveChanges();
            //TempData["msj"] = $"{calisan.CalisanAd} adlı çalışan kaydedildi.";

            //return RedirectToAction("CalisanList");
        //}

        // Çalışanlar Listesi
        public IActionResult CalisanList()
        {
            var calisanlar = db.Calisanlar.ToList();
            ViewBag.Msj = TempData["msj"];
            return View(calisanlar);
        }

    }
}
