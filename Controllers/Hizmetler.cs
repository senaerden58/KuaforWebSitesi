using Microsoft.AspNetCore.Mvc;

namespace KuaforWebSitesi.Controllers
{
    public class Hizmetler : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
