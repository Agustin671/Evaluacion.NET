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
            // Validación de credenciales de acceso
            if (usuario == "admin" && clave == "12345")
            {
                HttpContext.Session.SetString("UsuarioAdmin", "Activo");
           // Redirección HTTP hacia el controlador de Medicamentos, acción Admin.
                return RedirectToAction("Admin", "Medicamentos");
            }
           // Si falla la autenticación muestra el mensaje de error a la capa de presentación.
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
