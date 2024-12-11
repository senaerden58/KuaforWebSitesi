using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace KuaforWebSitesi.Controllers
{
    public class MusteriController : Controller
    {

        private readonly KuaforDBContext db;
        private readonly PasswordHasher<Musteri> _passwordHasher;
        private readonly ILogger<MusteriController> _logger;
        public MusteriController(KuaforDBContext context, PasswordHasher<Musteri> passwordHasher, ILogger<MusteriController> logger)
        {
            db = context;
            _logger = logger;
            _passwordHasher = passwordHasher;
        }

        public IActionResult MusteriEkle()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MusteriGiris()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MusteriKaydet(Musteri musteri)
        {
            if (!ModelState.IsValid)
            {
                // Hataları kontrol et
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }

                TempData["msj"] = "Kayıt işlemi başarısız. Lütfen alanları kontrol edin.";
                return RedirectToAction("MusteriEkle"); // Kullanıcıyı 'MusteriEkle' görünümüne yönlendir
            }

            // Şifreyi hash'le
            musteri.MusteriSifre = _passwordHasher.HashPassword(musteri, musteri.MusteriSifre);

            db.Musteriler.Add(musteri);
            db.SaveChanges();
            TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri kaydedildi.";
            return RedirectToAction("MusteriList");
        }

        [HttpPost]

        [ValidateAntiForgeryToken]
        public IActionResult MusteriGiris(string musteriMail, string musteriSifre)
        {
            if (string.IsNullOrEmpty(musteriMail) || string.IsNullOrEmpty(musteriSifre))
            {
                TempData["msj"] = "E-posta ve şifre alanlarını doldurun.";
                return View();  // Formu tekrar göster
            }

            var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriMail == musteriMail);
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Bu e-posta ile kayıtlı bir kullanıcı bulunamadı.";
                return View(); // Formu tekrar göster
            }

            var result = _passwordHasher.VerifyHashedPassword(mevcutMusteri, mevcutMusteri.MusteriSifre, musteriSifre);
            if (result == PasswordVerificationResult.Success)
            {
                HttpContext.Session.SetString("MusteriID", mevcutMusteri.MusteriID.ToString());
                HttpContext.Session.SetString("MusteriAd", mevcutMusteri.MusteriAd);
                HttpContext.Session.SetString("MusteriMail", mevcutMusteri.MusteriMail);

                TempData["msj"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Home");
            }

            TempData["msj"] = "Şifreniz yanlış. Lütfen tekrar deneyin.";
            return View();  // Formu tekrar göster
        }



        [HttpGet]
        public IActionResult Logout()
        {
            // Oturumu temizle
            HttpContext.Session.Clear();
            TempData["msj"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("MusteriGiris", "Account");
        }

        [HttpGet]
        public IActionResult Profil()
        {
            // Oturumdaki kullanıcı bilgilerini kontrol et
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris", "Account");
            }

            // Kullanıcının bilgilerini yükle
            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
                return RedirectToAction("MusteriGiris", "Account");
            }

            return View(musteri);
        }


        public IActionResult MusteriList()
        {
            var musteriler = db.Musteriler.ToList();
            ViewBag.Msj = TempData["msj"];
            return View(musteriler);
        }
    }

}