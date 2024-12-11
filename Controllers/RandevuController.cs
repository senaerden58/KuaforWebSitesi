using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;

namespace KuaforWebSitesi.Controllers
{
    public class RandevuController : Controller
    {
        //private readonly KuaforContext db;

        //public RandevuController(KuaforContext context)
        //{
        //    db = context;
        //}

        //[Authorize]
        //public IActionResult RandevuAl()
        //{
        //    // Giriş yapan kullanıcının ID'sini almak için User nesnesini kullanın
        //    var musteriIDClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    if (string.IsNullOrEmpty(musteriIDClaim))
        //    {
        //        return RedirectToAction("Login", "Account"); // Eğer kimlik doğrulama hatası varsa giriş sayfasına yönlendir
        //    }

        //    // Giriş yapan kullanıcı kimliğini int'e dönüştürün
        //    if (!int.TryParse(musteriIDClaim, out int musteriID))
        //    {
        //        return BadRequest("Geçersiz müşteri ID."); // Geçersiz ID durumu için hata yanıtı
        //    }

        //    // Kullanıcı veritabanında var mı kontrol edin
        //    var musteri = db.Musteriler.FirstOrDefault(m => m.MusteriID == musteriID);

        //    if (musteri == null)
        //    {
        //        return RedirectToAction("MusteriEkle", "Musteri"); // Eğer müşteri bulunamazsa yönlendir
        //    }

        //    // Randevu alma işlemleri burada yapılır
        //    return View(); // Randevu alma sayfası
        //}
    }
}
