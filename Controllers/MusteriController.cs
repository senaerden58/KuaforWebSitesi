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
        [HttpPost]
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


        public IActionResult MusteriGiris(string ad, string soyad, string sifre)
        {
           
            // Kullanıcı doğrulama işlemi
            var mevcutMusteri = musteriler.FirstOrDefault(m => m.MusteriAd == ad && m.MusteriSoyad == soyad && m.MusteriSifre == sifre);

            if (mevcutMusteri != null)
            {
                // Giriş başarılı ise ana sayfaya yönlendir
                TempData["msj"] = "Giriş başarılı!";
                return RedirectToAction("Index", "Home"); // Ana sayfaya yönlendirme
            }
            else
            {
                // Giriş bilgileri yanlışsa hata mesajı göster
                TempData["msj"] = "Giriş bilgileri yanlış. Lütfen tekrar deneyin.";
                return View();
            }
        }//calısmıyor





        public IActionResult MusteriList()
        {
            return View(musteriler);
        }
    }
}
