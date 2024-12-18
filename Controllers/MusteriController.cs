﻿using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;

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


        /* musteri tamamlandı*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MusteriKaydet(Musteri musteri) 
        {
            var varOlanEmailler = db.Musteriler.FirstOrDefault(m => m.MusteriMail == musteri.MusteriMail);
            var varOlanTelefonlar = db.Musteriler.FirstOrDefault(m => m.MusteriTelefon == musteri.MusteriTelefon);
            if (varOlanEmailler != null)
            {
                TempData["msj"] = "Bu e-posta adresi zaten kayıtlı.";
                return RedirectToAction("MusteriEkle"); // Müşteri kayıt sayfasına geri yönlendir
            }

            if (varOlanTelefonlar != null)
            {
                TempData["msj"] = "Bu telefon numarası zaten kayıtlı.";
                return RedirectToAction("MusteriEkle"); // Müşteri kayıt sayfasına geri yönlendir
            }

            if (!ModelState.IsValid)
            {
                // Model geçerli değilse hata mesajlarını kontrol et
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Hata: {error.ErrorMessage}");
                }

                TempData["msj"] = "Kayıt işlemi başarısız. Lütfen alanları kontrol edin.";
                return RedirectToAction("MusteriEkle"); 
            }

            try
            {
                musteri.MusteriSifre = _passwordHasher.HashPassword(musteri, musteri.MusteriSifre);
               
                db.Musteriler.Add(musteri);
               
                await db.SaveChangesAsync();
                var musteriRol = new MusteriRol
                {
                    MusteriID = musteri.MusteriID,  // Yeni kaydedilen müşteri ID'sini alıyoruz
                    RolID = 2 // Varsayılan olarak "Müşteri" rolünü atıyoruz
                };

                // MusteriRol ilişkilendirmesini kaydediyoruz
                db.MusteriRoller.Add(musteriRol);
                await db.SaveChangesAsync();
                TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri kaydedildi.";
                return RedirectToAction("MusteriList"); 
            }
            catch (Exception ex)
            {
                // Hata durumunda mesaj göster
                TempData["msj"] = $"Kayıt işlemi sırasında bir hata oluştu: {ex.Message}";
                return RedirectToAction("MusteriEkle"); 
            }
        }


        /* musteri tamamlandı*/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MusteriGiris(string musteriMail, string musteriSifre)
        {
            
            if (string.IsNullOrEmpty(musteriMail) || string.IsNullOrEmpty(musteriSifre))
            {
                TempData["msj"] = "E-posta ve şifre alanlarını doldurun.";
                return View();  
            }
            var mevcutMusteri = db.Musteriler
                .Include(m => m.MusteriRoller)
                .ThenInclude(mr => mr.Rol)
                .FirstOrDefault(m => m.MusteriMail == musteriMail);
 
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Bu e-posta ile kayıtlı bir kullanıcı bulunamadı.";
                return View(); 
            }

       
            var result = _passwordHasher.VerifyHashedPassword(mevcutMusteri, mevcutMusteri.MusteriSifre, musteriSifre);
            if (result == PasswordVerificationResult.Success)
            {

                HttpContext.Session.SetString("MusteriID", mevcutMusteri.MusteriID.ToString());
                HttpContext.Session.SetString("MusteriAd", mevcutMusteri.MusteriAd);
                HttpContext.Session.SetString("MusteriMail", mevcutMusteri.MusteriMail);
                var rol = mevcutMusteri.MusteriRoller.FirstOrDefault()?.Rol; // İlk ilişkili rol alınıyor
                if (rol != null && rol.RolID == 1) // RoleID kontrolü
                {
                    HttpContext.Session.SetInt32("RolID", rol.RolID); // RolID session'a kaydediliyor
                    TempData["msj"] = "Admin girişi başarılı!";
                    return RedirectToAction("Index", "Home"); // Admin paneline yönlendirilir
                }
                TempData["msj"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Home");
            }

            TempData["msj"] = "Şifreniz yanlış. Lütfen tekrar deneyin.";
            return View();
        }

        /* musteri tamamlandı */
        [HttpGet]
        public IActionResult MusteriCikis()
        {
            HttpContext.Session.Clear();
            TempData["msj"] = "Başarıyla çıkış yaptınız.";
            return RedirectToAction("MusteriGiris", "Musteri");
        }


      
        public IActionResult AdminPaneli()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MusteriGoruntule(int id)
        {
            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == id);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
                return RedirectToAction("MusteriGoruntule", "Admin");  // Adminin müşteri arama sayfasına yönlendirme
            }

            return View(musteri);  // Müşteri bilgilerini adminin görebileceği şekilde görüntüleme
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
     
        //[HttpGet]
        //public IActionResult MusteriSil(int id)
        //{
        //    var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == id);
        //    if (musteri == null)
        //    {
        //        TempData["msj"] = "Silinecek müşteri bulunamadı.";
        //        return RedirectToAction("MusteriList");
        //    }
        
        //    // Müşteriyi sil
        //    db.Musteriler.Remove(musteri);
        //    db.SaveChanges();
        //    TempData["msj"] = $"{musteri.MusteriAd} adlı müşteri başarıyla silindi.";
        
        //    return RedirectToAction("MusteriList");
        //}


        /* musteri tamamlandı*/

        [HttpGet]
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

      
        /* musteri tamamlandı*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SifreDegistir(string eskiSifre, string yeniSifre, string yeniSifreOnayi)
        {
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris");
            }

            var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bulunamadı.";
                return RedirectToAction("MusteriGiris");
            }

            var passwordHasher = new PasswordHasher<Musteri>();
            var result = passwordHasher.VerifyHashedPassword(musteri, musteri.MusteriSifre, eskiSifre);

            if (result == PasswordVerificationResult.Failed)
            {
                TempData["msj"] = "Mevcut şifre yanlış.";
                return RedirectToAction("ProfilGuncelle");
            }

            // Yeni şifre mevcut şifre ile aynı olmamalı
            if (eskiSifre == yeniSifre)
            {
                TempData["msj"] = "Yeni şifre mevcut şifre ile aynı olamaz.";
                return RedirectToAction("ProfilGuncelle");
            }

            // Yeni şifreyi ve onay şifresini kontrol etme
            if (yeniSifre != yeniSifreOnayi)
            {
                TempData["msj"] = "Yeni şifreler eşleşmiyor.";
                return RedirectToAction("ProfilGuncelle");
            }

            // Yeni şifreyi şifreleyerek güncelleme
            musteri.MusteriSifre = passwordHasher.HashPassword(musteri, yeniSifre);
            db.Musteriler.Update(musteri);
            await db.SaveChangesAsync();

            TempData["msj"] = "Şifre başarıyla güncellendi.";
            return RedirectToAction("ProfilGoruntule"); // Profil görüntüleme sayfasına yönlendir
        }


        /* musteri tamamlandı*/
        // HttpGet: Profil Güncelleme Sayfasını Görüntüleme

        [HttpGet]
        public IActionResult ProfilGuncelle()
        {
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris");
            }

            var musteri = db.Musteriler.SingleOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (musteri == null)
            {
                TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
                return RedirectToAction("MusteriGiris");
            }

            return View(musteri); // Mevcut müşteri bilgileriyle formu göster
        }



        /*musteri tamamlandı*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProfilGuncelle(Musteri musteri)
        {
            if (!ModelState.IsValid)
            {
                // Hatalı form durumunda mevcut modelle tekrar formu döndür
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Hata: " + error.ErrorMessage);  // Hata mesajlarını konsola yazdırıyoruz
                }

                TempData["msj"] = "Lütfen tüm alanları doldurun.";
                return View(musteri);
            }

          
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Oturum süresi dolmuş. Lütfen tekrar giriş yapın.";
                return RedirectToAction("MusteriGiris");
            }

            var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
            if (mevcutMusteri == null)
            {
                TempData["msj"] = "Müşteri bulunamadı.";
                return RedirectToAction("MusteriGiris");
            }

            // E-posta kontrolü, güncellenen müşteri hariç
            var varOlanEmailler = db.Musteriler
                .FirstOrDefault(m => m.MusteriMail == musteri.MusteriMail && m.MusteriID != mevcutMusteri.MusteriID);
            if (varOlanEmailler != null)
            {
                TempData["msj"] = "Bu e-posta adresi başka bir müşteri tarafından kullanılıyor.";
                return View(musteri); // Hata mesajıyla birlikte tekrar formu döndürüyoruz
            }

            // Telefon kontrolü, güncellenen müşteri hariç
            var varOlanTelefonlar = db.Musteriler
                .FirstOrDefault(m => m.MusteriTelefon == musteri.MusteriTelefon && m.MusteriID != mevcutMusteri.MusteriID);
            if (varOlanTelefonlar != null)
            {
                TempData["msj"] = "Bu telefon numarası başka bir müşteri tarafından kullanılıyor.";
                return View(musteri); // Hata mesajıyla birlikte tekrar formu döndürüyoruz
            }


            var passwordHasher = new PasswordHasher<Musteri>();
            var result = passwordHasher.VerifyHashedPassword(mevcutMusteri, mevcutMusteri.MusteriSifre, musteri.MusteriSifre);

            if (result == PasswordVerificationResult.Failed)
            {
                TempData["msj"] = "Şifre yanlış. Lütfen tekrar deneyin.";
                return View(musteri);  // Formu yeniden döndürüyoruz
            }
                  
            mevcutMusteri.MusteriAd = musteri.MusteriAd;
            mevcutMusteri.MusteriSoyad = musteri.MusteriSoyad;
            mevcutMusteri.MusteriMail = musteri.MusteriMail;
            mevcutMusteri.MusteriTelefon = musteri.MusteriTelefon; 

            db.Musteriler.Update(mevcutMusteri);
            await db.SaveChangesAsync();  

            TempData["msj"] = "Profil başarıyla güncellendi.";
            return RedirectToAction("ProfilGoruntule"); 
        }

        ///*admin*/
        //[HttpGet]
        //public IActionResult MusteriGuncelle(int id)
        //{
        //    var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == id);

        //    if (musteri == null)
        //    {
        //        TempData["msj"] = "Bulunamadi."; 
        //    }

        //    return View(musteri); // Müşteri bilgilerini MusteriGuncelle.cshtml sayfasına gönder
        //}

        /*admin*/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> MusteriGuncelle(int id, Musteri musteri)
        //{
        //    var mevcutMusteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == id);
        //    if (mevcutMusteri == null )
        //    {
        //        TempData["msj"] = "Müşteri bulunamadı.";
        //        return RedirectToAction("MusteriGiris");
        //    }
        //    var varOlanEmailler = db.Musteriler
        //       .FirstOrDefault(m => m.MusteriMail == musteri.MusteriMail && m.MusteriID != mevcutMusteri.MusteriID);
        //    if (varOlanEmailler != null)
        //    {
        //        TempData["msj"] = "Bu e-posta adresi başka bir müşteri tarafından kullanılıyor.";
        //        return View(musteri); // Hata mesajıyla birlikte tekrar formu döndürüyoruz
        //    }

        //    // Telefon kontrolü, güncellenen müşteri hariç
        //    var varOlanTelefonlar = db.Musteriler
        //        .FirstOrDefault(m => m.MusteriTelefon == musteri.MusteriTelefon && m.MusteriID != mevcutMusteri.MusteriID);
        //    if (varOlanTelefonlar != null)
        //    {
        //        TempData["msj"] = "Bu telefon numarası başka bir müşteri tarafından kullanılıyor.";
        //        return View(musteri); // Hata mesajıyla birlikte tekrar formu döndürüyoruz
        //    }

        //    var passwordHasher = new PasswordHasher<Musteri>();
        //    var result = passwordHasher.VerifyHashedPassword(mevcutMusteri, mevcutMusteri.MusteriSifre, musteri.MusteriSifre);

        //    if (result == PasswordVerificationResult.Failed)
        //    {
        //        TempData["msj"] = "Şifre yanlış. Lütfen tekrar deneyin.";
        //        return View(musteri);  // Formu yeniden döndürüyoruz
        //    }

        //    mevcutMusteri.MusteriAd = musteri.MusteriAd;
        //    mevcutMusteri.MusteriSoyad = musteri.MusteriSoyad;
        //    mevcutMusteri.MusteriMail = musteri.MusteriMail;
        //    mevcutMusteri.MusteriTelefon = musteri.MusteriTelefon;

        //    db.Musteriler.Update(mevcutMusteri);
        //    await db.SaveChangesAsync();
        //    TempData["msj"] = "Profil başarıyla güncellendi.";
        //    return RedirectToAction("ProfilGoruntule");
        //}

        public IActionResult MusteriList()
        {
            Debug.WriteLine("abc");


            // Session'dan kullanıcı bilgilerini kontrol et
            var userRoleId = HttpContext.Session.GetInt32("RolID"); // Kullanıcı rol ID'sini session'dan alıyoruz
            Console.WriteLine("User Role ID: " + userRoleId); // Debug amacıyla, konsola yazdırıyoruz
            if (userRoleId == 0 || userRoleId == 2 || userRoleId == null) // Eğer oturumda kullanıcı bilgisi yoksa
            {
                Debug.WriteLine("giris yapamamissin");
                return RedirectToAction("MusteriGiris", "Musteri");
            }

            Debug.WriteLine("User Role ID: " + userRoleId);

            // Giriş yapmışsa müşteri listesini getir
            var musteriler = db.Musteriler.ToList();
            ViewBag.Msj = TempData["msj"];
            return View(musteriler);
        }



        ///*musteri tamalandı*/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> MusteriHesapSil()
        //{
        //    var musteriID = HttpContext.Session.GetString("MusteriID");
        //    if (string.IsNullOrEmpty(musteriID))
        //    {
        //        TempData["msj"] = "Oturum süresi dolmuş. Lütfen tekrar giriş yapın.";
        //        return RedirectToAction("MusteriGiris");
        //    }

        //    var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
        //    if (musteri == null)
        //    {
        //        TempData["msj"] = "Müşteri bulunamadı.";
        //        return RedirectToAction("MusteriGiris");
        //    }

        //    try
        //    {
        //        // Müşteriyi sil
        //        db.Musteriler.Remove(musteri);
        //        await db.SaveChangesAsync();

        //        // Oturumu sonlandır
        //        HttpContext.Session.Clear();

        //        TempData["msj"] = "Hesabınız başarıyla silindi.";
        //        return RedirectToAction("MusteriGiris"); // Kullanıcıyı giriş sayfasına yönlendir
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["msj"] = $"Hesap silme işlemi sırasında bir hata oluştu: {ex.Message}";
        //        return RedirectToAction("ProfilGoruntule"); // Profil sayfasına geri yönlendir
        //    }
        //}

       



    }
}