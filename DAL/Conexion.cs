using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Conexion
    {
        static SqlConnection databaseConnection = null;

        public static SqlConnection getDBConnection()
        {
            if (databaseConnection == null)
            {
                string connectionString = @"Server=FERREIRAPC\SQL;Database=fortaleza_db;Trusted_Connection=True;";

                databaseConnection = new SqlConnection(connectionString);
            }

            return databaseConnection;
        }

        public static SqlConnection openDBConeccion()
        {
            var connectionStatus = getDBConnection();

            if (connectionStatus.State == ConnectionState.Closed)
            {
                connectionStatus.Open();
            }

            return connectionStatus;
        }

        public static SqlConnection closeDBConnection()
        {
            var connectionStatus = getDBConnection();

            if (connectionStatus.State == ConnectionState.Open)
            {
                connectionStatus.Close();
            }

            return connectionStatus;
        }
    }
}
