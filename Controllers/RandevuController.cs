using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KuaforWebSitesi.Controllers
{
    public class RandevuController : Controller
    {
        private readonly KuaforDBContext db;

        public RandevuController(KuaforDBContext context)
        {
            db = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RandevuEkle(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                // Randevuyu veritabanına kaydet
                db.Randevular.Add(randevu);
                await db.SaveChangesAsync();

                // Randevu başarıyla kaydedildi
                TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
                return RedirectToAction("RandevuList");
            }
            // Eğer geçersizse, tekrar formu göster
            return View(randevu);
        }


        //public async Task<IActionResult> Index()
        //{
        //    var musteriID = HttpContext.Session.GetString("MusteriID"); // Giriş yapan kullanıcının ID'si
        //    if (string.IsNullOrEmpty(musteriID))
        //    {
        //        TempData["msj"] = "Lütfen önce giriş yapın.";
        //        return RedirectToAction("MusteriGiris", "Account"); // Giriş yapmamış kullanıcıyı giriş sayfasına yönlendir
        //    }

        //    // Kullanıcının kendi randevularını filtreleyin
        //    var randevular = await db.Randevular
        //        .Where(r => r.MusteriID.ToString() == musteriID) // Kullanıcının ID'si ile randevuları filtrele
        //        .Include(r => r.Calisan) // Çalışan bilgilerini dahil et
        //        .Include(r => r.Hizmet)  // Hizmet bilgilerini dahil et
        //        .ToListAsync(); // Veritabanından listeyi çek

        //    return View(randevular); // Randevuları View'a gönder
        //}


        //// Yeni Randevu Alma Sayfası
        //public IActionResult YeniRandevu()
        //{
        //    // Kullanıcının o gün ve saatte uygun çalışanlarını listeleyin
        //    var calisanlar = db.Calisanlar.ToList();
        //    var hizmetler = db.Hizmetler.ToList();

        //    ViewBag.Calisanlar = calisanlar;
        //    ViewBag.Hizmetler = hizmetler;
        //    return View();
        //}


        //// Yeni Randevu Kaydetme
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult YeniRandevu(Randevu randevu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var musteriID = HttpContext.Session.GetString("MusteriID");
        //        if (string.IsNullOrEmpty(musteriID))
        //        {
        //            TempData["msj"] = "Lütfen önce giriş yapın.";
        //            return RedirectToAction("MusteriGiris", "Account");
        //        }

        //        // Müşteri bilgilerini al
        //        var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID.ToString() == musteriID);
        //        if (musteri == null)
        //        {
        //            TempData["msj"] = "Kullanıcı bilgilerine ulaşılamadı.";
        //            return RedirectToAction("MusteriGiris", "Account");
        //        }

        //        randevu.MusteriID = musteri.MusteriID; // Müşteri bilgilerini randevoya ekle
        //        db.Randevular.Add(randevu);
        //        db.SaveChanges();
        //        TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    ViewBag.Calisanlar = db.Calisanlar.ToList();
        //    ViewBag.Hizmetler = db.Hizmetler.ToList();
        //    return View(randevu);
        //}
        //public async Task<IActionResult> Onayla(int id)
        //{
        //    var randevu = await db.Randevular.FindAsync(id);
        //    if (randevu != null)
        //    {
        //        randevu.Durum = "Onaylandı"; // Durumu onayla
        //        await db.SaveChangesAsync();
        //        TempData["msj"] = "Randevunuz onaylandı.";
        //    }
        //    return RedirectToAction(nameof(Index));
        //}



        //// Randevu Silme
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Sil(int id)
        //{
        //    var randevu = await db.Randevular.FindAsync(id);

        //    // Randevunun bulunup bulunmadığını ve kullanıcının bu randevuya sahip olup olmadığını kontrol et
        //    if (randevu != null && randevu.MusteriID.ToString() == HttpContext.Session.GetString("MusteriID"))
        //    {
        //        db.Randevular.Remove(randevu);
        //        await db.SaveChangesAsync();
        //        TempData["msj"] = "Randevunuz başarıyla silindi.";
        //    }
        //    else
        //    {
        //        TempData["msj"] = "Bu randevuya erişiminiz yok.";
        //    }

        //    return RedirectToAction(nameof(Index)); // Listeyi tekrar göster
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> RandevuEkle(Randevu randevu)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Müşteri, çalışan ve hizmet var mı kontrol et
        //        var musteri = await db.Musteri.FindAsync(randevu.MusteriID);
        //        var calisan = await db.Calisan.FindAsync(randevu.CalisanID);
        //        var hizmet = await db.Hizmetler.FindAsync(randevu.HizmetID);

        //        if (musteri == null || calisan == null || hizmet == null)
        //        {
        //            ModelState.AddModelError("", "Geçersiz müşteri, çalışan veya hizmet.");
        //            return View(randevu);
        //        }

        //        // Randevuyu ekle
        //        db.Randevular.Add(randevu);
        //        await db.SaveChangesAsync();

        //        // Randevu başarıyla kaydedildi
        //        TempData["msj"] = "Randevunuz başarıyla kaydedildi.";
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // Model hatası varsa tekrar göster
        //    return View(randevu);
        //}
        //public async Task<IActionResult> RandevuList()
        //{
        //    var randevular = await db.Randevular
        //                            .Include(r => r.Musteri)  // Müşteri bilgilerini yükle
        //                            .Include(r => r.Calisan)  // Çalışan bilgilerini yükle
        //                            .Include(r => r.Hizmet)   // Hizmet bilgilerini yükle
        //                            .ToListAsync();

        //    return View(randevular);  // View'da randevuları gönder
        //}
        //[HttpPost]
        //public async Task<IActionResult> RandevuDurumGuncelle(int randevuId, string yeniDurum)
        //{
        //    var randevu = await db.Randevular.FindAsync(randevuId);

        //    if (randevu != null)
        //    {
        //        randevu.Durum = yeniDurum;
        //        await db.SaveChangesAsync();
        //        TempData["msj"] = "Randevu durumu başarıyla güncellendi.";
        //    }
        //    else
        //    {
        //        TempData["msj"] = "Randevu bulunamadı.";
        //    }

        //    return RedirectToAction("RandevuList");
        //}


    }
}
