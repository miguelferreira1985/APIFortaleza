using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

namespace DAL
{
    public class DALUser
    {
        public  User dalValidateUser(User user)
        {
            User userAuthenticated = new User();

            using (var command = new SqlCommand())
            {
                command.Connection = Connection.OpenDBConeccion();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spValidateUser";

                command.Parameters.AddWithValue("@userName", user.UserName);
                command.Parameters.AddWithValue("@userPassword", user.UserPassword);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    userAuthenticated.UserName = reader.GetString(0);
                    userAuthenticated.UserRoles = reader.GetString(1);
                }
                else
                {
                    userAuthenticated = null;
                }

                Connection.CloseDBConnection();

                return userAuthenticated;
            }
        }
    }
}
