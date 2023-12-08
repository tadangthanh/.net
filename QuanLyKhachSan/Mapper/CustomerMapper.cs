using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Mapper
{
    internal class CustomerMapper : RowMapper<Customer>
    {
        public Customer mappRow(SqlDataReader reader)
        {
            Customer customer = new Customer();
            customer.Address = reader.GetString(reader.GetOrdinal("Address"));
            customer.CitizenIdNumber = reader.GetString(reader.GetOrdinal("CitizenIdNumber"));
            customer.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
            customer.Name = reader.GetString(reader.GetOrdinal("Name"));
            customer.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            return customer;

        }
    }
}
