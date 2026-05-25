using MySql.Data.MySqlClient;

namespace Farmacia.Data
{
    public class Conexion
    {
        public static MySqlConnection ObtenerConexion()
        {
            string cadena = "server=localhost;database=farmacia;uid=root;pwd=0980;";

            return new MySqlConnection(cadena);
        }
    }
}