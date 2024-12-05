using Microsoft.AspNetCore.Mvc;

namespace KuaforWebSitesi.Controllers
{
    public class CalisanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
