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


        /* musteri*/
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> MusteriKaydet(Musteri musteri) 
        {
            if (!ModelState.IsValid)
            {
                // Model geçerli değilse hata mesajlarını kontrol et
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }

                TempData["msj"] = "Kayıt işlemi başarısız. Lütfen alanları kontrol edin.";
                return RedirectToAction("MusteriEkle"); // Kullanıcıyı 'MusteriEkle' görünümüne yönlendir
            }

            try
            {
                // Şifreyi hash'le
                musteri.MusteriSifre = _passwordHasher.HashPassword(musteri, musteri.MusteriSifre);

                // Müşteriyi veritabanına ekle
                db.Musteriler.Add(musteri);

                // Asenkron olarak veritabanına kaydet
                await db.SaveChangesAsync();

                // Başarılı işlem sonrası mesaj gönder
                TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri kaydedildi.";
                return RedirectToAction("MusteriList"); // Başarılı kayıt sonrası listeye yönlendir
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                TempData["msj"] = $"Kayıt işlemi sırasında bir hata oluştu: {ex.Message}";
                return RedirectToAction("MusteriEkle"); // Kullanıcıyı 'MusteriEkle' görünümüne yönlendir
            }
        }


        /* musteri*/

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

            var admin = db.Admin.FirstOrDefault(a => a.AdminMail == musteriMail);
            if (admin != null && musteriSifre == admin.AdminSifre)
            {
                // Admin giriş yaptıysa
                TempData["msj"] = "Admin Girişi Başarılı!";
                return RedirectToAction("AdminPaneli", "Admin");
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


        /* musteri*/
        [HttpGet]
        public IActionResult MusteriCikis()
        {
            HttpContext.Session.Clear();
            TempData["msj"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("MusteriGiris", "Musteri");
        }


        /*admin*/
        [HttpGet]
        public IActionResult MusteriGoruntule()
        {
            // Oturumdaki kullanıcı bilgilerini kontrol et
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris", "Musteri");
            }

            // Kullanıcının bilgilerini yükle
            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
                return RedirectToAction("MusteriGiris", "Musteri");
            }

            return View(musteri);
        }

        /*admin*/
        [HttpGet]
        public IActionResult MusteriAra(string aramaKriteri)
        {
            // Arama kriteri girilmişse
            if (!string.IsNullOrEmpty(aramaKriteri))
            {
                // Ad, soyad veya mail adresine göre arama yapıyoruz
                var bulunanMusteriler = db.Musteriler
                    .Where(m => m.MusteriAd.Contains(aramaKriteri) ||
                                m.MusteriSoyad.Contains(aramaKriteri) ||
                                m.MusteriMail.Contains(aramaKriteri))
                    .ToList();

                return View("MusteriList", bulunanMusteriler);  // Bulunan müşteriler listelenir
            }

            // Eğer arama yapılmamışsa, tüm müşteriler listelenir
            var tumMusteriler = db.Musteriler.ToList();
            return View("MusteriList", tumMusteriler);  // Tüm müşteri listesi gösterilir
        }

        /*admin*/
        [HttpGet]
        public IActionResult MusteriSil(int id)
        {
            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == id);
            if (musteri == null)
            {
                TempData["msj"] = "Silinecek müşteri bulunamadı.";
                return RedirectToAction("MusteriList");
            }

            // Müşteriyi sil
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri başarıyla silindi.";

            return RedirectToAction("MusteriList");
        }
        [HttpGet]

        /* musteri*/
        public IActionResult ProfilGoruntule()
        {
            // Oturumdaki müşteri ID'sini al
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris");
            }

            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
                return RedirectToAction("MusteriGiris");
            }

            return View(musteri);
        }


        /* musteri*/
        [HttpGet]
        public IActionResult SifreDegistir()
        {
            return View();
        }
        /* musteri*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SifreDegistir(string eskiSifre, string yeniSifre, string telefonNumarasi)
        {
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris");
            }

            var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Müşteri bulunamadı.";
                return RedirectToAction("MusteriGiris");
            }

            // Telefon numarası doğrulama
            if (mevcutMusteri.MusteriTelefon != telefonNumarasi)
            {
                TempData["msj"] = "Telefon numarası doğrulanamadı.";
                return View();
            }

            var result = _passwordHasher.VerifyHashedPassword(mevcutMusteri, mevcutMusteri.MusteriSifre, eskiSifre);
            if (result == PasswordVerificationResult.Success)
            {
                mevcutMusteri.MusteriSifre = _passwordHasher.HashPassword(mevcutMusteri, yeniSifre);
                db.Musteriler.Update(mevcutMusteri);
                db.SaveChanges();
                TempData["msj"] = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("ProfilGoruntule");
            }

            TempData["msj"] = "Eski şifreniz yanlış.";
            return View();
        }


        /* musteri*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfilGuncelle(Musteri musteri)
        {
            if (!ModelState.IsValid)
            {
                TempData["msj"] = "Lütfen tüm alanları doldurun.";
                return View(musteri);
            }

            var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == musteri.MusteriID);
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Müşteri bulunamadı.";
                return RedirectToAction("MusteriGiris");
            }

            // Müşteri bilgilerini güncelle
            mevcutMusteri.MusteriAd = musteri.MusteriAd;
            mevcutMusteri.MusteriSoyad = musteri.MusteriSoyad;
            mevcutMusteri.MusteriMail = musteri.MusteriMail;
            mevcutMusteri.MusteriTelefon = musteri.MusteriTelefon;

            db.Musteriler.Update(mevcutMusteri);
            await db.SaveChangesAsync();

            TempData["msj"] = "Profil başarıyla güncellendi.";
            return RedirectToAction("ProfilGoruntule");
        }
        /*admin*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MusteriGuncelle(Musteri musteri)
        {
            if (!ModelState.IsValid)
            {
                TempData["msj"] = "Lütfen tüm alanları doldurun.";
                return View(musteri);
            }

            var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == musteri.MusteriID);
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Müşteri bulunamadı.";
                return RedirectToAction("MusteriList");
            }

            // Mevcut müşteri verilerini güncelle
            mevcutMusteri.MusteriAd = musteri.MusteriAd;
            mevcutMusteri.MusteriSoyad = musteri.MusteriSoyad;
            mevcutMusteri.MusteriMail = musteri.MusteriMail;
            mevcutMusteri.MusteriTelefon = musteri.MusteriTelefon;

            db.Musteriler.Update(mevcutMusteri);
            await db.SaveChangesAsync();

            TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri başarıyla güncellendi.";
            return RedirectToAction("MusteriList");
        }


        public IActionResult MusteriList()
        {
            var musteriler = db.Musteriler.ToList();
            ViewBag.Msj = TempData["msj"];
            return View(musteriler);
        }

    }
}