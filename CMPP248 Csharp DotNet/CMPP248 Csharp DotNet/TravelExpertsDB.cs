using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Summary description for Package
/// </summary>
/// 

namespace CMPP248_Csharp_DotNet
{
   public static class TravelExpertsDB
    {
        public static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=TravelExperts;Integrated Security=True";
                //"Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\TravelExperts_Data.MDF;" +
                //"Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
