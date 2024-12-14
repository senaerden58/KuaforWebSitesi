using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace KuaforWebSitesi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly KuaforDBContext db;

        public RandevuController(KuaforDBContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult RandevuAl()
        {
            // Tüm hizmetleri ViewBag'e gönderiyoruz
            ViewBag.Hizmetler = db.Hizmetler.ToList();

            // Başlangıçta tüm çalışanları ViewBag'e gönderiyoruz
            ViewBag.Calisanlar = db.Calisanlar.ToList();

            return View();
        }

        // Hizmet seçildikten sonra çalışanları göster
        [HttpPost]
        public IActionResult RandevuAlPost(int hizmetID, int calisanID, string randevuGunu)
        {
            // Kullanıcının giriş yapıp yapmadığını kontrol et
            if (HttpContext.Session.GetString("UserID") == null)
            {
                TempData["msj"] = "Lütfen giriş yapınız.";
                return RedirectToAction("Login", "Account");
            }

            // Randevu işlemini burada yapabilirsiniz
            // ...

            TempData["msj"] = "Randevunuz başarıyla alınmıştır.";
            return RedirectToAction("RandevuAl");
        }

        [HttpGet]
        public async Task<IActionResult> GetCalisanGunler(int calisanID)
        {
            // Çalışanın hangi günlerde çalıştığını alıyoruz (GunID)
            var calisanGunler = await db.CalisanGunler
                .Where(cg => cg.CalisanID == calisanID)
                .Select(cg => cg.GunID)  // GunID'leri alıyoruz
                .ToListAsync();

            // Eğer çalışan için hiçbir gün yoksa, hata döndürüyoruz
            if (calisanGunler == null || calisanGunler.Count == 0)
            {
                return Json(new { error = "Hiç gün bulunamadı." });
            }

            // GunID'leri kullanarak gün adlarını alıyoruz
            var gunAdlari = await db.Gunler
                .Where(g => calisanGunler.Contains(g.GunID))  // Sadece ilgili GunID'leri alıyoruz
                .Select(g => g.GunAdi)  // Gün adlarını alıyoruz
                .ToListAsync();
            Console.WriteLine(string.Join(", ", gunAdlari)); // Log ekleyin
            return Json(gunAdlari); // Gün adlarını döndürüyoruz
        }
        [HttpGet]
        public JsonResult GetCalisanSaatler(int calisanID, string gun, int hizmetID)
        {
            // Çalışan için sabit çalışma saatleri (örneğin, 09:00 - 18:00)
            var baslangicSaat = TimeSpan.FromHours(9); // 09:00
            var bitisSaat = TimeSpan.FromHours(18);   // 18:00

            // Seçilen hizmetin süresi (dakika)
            var hizmetSure = db.Hizmetler
                .Where(h => h.HizmetID == hizmetID)
                .Select(h => h.Sure)
                .FirstOrDefault();

            // Tarihi dönüştürme
            if (!DateTime.TryParse(gun, out var tarih))
            {
                return Json(new { error = "Geçersiz tarih formatı." });
            }

            // Mevcut randevular
            var doluSaatler = db.Randevular
                .Where(r => r.CalisanID == calisanID && r.Tarih == tarih)
                .Select(r => new
                {
                    Baslangic = TimeSpan.Parse(r.Saat),
                    Bitis = TimeSpan.Parse(r.Saat).Add(TimeSpan.FromMinutes(hizmetSure)) // Bitis saati
                })
                .ToList();

            // Uygun saatleri hesapla
            var uygunSaatler = new List<string>();
            for (var saat = baslangicSaat; saat < bitisSaat; saat = saat.Add(TimeSpan.FromMinutes(30)))
            {
                var randevuSonu = saat.Add(TimeSpan.FromMinutes(hizmetSure));

                // Çalışma saatleri sınırında kontrol
                if (randevuSonu > bitisSaat) break;

                // Çakışma kontrolü
                var cakisma = doluSaatler.Any(d =>
                    (saat >= d.Baslangic && saat < d.Bitis) ||
                    (randevuSonu > d.Baslangic && randevuSonu <= d.Bitis));

                if (!cakisma)
                {
                    uygunSaatler.Add(saat.ToString(@"hh\:mm"));
                }
            }

            return Json(uygunSaatler);
        }




        [HttpGet]
        public JsonResult GetCalisanlar(int hizmetID)
        {
            // Hizmete göre çalışanları filtrele
            var calisanlar = db.Calisanlar
                .Where(c => c.CalisanHizmetler.Any(ch => ch.HizmetID == hizmetID))
                .Select(c => new
                {
                    calisanID = c.CalisanID,
                    ad = c.CalisanAd,
                    soyad = c.CalisanSoyad
                })
                .ToList();

            return Json(calisanlar);
        }

        // Randevu kaydını alıyoruz
        [HttpPost]
        public IActionResult RandevuAlFinal(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                db.Randevular.Add(randevu);
                db.SaveChanges();

                TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
                return RedirectToAction("RandevuList");
            }
            TempData["msj"] = "Bir hata oluştu. Lütfen tekrar deneyin.";
            return RedirectToAction("RandevuAl");
        }

        public IActionResult RandevuList()
        {
            var randevular = db.Randevular.Include(r => r.Hizmet).Include(r => r.Calisan).ToList();
            return View(randevular);
        }

    }
}
