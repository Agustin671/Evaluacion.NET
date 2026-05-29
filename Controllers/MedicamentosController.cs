using Farmacia.Data;
using Farmacia.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MySql.Data.MySqlClient;

namespace Farmacia.Controllers
{
    public class MedicamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Medicamentos> lista = ObtenerListaMedicamentos();
            return View(lista);
        }

        // Implementación de control de acceso (Autorización). 
        // Se verifica la existencia y validez del token de sesión antes de renderizar la vista.
        public IActionResult Admin()
        {
            if (HttpContext.Session.GetString("UsuarioAdmin") != "Activo")
            {
            // Si no hay sesión activa, se redirige al flujo de autenticación (Login).
                return RedirectToAction("Login", "Acceso");
            }

            List<Medicamentos> lista = ObtenerListaMedicamentos();
            return View(lista);
        }

        private List<Medicamentos> ObtenerListaMedicamentos()
        {
            List<Medicamentos> lista = new List<Medicamentos>();
             // Gestión automática de recursos con el bloque using para la conexión a MySQL.
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
                                // Manejo seguro de valores nulos (NULL) provenientes de la base de datos.
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
