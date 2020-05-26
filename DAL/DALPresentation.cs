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
    public class DALPresentation
    {
        public List<Presentation> dalGetActivePresentations()
        {
            DataTable dt = new DataTable();

            using (var command = new SqlCommand()) 
            {
                command.Connection = Connection.OpenDBConeccion();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spGetActivePresentations";

                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);

                Connection.CloseDBConnection();

                List<Presentation> presentationList = new List<Presentation>();

                foreach (DataRow row in dt.Rows)
                {
                    Presentation presentation = new Presentation();
                    presentation.PresentationID = Convert.ToInt32(row[0]);
                    presentation.Name = row[1].ToString();
                    presentation.Abbrevation = row[2].ToString();
                    presentation.Descripton = row[3].ToString();
                    presentation.IsActivated = Convert.ToBoolean(row[4]);

                    presentationList.Add(presentation);
                }

                return presentationList;
            }
        }
    }
}
