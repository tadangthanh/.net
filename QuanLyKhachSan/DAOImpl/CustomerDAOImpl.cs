using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Mapper;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyKhachSan.DAOImpl
{
    internal class CustomerDAOImpl : Commons<Customer>, ICustomerDAO
    {
        CustomerMapper customerMapper = new CustomerMapper();
        public int delete(int id)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Delete from Customer where CustomerId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                command.Parameters.AddWithValue("@id", id);
                result = command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public List<Customer> findAll()
        {
            List<Customer> list = new List<Customer>();
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Customer";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(customerMapper.mappRow(reader));
                    }
                }
            }
            Connection.CloseConnection(sqlConn);
            return list;
        }

        public Customer findByCitizenIdNumber(string CCCD)
        {
            Customer customer = null;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Customer where CitizenIdNumber = @CitizenIdNumber";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, CCCD);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        customer = customerMapper.mappRow(reader);
                    }
                }
            }
            return customer;
        }

        public Customer findOne(int id)
        {
            Customer customer = null;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Customer where CustomerId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, customer.CitizenIdNumber);
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    if (reader.Read())
                    {
                        customer = customerMapper.mappRow(reader);
                    }
                }
            }
            return customer;
        }

        public int save(Customer customer)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "INSERT INTO Customer (CitizenIdNumber,Name, Address, PhoneNumber) OUTPUT INSERTED.CustomerId VALUES (@CitizenIdNumber,@fullName, @address, @numberPhone)";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, customer.CitizenIdNumber, customer.Name, customer.Address, customer.PhoneNumber);
                result = (int)command.ExecuteScalar();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public int update(Customer customer)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "UPDATE Customer set CitizenIdNumber = @cccd,Name = @Name, Address = @address, PhoneNumber = @phoneNumber where CustomerId= @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, customer.CitizenIdNumber, customer.Name, customer.Address, customer.PhoneNumber, customer.CustomerId);
                result = (int)command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public int updateByCitizenIdNumber(Customer customer)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "UPDATE Customer set Name = @Name, Address = @address, PhoneNumber = @phoneNumber where CitizenIdNumber = @cccd";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery,  customer.Name, customer.Address, customer.PhoneNumber, customer.CitizenIdNumber);
                result = (int)command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }
    }
}
