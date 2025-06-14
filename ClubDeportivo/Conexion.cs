using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ClubDeportivo
{
    public static class Conexion
    {
        private static readonly string connectionString = "server=localhost;user=root;password=santi12;database=club_deportivo";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
