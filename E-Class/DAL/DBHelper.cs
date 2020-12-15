using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace E_Class.DAL
{
    public class DBHelper
    {

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["E-Class"].ToString());
        }

        public static void CloseConnection(SqlConnection objConn)
        {
            if (objConn.State != System.Data.ConnectionState.Open)
                objConn.Close();
            objConn.Dispose();
        }

    }
}