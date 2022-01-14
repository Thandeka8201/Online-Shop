using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBackEnd.DataAccess
{
    //class that contains database connection
    class SqlServerConnection
    {
            public static SqlConnection GetSqlConnection()
            {
                //connects to the database
                SqlConnection connection = new SqlConnection(@"Data Source=WANKIS-LAPTOP\SQLEXPRESS01;Initial Catalog=OnlineStoreDb;Integrated Security=True");
                return connection;
            }
    }
}
