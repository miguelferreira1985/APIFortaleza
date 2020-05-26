using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        static SqlConnection databaseConnection = null;

        public static SqlConnection GetDBConnection()
        {
            if (databaseConnection == null)
            {
                string connectionString = @"Server=MIGUELPC\SQLEXPRESS;Database=fortaleza_db;Trusted_Connection=True;";

                databaseConnection = new SqlConnection(connectionString);
            }

            return databaseConnection;
        }

        public static SqlConnection OpenDBConeccion()
        {
            var connectionStatus = GetDBConnection();

            if (connectionStatus.State == ConnectionState.Closed)
            {
                connectionStatus.Open();
            }

            return connectionStatus;
        }

        public static SqlConnection CloseDBConnection()
        {
            var connectionStatus = GetDBConnection();

            if (connectionStatus.State == ConnectionState.Open)
            {
                connectionStatus.Close();
            }

            return connectionStatus;
        }
    }
}
