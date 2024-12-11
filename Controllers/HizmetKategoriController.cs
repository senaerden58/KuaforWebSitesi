using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuaforWebSitesi.Controllers
{
    public class HizmetKategoriController : Controller
    {

        private readonly KuaforDBContext db;

        public HizmetKategoriController(KuaforDBContext context)
        {
            db = context;
        }

        public IActionResult AddMultipleKategoriler()
        {
            try
            {
                // Kategorileri bir liste halinde tanımlayalım
                var kategoriler = new List<HizmetKategori>
        {
            new HizmetKategori { KategoriAdi = "Saç Bakımı" },
            new HizmetKategori { KategoriAdi = "Saç Şekillenidirme" },
            new HizmetKategori { KategoriAdi = "Gelin" },
            new HizmetKategori { KategoriAdi = "Manikür & Pedikür" },
            new HizmetKategori { KategoriAdi = "Cilt" }
        };

                // Veritabanına kategorileri ekliyoruz
                db.HizmetKategoriler.AddRange(kategoriler);
                db.SaveChanges();

                ViewBag.Message = "Kategoriler başarıyla eklendi!";
                return View(); // Yönlendirme
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Bir hata oluştu: " + ex.Message;
                return View(); // Yönlendirme
            }
        }


    }
}

