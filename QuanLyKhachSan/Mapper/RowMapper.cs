using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Mapper
{
    internal interface RowMapper<T>
    {
        T mappRow(SqlDataReader reader);
    }
}
