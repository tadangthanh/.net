using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Mapper
{
    internal class ReservationDTOMapper : RowMapper<ReservationDTO>
    {
        public ReservationDTO mappRow(SqlDataReader reader)
        {
            ReservationDTO reservationDTO = new ReservationDTO();
            reservationDTO.CheckInDate = reader.GetDateTime(reader.GetOrdinal("CheckInDate"));
            reservationDTO.CheckOutDate = reader.GetDateTime(reader.GetOrdinal("CheckOutDate"));
            reservationDTO.CustomerName = reader.GetString(reader.GetOrdinal("Name"));
            reservationDTO.RoomType = reader.GetString(reader.GetOrdinal("RoomType"));
            reservationDTO.PaymentStatus = reader.GetString(reader.GetOrdinal("PaymentStatus"));
            reservationDTO.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
            return reservationDTO;
        }
    }
}
