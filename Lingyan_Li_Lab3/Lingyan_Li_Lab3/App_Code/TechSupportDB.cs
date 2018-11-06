using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Purpose: ASP.NET Lab3
//Author: Lindsay
//Date:July, 2018

namespace Lingyan_Li_Lab3
{    
    public static class TechSupportDB
    {
        public static SqlConnection GetConnection()
        {
            // get connection string from Web.config
            string connString = ConfigurationManager.ConnectionStrings["TechSupportConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            return conn;
        }
    }
}
