using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shizzle.Data
{
    internal static class DatabaseConnectionProvider
    {
        private static MySqlConnection connection;
        public static MySqlConnection GetConnection()
        {
            if (connection == null)
                CreateConnection();

            return connection;
        }

        private static void CreateConnection()
        {
            //TODO: Get values from settings file
            CreateConnection("localhost", "shizzleRoot", "r00t", "shizzle");
        }

        private static void CreateConnection(string host, string username, string password, string database)
        {
            string cs = $"server={host};userid={username};password={password};database={database}";

            connection = new MySqlConnection(cs);
        }
    }
}
