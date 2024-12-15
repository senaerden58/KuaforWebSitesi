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
        public async Task<List<DateTime>> GetUygunSaatler(int calisanID, DateTime tarih, int hizmetSuresi, int hizmetID)
        {
            // Tarihe göre gün bilgisini alıyoruz
            var gunAdi = tarih.DayOfWeek.ToString();  // Pazartesi, Salı vb. alıyoruz
            var gun = await db.Gunler
                .FirstOrDefaultAsync(g => g.GunAdi == gunAdi);

            if (gun == null)
            {
                throw new Exception("Gün bulunamadı.");
            }

            // İlgili gün ve çalışan için saat dilimlerini alıyoruz
            var calisanGunler = await db.CalisanGunler
                .Where(cs => cs.CalisanID == calisanID && cs.GunID == gun.GunID)
                .ToListAsync();

            if (calisanGunler == null || !calisanGunler.Any())
            {
                throw new Exception("Bu gün için uygun saatler bulunamadı.");
            }

            // Mevcut randevuları kontrol ediyoruz
            var mevcutRandevular = await db.Randevular
                .Where(r => r.CalisanID == calisanID && r.Tarih.Date == tarih.Date)
                .ToListAsync();

            List<DateTime> uygunSaatler = new List<DateTime>();

            // Saat aralıklarını döngü ile kontrol ediyoruz
            foreach (var calisanGun in calisanGunler)
            {
                TimeSpan baslangicSaati = calisanGun.BaslangicSaati; // Başlangıç saatini alıyoruz
                TimeSpan bitisSaati = calisanGun.BitisSaati; // Bitiş saatini alıyoruz

                // Başlangıç saatinden bitiş saatine kadar 30 dakikalık aralıklarla kontrol ediyoruz
                for (TimeSpan saat = baslangicSaati; saat < bitisSaati; saat = saat.Add(TimeSpan.FromMinutes(30))) // 30 dakikalık aralıklarla ekliyoruz
                {
                    // Mevcut randevularla çakışıp çakışmadığını kontrol ediyoruz
                    bool randevuCakismiyor = true;
                    foreach (var randevu in mevcutRandevular)
                    {
                        TimeSpan randevuBaslangic = randevu.Saat.TimeOfDay; // Randevunun başlangıç saatini alıyoruz
                        TimeSpan randevuBitis = randevuBaslangic.Add(TimeSpan.FromMinutes(hizmetSuresi)); // Randevunun bitiş saatini hesaplıyoruz

                        // Saat aralığının mevcut randevu ile çakışıp çakışmadığını kontrol ediyoruz
                        if ((saat >= randevuBaslangic && saat < randevuBitis) ||
                            (saat.Add(TimeSpan.FromMinutes(hizmetSuresi)) > randevuBaslangic && saat.Add(TimeSpan.FromMinutes(hizmetSuresi)) <= randevuBitis))
                        {
                            randevuCakismiyor = false;
                            break;
                        }
                    }

                    if (randevuCakismiyor)
                    {
                        // Eğer çakışma yoksa uygun saati listeye ekliyoruz
                        uygunSaatler.Add(tarih.Date.Add(saat)); // Tarih ile saati birleştirip ekliyoruz
                    }
                }
            }

            return uygunSaatler; // Uygun saatlerin listesini döndürüyoruz
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
                db.Randevular.Add(randevu);
                db.SaveChanges();

                TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
                return RedirectToAction("RandevuList");
            }
            catch (Exception ex)
            {
                TempData["msj"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction("RandevuAl");
            }
        }




        public IActionResult RandevuList()
        {
            var randevular = db.Randevular.Include(r => r.Hizmet).Include(r => r.Calisan).ToList();
            return View(randevular);
        }

    }
}