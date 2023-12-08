using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.DAOImpl
{
    internal class Commons <T>
    {
        /// <summary>
        /// set giá trị cho các param trong câu sql
        /// </summary>
        /// <param name="command"></param>
        /// <param name="sqlQuery">câu lệnh sql</param>
        /// <param name="listParam">danh sách giá trị tham số</param>
        public void setParameter(SqlCommand command,string sqlQuery, params Object[] listParam )
        {
            MatchCollection matches = Regex.Matches(sqlQuery, @"@\w+");
            for(int i=0;i<matches.Count; i++)
            {
                command.Parameters.AddWithValue(matches[i].Value, listParam[i]);
            }
        }
        
    }
}