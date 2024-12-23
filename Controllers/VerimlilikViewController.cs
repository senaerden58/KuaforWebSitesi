using KuaforWebSitesi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace KuaforWebSitesi.Controllers
{
    public class VerimlilikViewController : Controller
    {
        private readonly HttpClient _httpClient;

        public VerimlilikViewController(HttpClient httpClient)
        {
            _httpClient = httpClient;  // HttpClient'ı constructor üzerinden alıyoruz.
        }

        public async Task<IActionResult> TumCalisanlarVerimlilik()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7035/api/Verimlilik");
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var sonucListesi = JsonConvert.DeserializeObject<List<CalisanVerimlilik>>(jsonData);  // CalisanVerimlilik modelini kullanıyoruz
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
