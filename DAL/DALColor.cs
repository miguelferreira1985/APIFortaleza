using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALColor
    {
        public List<Color> dalGetActiveColors()
        {
            DataTable dt = new DataTable();

            using (var command = new SqlCommand())
            {
                command.Connection = Connection.OpenDBConeccion();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetActiveColors";

                SqlDataAdapter daColor= new SqlDataAdapter(command);
                daColor.Fill(dt);

                Connection.CloseDBConnection();

                List<Color> colorList = new List<Color>();

                foreach (DataRow row in dt.Rows)
                {
                    Color color = new Color();
                    color.ColorID = Convert.ToInt32(row[0]);
                    color.Name = row[1].ToString();
                    color.CreatedDate = Convert.ToDateTime(row[2]);
                    color.ModifiedDate = Convert.ToDateTime(row[3]);
                    color.IsActivated = Convert.ToBoolean(row[4]);


                    colorList.Add(color);
                }

                return colorList;
            }
        }

        public bool dalUpdateColor(Color color)
        {
            using ( var command = new SqlCommand())
            {
                command.Connection = Connection.OpenDBConeccion();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spUpdateColor";
                command.Parameters.AddWithValue("@colorId", color.ColorID);
                command.Parameters.AddWithValue("@name", color.Name);

                int result = command.ExecuteNonQuery();

                Connection.CloseDBConnection();

                if ( result > 0 )
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool dalDeleteColor(int id)
        {
            using (var command = new SqlCommand())
            {
                command.Connection = Connection.OpenDBConeccion();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spDeleteColor";
                command.Parameters.AddWithValue("@colorId", id);

                int result = command.ExecuteNonQuery();

                Connection.CloseDBConnection();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
