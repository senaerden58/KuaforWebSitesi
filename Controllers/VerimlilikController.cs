using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KuaforWebSitesi.Controllers
{

    namespace KuaforWebSitesi.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class VerimlilikController : Controller
        {
            private readonly KuaforDBContext db;

            public VerimlilikController(KuaforDBContext context)
            {
                db = context;
            }


            [HttpGet("{calisanId}/verimlilik")]
            public async Task<IActionResult> GetVerimlilik(int calisanId, DateTime tarih)
            {
                // Çalışanın yaptığı randevuları ve ilişkili hizmetleri al
                var calisanRandevular = await db.Randevular
                    .Where(r => r.CalisanID == calisanId && r.Tarih.Date == tarih.Date)
                    .Include(r => r.Hizmetler) // Tek bir Hizmet özelliğini dahil et
                    .ToListAsync();

                // Gerçek Kazanç Hesaplama
                double toplamKazanc = calisanRandevular
                    .Where(r => r.Hizmetler != null) // Hizmet null kontrolü
                    .Sum(r => (double)r.Hizmetler.Fiyat); // Hizmetlerin fiyatlarını topla

                // Hedef Kazanç Hesaplama
                var hizmetAdedi = calisanRandevular.Count; // Randevu sayısı hizmet adediyle eşittir

                double hedefKazanc = hizmetAdedi * 125; // Örneğin her hizmet için ortalama fiyat: 125 TL

                // Verimlilik Hesaplama
                double verimlilikOrani = hedefKazanc > 0 ? (toplamKazanc / hedefKazanc) * 100 : 0;

                var result = new
                {
                    CalisanAd = "Ahmet", // Çalışanın adı veritabanından alınabilir
                    Tarih = tarih.ToString("yyyy-MM-dd"),
                    ToplamKazanc = toplamKazanc,
                    ToplamHizmetAdedi = hizmetAdedi,
                    VerimlilikOrani = verimlilikOrani
                };

                return Ok(result);
            }




            public IActionResult Index()
            {
                return View();
            }
        }
    }
}
