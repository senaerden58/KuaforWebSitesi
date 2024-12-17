using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace KuaforWebSitesi.Controllers
{
    public class CalisanController : Controller
    {
       
        private readonly KuaforDBContext db;
        private readonly PasswordHasher<Calisan> _passwordHasher;
        private readonly ILogger<CalisanController> _logger;
       
        public CalisanController(KuaforDBContext context, PasswordHasher<Calisan> passwordHasher, ILogger<CalisanController> logger)
        {
            db = context;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult CalisanEkle()
        {
            // Tüm günleri veritabanından al
            var gunler = db.Gunler.ToList();
            var hizmetler = db.Hizmetler.ToList();

          

            // Günleri ve hizmetleri ViewBag içine gönder
            ViewBag.Gunler = gunler;
            ViewBag.Hizmetler = hizmetler;

            return View(); // View'a geçiş yap
        }




        [HttpGet]
        public IActionResult CalisanGiris()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CalisanKaydet([Bind("CalisanAd,CalisanSoyad,CalisanMail,CalisanTelefon,CalisanSifre")] Calisan calisan, int[] selectedGunler, int[] selectedHizmetler)
        {
            if (!ModelState.IsValid)
            {
                return View("CalisanEkle"); // Model geçersizse, formu geri gönder
            }

            try
            {
                // Çalışanın şifresini hash'le
                calisan.CalisanSifre = _passwordHasher.HashPassword(calisan, calisan.CalisanSifre);

                // Çalışanı veritabanına ekle
                db.Calisanlar.Add(calisan);
                await db.SaveChangesAsync(); // Çalışanı kaydet ve CalisanID'yi al

                // Seçilen günleri ekle
                foreach (var gunID in selectedGunler)
                {
                    var calisanGun = new CalisanGun
                    {
                        CalisanID = calisan.CalisanID, // Çalışanın ID'si
                        GunID = gunID // Seçilen günün ID'si
                    };
                    db.CalisanGunler.Add(calisanGun); // Çalışan ve gün ilişkisini ekle
                }

                // Seçilen hizmetleri ekle
                foreach (var hizmetID in selectedHizmetler)
                {
                    var calisanHizmet = new CalisanHizmetler
                    {
                        CalisanID = calisan.CalisanID, // Çalışanın ID'si
                        HizmetID = hizmetID // Seçilen hizmetin ID'si
                    };
                    db.CalisanHizmetler.Add(calisanHizmet); // Çalışan ve hizmet ilişkisini ekle
                }

                // Günleri ve hizmetleri kaydet
                await db.SaveChangesAsync();

                return RedirectToAction("Index"); // Başarıyla kaydedildikten sonra yönlendirme
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya mesaj göster
                TempData["ErrorMessage"] = "Bir hata oluştu: " + ex.Message;
                return View("CalisanEkle"); // Hata varsa, formu tekrar göster
            }
        }





        public IActionResult CalisanGuncelle(int id)
        {
            var calisan = db.Calisanlar.Find(id); // Performans için Find() kullanıyoruz
            if (calisan == null)
            {
                TempData["msj"] = "Güncellenecek çalışan bulunamadı.";
                return RedirectToAction("CalisanList");
            }
            return View(calisan);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalisanGuncelle(Calisan calisan)
        {
            if (!ModelState.IsValid)
            {
                TempData["msj"] = "Çalışan güncelleme işlemi başarısız. Lütfen alanları kontrol edin.";
                return View(calisan);
            }

            var calisanDb = db.Calisanlar.Find(calisan.CalisanID); // Performans için Find() kullanıyoruz
            if (calisanDb == null)
            {
                TempData["msj"] = "Güncellenen çalışan bulunamadı.";
                return RedirectToAction("CalisanList");
            }

            // Şifreyi değiştirme
            if (!string.IsNullOrEmpty(calisan.CalisanSifre))
            {
                calisan.CalisanSifre = _passwordHasher.HashPassword(calisan, calisan.CalisanSifre);
            }
            else
            {
                calisan.CalisanSifre = calisanDb.CalisanSifre; // Eski şifreyi koruyalım
            }

            // Veritabanında güncelleme işlemi
            calisanDb.CalisanAd = calisan.CalisanAd;
            calisanDb.CalisanSoyad = calisan.CalisanSoyad;
            calisanDb.CalisanMail = calisan.CalisanMail;
            calisanDb.CalisanTelefon = calisan.CalisanTelefon;
           

            db.SaveChanges();

            TempData["msj"] = $"{calisan.CalisanAd} adlı çalışan başarıyla güncellendi.";
            return RedirectToAction("CalisanList");
        }




        public IActionResult CalisanSil(int id)
        {
            var calisan = db.Calisanlar.Find(id); // Performans için Find() kullanıyoruz
            if (calisan == null)
            {
                TempData["msj"] = "Silinecek çalışan bulunamadı.";
                return RedirectToAction("CalisanList");
            }

            // Çalışanın randevularını silme işlemi (isteğe bağlı)
            db.Randevular.RemoveRange(db.Randevular.Where(r => r.CalisanID == calisan.CalisanID)); // Çalışanın randevuları silinebilir

            db.Calisanlar.Remove(calisan);
            db.SaveChanges();

            TempData["msj"] = $"{calisan.CalisanAd} adlı çalışan başarıyla silindi.";
            return RedirectToAction("CalisanList");
        }




        public IActionResult CalisanList()
        {
            var calisanlar = db.Calisanlar.ToList();
            ViewBag.Msj = TempData["msj"];
            return View(calisanlar);
        }

    }
}
