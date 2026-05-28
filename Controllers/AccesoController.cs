using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Farmacia.Controllers
{
    public class AccesoController : Controller
    {

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string clave)
        {
            if (usuario == "admin" && clave == "12345")
            {
                HttpContext.Session.SetString("UsuarioAdmin", "Activo");

                return RedirectToAction("Admin", "Medicamentos");
            }

            ViewBag.Error = "Datos incorrectos, intenta de nuevo.";
            return View();
        }
                public IActionResult Salir()
        {
            HttpContext.Session.Remove("UsuarioAdmin");

            return RedirectToAction("Index", "Home");
        }
    }
}
