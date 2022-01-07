using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Shop.BackEnd.DataAccess
{
    //class that contains database connection
    class SqlServerConnection 
    {
        public static SqlConnection GetSqlConnection()
        {
            //connects to the database
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-PKFMPH7\SQLEXPRESS;Initial Catalog=OnlineStoreDb;Integrated Security=True");
            return connection;
        }  
    }
}
