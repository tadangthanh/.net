using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Mapper;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAOImpl
{
    internal class CustomDAOImpl : ICustomDAO<ReservationDTO>
    {
        public List<ReservationDTO> findAll()
        {
            ReservationDTOMapper reservationDTOMapper = new ReservationDTOMapper();
            List<ReservationDTO> list = new List<ReservationDTO>();
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = @"select c.Name,r.RoomType,v.CheckInDate,v.CheckOutDate,v.PaymentStatus,c.PhoneNumber FROM dbo.Customer as c inner join dbo.Reservation as v on c.CustomerId=v.CustomerId inner join dbo.Room as r on v.RoomId=r.RoomId where v.PaymentStatus like '%chưa thanh toán%';";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reservationDTOMapper.mappRow(reader));
                    }
                }
            }
            Connection.CloseConnection(sqlConn);
            return list;
        }
    }
}
