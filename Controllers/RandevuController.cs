using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
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
        public ActionResult RandevuAl()
        {
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris", "Musteri");
            }
            var hizmetler = db.Hizmetler.ToList();

            var musteriler = db.Musteriler.ToList();
            if (hizmetler == null || hizmetler.Count == 0)
            {
                TempData["Error"] = "Hizmetler mevcut değil.";
            }
            else
            {
                ViewData["Hizmetler"] = hizmetler;
                ViewData["Musteriler"] = musteriler;
            }
            return View();
        }



        // Hizmet seçildikten sonra çalışanları göster
        [HttpPost]

        public IActionResult RandevuAlPost(int hizmetID, int calisanID, string randevuGunu)
        {
            // Kullanıcının giriş yapıp yapmadığını kontrol et
            var musteriID = HttpContext.Session.GetString("MusteriID");
            if (string.IsNullOrEmpty(musteriID))
            {
                TempData["msj"] = "Lütfen giriş yapın.";
                return RedirectToAction("MusteriGiris");  // Yönlendirme doğru mu?
            }
            // Seçilen hizmet, çalışan ve tarih bilgilerini kontrol et
            if (hizmetID == 0 || calisanID == 0 || string.IsNullOrEmpty(randevuGunu))
            {
                TempData["msj"] = "Lütfen tüm alanları doldurduğunuzdan emin olun.";
                return RedirectToAction("RandevuAl");
            }

            // Geçerli bir tarih formatı olup olmadığını kontrol et
            DateTime selectedDate;
            if (!DateTime.TryParse(randevuGunu, out selectedDate))
            {
                TempData["msj"] = "Geçersiz tarih formatı.";
                return RedirectToAction("RandevuAl");
            }

            // Hizmet süresi, çalışan saatleri ve diğer ilgili verilerle randevu oluşturulabilir
            // ...

            // İşlemi tamamladıktan sonra başarılı mesajı gönder
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
        public async Task<List<TimeSpan>> GetUygunSaatler(int calisanID, DateTime tarih, int hizmetID)
        {
            // Seçilen hizmetin süresini alıyoruz
            var hizmet = await db.Hizmetler
                .FirstOrDefaultAsync(h => h.HizmetID == hizmetID);

            if (hizmet == null)
            {
                throw new Exception("Seçilen hizmet bulunamadı.");
            }

            TimeSpan hizmetSuresi = hizmet.Sure; // Hizmet süresi zaten TimeSpan türünde, direkt alıyoruz

            // Tarihe göre çalışanın çalışma saatlerini alıyoruz
            var gunAdi = tarih.DayOfWeek.ToString(); // Pazartesi, Salı vb.
            var calisanGun = await db.CalisanGunler
                .FirstOrDefaultAsync(cg => cg.CalisanID == calisanID && cg.GunID == (int)tarih.DayOfWeek);

            if (calisanGun == null)
            {
                throw new Exception("Bu gün için çalışma saatleri bulunamadı.");
            }

            var mevcutRandevular = await db.Randevular
                .Where(r => r.CalisanID == calisanID && r.Tarih.Date == tarih.Date)
                .ToListAsync();

            var uygunSaatler = new List<TimeSpan>();

            // Çalışma saatleri arasında uygun saatleri kontrol ediyoruz
            for (var saat = calisanGun.BaslangicSaati;
                 saat < calisanGun.BitisSaati;
                 saat = saat.Add(hizmetSuresi)) // Hizmet süresi kadar aralık
            {
                bool cakismaVar = mevcutRandevular.Any(r =>
                {
                    var randevuBaslangic = r.Saat;
                    TimeSpan randevuBitis = randevuBaslangic.Add(hizmetSuresi); // Hizmet süresini ekliyoruz
                    TimeSpan yeniRandevuBitis = saat.Add(hizmetSuresi); // Yeni randevu bitiş saati

                    return (saat >= randevuBaslangic && saat < randevuBitis) ||
                           (yeniRandevuBitis > randevuBaslangic && yeniRandevuBitis <= randevuBitis);
                });

                if (!cakismaVar)
                {
                    uygunSaatler.Add(saat);
                }
            }

            return uygunSaatler;
        }





        [HttpPost]
      
        public IActionResult RandevuAlFinal(Randevu randevu)
        {
            // Validate required fields
            if (randevu.HizmetID == 0 || randevu.CalisanID == 0 || randevu.MusteriID == 0)
            {
                TempData["msj"] = "Lütfen tüm alanları doğru doldurduğunuzdan emin olun.";
                return RedirectToAction("RandevuAl");
            }

            try
            {
                // Saat ve tarih bilgilerini birleştirme
                if (randevu.Tarih < DateTime.Now.Date)
                {
                    TempData["msj"] = "Geçmiş bir tarih seçilemez.";
                    return RedirectToAction("RandevuAl"); // Bu işlemdeki yönlendirme kullanıcıyı tekrar doğru sayfaya yönlendirir.
                }

                // Veritabanına kaydetme
                db.Randevular.Add(randevu);
                db.SaveChanges();

                // Başarı mesajı
                TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
                return RedirectToAction("RandevuList", new { id = randevu.RandevuID });
            }
            catch (Exception ex)
            {
                TempData["msj"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction("RandevuAl");  // Hata durumunda yönlendirme tekrar form sayfasına yapılır.
            }
        }





        public async Task<IActionResult> RandevuList()
        {
            var randevular = await db.Randevular
                .Include(r => r.Hizmet) // Hizmet bilgisini de ekliyoruz
                .Include(r => r.Calisan) // Çalışan bilgisini de ekliyoruz
                .ToListAsync();

            return View();
        }

    }
}