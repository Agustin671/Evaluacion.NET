using Farmacia.Data;
using Farmacia.Models;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Farmacia.Controllers
{
    public class CrearController : Controller
    {
        public ActionResult Index(Medicamentos medicamento)
        {
            if (!string.IsNullOrEmpty(medicamento.nombre))
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"INSERT INTO medicamentos
                            (nombre, descripcion, valor, cantidad, fechacaducidad, fechafabricacion, gramaje)
                            VALUES
                            (@nombre, @descripcion, @valor, @cantidad, @fechaCaducidad, @fechaFabricacion, @gramaje)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", medicamento.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", medicamento.descripcion ?? "");
                        cmd.Parameters.AddWithValue("@valor", medicamento.valor);
                        cmd.Parameters.AddWithValue("@cantidad", medicamento.cantidad);
                        cmd.Parameters.AddWithValue("@fechaCaducidad", medicamento.fechaCaducidad);
                        cmd.Parameters.AddWithValue("@fechaFabricacion", medicamento.fechaFabricacion);
                        cmd.Parameters.AddWithValue("@gramaje", medicamento.gramaje ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            return RedirectToAction("Crear");
        }

        public ActionResult Crear()
        {
            return View();
        }
        public ActionResult Editar(int id)
        {
            Medicamentos med = new Medicamentos();
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM medicamentos WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            med.id = reader.GetInt32("id");
                            med.nombre = reader.GetString("nombre");
                            med.descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader.GetString("descripcion");
                            med.valor = reader.GetInt32("valor");
                            med.cantidad = reader.GetInt32("cantidad");
                            med.fechaCaducidad = reader.GetDateTime("fechacaducidad");
                            med.fechaFabricacion = reader.GetDateTime("fechafabricacion");
                            med.gramaje = reader.IsDBNull(reader.GetOrdinal("gramaje")) ? "" : reader.GetString("gramaje");
                        }
                    }
                }
            }
            return View(med);
        }

        [HttpPost]
        public ActionResult Editar(Medicamentos medicamento)
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"UPDATE medicamentos SET 
                                    nombre = @nombre, 
                                    descripcion = @descripcion, 
                                    valor = @valor, 
                                    cantidad = @cantidad, 
                                    fechacaducidad = @fechaCaducidad, 
                                    fechafabricacion = @fechaFabricacion, 
                                    gramaje = @gramaje 
                                    WHERE id = @id";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", medicamento.id);
                        cmd.Parameters.AddWithValue("@nombre", medicamento.nombre);
                        cmd.Parameters.AddWithValue("@descripcion", medicamento.descripcion ?? "");
                        cmd.Parameters.AddWithValue("@valor", medicamento.valor);
                        cmd.Parameters.AddWithValue("@cantidad", medicamento.cantidad);
                        cmd.Parameters.AddWithValue("@fechaCaducidad", medicamento.fechaCaducidad);
                        cmd.Parameters.AddWithValue("@fechaFabricacion", medicamento.fechaFabricacion);
                        cmd.Parameters.AddWithValue("@gramaje", medicamento.gramaje ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Index", "Medicamentos");
            }
            catch
            {
                return View(medicamento);
            }
        }
        public ActionResult Eliminar(int id)
        {
            Medicamentos med = new Medicamentos();
            using (MySqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                string query = "SELECT * FROM medicamentos WHERE id = @id";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            med.id = reader.GetInt32("id");
                            med.nombre = reader.GetString("nombre");
                            med.descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? "" : reader.GetString("descripcion");
                            med.valor = reader.GetInt32("valor");
                            med.cantidad = reader.GetInt32("cantidad");
                            med.fechaCaducidad = reader.GetDateTime("fechacaducidad");
                            med.fechaFabricacion = reader.GetDateTime("fechafabricacion");
                            med.gramaje = reader.IsDBNull(reader.GetOrdinal("gramaje")) ? "" : reader.GetString("gramaje");
                        }
                    }
                }
            }
            return View(med);
        }

        [HttpPost]
        public ActionResult Eliminar(int id, IFormCollection collection)
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM medicamentos WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return RedirectToAction("Index", "Medicamentos");
            }
            catch
            {
                return View();
            }
        }
    }
}