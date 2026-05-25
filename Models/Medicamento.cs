using System;

namespace Farmacia.Models
{
    public class Medicamentos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; } 
        public int valor { get; set; }
        public int cantidad { get; set; }
        public DateTime fechaCaducidad { get; set; } 
        public DateTime fechaFabricacion { get; set; }
        public string gramaje { get; set; } 

        public Medicamentos(int id, string nombre, string descripcion, int valor, int cantidad, DateTime fechaCaducidad, DateTime fechaFabricacion, string gramaje)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.valor = valor;
            this.cantidad = cantidad;
            this.fechaCaducidad = fechaCaducidad;
            this.fechaFabricacion = fechaFabricacion;
            this.gramaje = gramaje;
        }

        public Medicamentos()
        {
        }
    }
}