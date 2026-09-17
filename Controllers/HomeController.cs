using Microsoft.AspNetCore.Mvc;

namespace TP02.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Creditos()
        {
            return View();
        }
    }
}