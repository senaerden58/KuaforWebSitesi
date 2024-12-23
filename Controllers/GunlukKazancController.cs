using Microsoft.AspNetCore.Mvc;
using KuaforWebSitesi.Models;  // Model sınıfını kullanalım
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace KuaforWebSitesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GunlukKazancController : ControllerBase
    {


        private readonly KuaforDBContext db;

        public GunlukKazancController(KuaforDBContext context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult GunlukKazanc()
        {
            var calisanlar = db.Calisanlar.ToList();  // Veritabanındaki tüm çalışanlar

            var gunlukKazancListesi = calisanlar.Select(calisan =>
            {
                // Çalışanın yaptığı hizmetlerin toplam kazancını hesaplayalım
                var toplamKazanc = db.CalisanHizmetler
                    .Where(ch => ch.CalisanID == calisan.CalisanID)  // Çalışana bağlı hizmetler
                    .Join(db.Hizmetler, ch => ch.HizmetID, h => h.HizmetID, (ch, h) => h.Fiyat) // Hizmet fiyatını alıyoruz
                    .Sum(fiyat => fiyat);  // Toplam kazancı hesapla

                // Günlük kazanç hesaplanıyor ( iş günü varsayıyoruz)
                var gunlukKazanc = toplamKazanc / 28;

                return new
                {
                    CalisanID = calisan.CalisanID,
                    CalisanAd = calisan.CalisanAd,
                    CalisanSoyad = calisan.CalisanSoyad,
                    ToplamKazanc = toplamKazanc,
                    GunlukKazanc = gunlukKazanc
                };
            }).ToList();

            return Ok(gunlukKazancListesi);  // Hesaplanan verileri JSON olarak döndür
        }



    }
}

