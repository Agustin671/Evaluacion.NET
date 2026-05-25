using Farmacia.Data;
using Farmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Librería para leer sesiones
using MySql.Data.MySqlClient;

namespace Farmacia.Controllers
{
    public class MedicamentosController : Controller
    {
        // PÚBLICO
        public IActionResult Index()
        {
            List<Medicamentos> lista = ObtenerListaMedicamentos();
            return View(lista);
        }

        // PRIVADO (Revisa la sesión)
        public IActionResult Admin()
        {
            // Verificamos si la variable de sesión existe y dice "Activo"
            if (HttpContext.Session.GetString("UsuarioAdmin") != "Activo")
            {
                // Si no la tienes (porque cerraste la web y se borró), te manda al Login
                return RedirectToAction("Login", "Acceso");
            }

            List<Medicamentos> lista = ObtenerListaMedicamentos();
            return View(lista);
        }

        private List<Medicamentos> ObtenerListaMedicamentos()
        {
            List<Medicamentos> lista = new List<Medicamentos>();
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM medicamentos";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Medicamentos
                            {
                                id = reader.GetInt32("id"),
                                nombre = reader.GetString("nombre"),
                                descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader.GetString("descripcion"),
                                valor = reader.GetInt32("valor"),
                                cantidad = reader.GetInt32("cantidad"),
                                fechaCaducidad = reader.GetDateTime("fechacaducidad"),
                                fechaFabricacion = reader.GetDateTime("fechafabricacion"),
                                gramaje = reader.IsDBNull(reader.GetOrdinal("gramaje")) ? "" : reader.GetString("gramaje")
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}