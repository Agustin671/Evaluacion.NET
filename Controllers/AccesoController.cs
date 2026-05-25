using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Librería para usar sesiones

namespace Farmacia.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Muestra el Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Revisa la clave
        [HttpPost]
        public IActionResult Login(string usuario, string clave)
        {
            if (usuario == "admin" && clave == "12345")
            {
                // Guardamos una Variable de Sesión. Esta no se borra al cambiar de página.
                HttpContext.Session.SetString("UsuarioAdmin", "Activo");

                return RedirectToAction("Admin", "Medicamentos");
            }

            ViewBag.Error = "Datos incorrectos, intenta de nuevo.";
            return View();
        }
    }
}