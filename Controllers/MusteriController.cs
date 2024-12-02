using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuaforWebSitesi.Controllers
{
    public class MusteriController : Controller
    {
        static List<Musteri> musteriler = new List<Musteri>();
        public IActionResult MusteriEkle()
        {
            return View();
        }
        public IActionResult MusteriKaydet(Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemi
                musteriler.Add(musteri);
                TempData["msj"] = musteri.MusteriAd + " adlı musteri Kaydedildi";
                return RedirectToAction("MusteriList");

            }
            TempData["msj"] = "Kayıt İşlemi Başarısız";
            return RedirectToAction("MusteriEkle");
            //Hata işlemi
        }

        public IActionResult MusteriList()
        {
            return View(musteriler);
        }
    }
}
