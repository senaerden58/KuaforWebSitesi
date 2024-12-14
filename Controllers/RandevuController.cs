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
        public IActionResult RandevuAlPost(int hizmetID)
        {
            // Seçilen hizmeti veren çalışanları bul
            var calisanlar = db.CalisanHizmetler
                .Where(ch => ch.HizmetID == hizmetID)
                .Select(ch => ch.Calisan)
                .ToList();

            ViewBag.Calisanlar = calisanlar; // Dinamik çalışan listesi
            ViewBag.Hizmetler = db.Hizmetler.ToList(); // Hizmetler tekrar gösterilsin
            ViewBag.SelectedHizmetID = hizmetID;

            return View("RandevuAl");
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

            return Json(gunAdlari); // Gün adlarını döndürüyoruz
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
