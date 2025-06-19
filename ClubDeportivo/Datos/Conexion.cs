using MySql.Data.MySqlClient;

namespace ClubDeportivo.Datos
{
    public class Conexion
    {
        private static string servidor = "";
        private static string puerto = "";
        private static string usuario = "";
        private static string clave = "";
        private static string baseDatos = "";

        public static void Configurar(string _servidor, string _puerto, string _usuario, string _clave, string _baseDatos)
        {
            servidor = _servidor;
            puerto = _puerto;
            usuario = _usuario;
            clave = _clave;
            baseDatos = _baseDatos;
        }

        public static MySqlConnection GetConnection()
        {
            string connectionString = $"server={servidor};port={puerto};user={usuario};password={clave};database={baseDatos}";
            return new MySqlConnection(connectionString);
        }
    }
}
