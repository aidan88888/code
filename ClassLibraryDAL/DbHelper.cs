using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibraryDAL
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-EIQLF09;Initial Catalog=db_fyp;Integrated Security=True");
            return conn;
        }
    }
}
