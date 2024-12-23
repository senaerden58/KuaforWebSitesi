using Microsoft.AspNetCore.Mvc;
using KuaforWebSitesi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace KuaforWebSitesi.Controllers
{
    public class GunlukKazancViewController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly KuaforDBContext db;
        public GunlukKazancViewController(HttpClient httpClient)
        {
            _httpClient = httpClient;  // HttpClient'ı constructor üzerinden alıyoruz.
        }
        public async Task<IActionResult> GunlukKazanc()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7035/api/GunlukKazanc");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var sonucListesi = JsonConvert.DeserializeObject<List<GunlukKazancViewModel>>(jsonData);  // CalisanVerimlilik modelini kullanıyoruz
                    return View(sonucListesi);  // Verileri view'e gönderiyoruz
                }
                return View("Error");
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }




    }
}
