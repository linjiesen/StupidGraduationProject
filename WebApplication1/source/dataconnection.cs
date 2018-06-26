using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WebApplication1
{
    class dataconnection
    {
        public static string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\用户目录\我的文档\Visual Studio 2017\Automatic-exam\WebApplication1\WebApplication1\App_Data\examination.mdf;Integrated Security = True";

        public static SqlConnection conn = new SqlConnection(dataconnection.str);
        public static SqlConnection get_connection()
        {
            return dataconnection.conn;
        }
    }
}
