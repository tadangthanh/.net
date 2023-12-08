using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Util
{
    internal class Connection
    {
        private static readonly SqlConnection conn;

            //Kết nối của thành 
        //private static readonly string strCon = @"Data Source=DESKTOP-CR5N4N8\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

            //Kết nối của triệu 
        //private static readonly string strCon = @"Data Source=TrieuChinh\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        //Database trong project
        private static readonly string strCon = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""G:\Drive của tôi\Lập trình .NET\BaiTapLon .Net\QuanLyKhachSan\Database1.mdf"";Integrated Security=True";


        static Connection()
        {
            conn = new SqlConnection(strCon);
        }

        public static SqlConnection GetConnection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public static void CloseConnection(SqlConnection sqlConn)
        {
            if(sqlConn != null)
            {
                conn.Close();
            }
        }
    }
}
