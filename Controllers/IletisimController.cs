using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

//https://localhost:7035/api/Iletisim
namespace KuaforWebSitesi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IletisimController : ControllerBase
    {
        private readonly KuaforDBContext db;

        public IletisimController(KuaforDBContext context)
        {
            db = context;
        }

        // POST: api/iletisim
        [HttpPost]
        public async Task<IActionResult> MesajGonder([FromBody] Iletisim model)
        {
            // ModelState geçersizse, hatalı istek gönderildiğini belirtiyoruz
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // E-posta doğrulaması yapıyoruz
            if (!IsValidEmail(model.Eposta))
            {
                return BadRequest(new { message = "Geçersiz e-posta adresi." });
            }

            try
            {
                // Mesajı veritabanına ekliyoruz
                await db.Iletisimler.AddAsync(model);
                await db.SaveChangesAsync();

                // Başarılı işlem sonrası mesajı döndürüyoruz
                return Ok(new { message = "Mesajınız başarıyla alındı, teşekkür ederiz." });
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama yapıyoruz ve kullanıcıya uygun mesaj dönüyoruz
                Console.WriteLine($"Hata: {ex.Message}");
                return StatusCode(500, new { message = "Bir hata oluştu. Lütfen tekrar deneyin." });
            }
        }

        // E-posta geçerliliğini kontrol eden fonksiyon
        private bool IsValidEmail(string email)
        {
            // Basit bir e-posta regex kontrolü
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }

        [HttpGet]
        public IActionResult GetMesajlar()
        {
            try
            {
                var mesajlar = db.Iletisimler.ToList();  // Veritabanındaki tüm mesajları alıyoruz

                if (mesajlar == null || mesajlar.Count == 0)
                {
                    return NotFound(new { message = "Hiç mesaj bulunmamaktadır." });
                }

                return Ok(mesajlar);  // Mesajları geri döndürüyoruz
            }
            catch (Exception ex)
            {
                // Hata durumunda geri dönecek mesaj
                Console.WriteLine($"Hata: {ex.Message}");
                return StatusCode(500, new { message = "Mesajlar alınırken bir hata oluştu." });
            }
        }
    }
}

