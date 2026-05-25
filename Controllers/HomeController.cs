using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }
    }
}