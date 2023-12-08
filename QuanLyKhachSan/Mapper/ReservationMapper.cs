using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Mapper
{
    internal class ReservationMapper : RowMapper<Reservation>
    {
        public Reservation mappRow(SqlDataReader reader)
        {
            Reservation reservation = new Reservation();
            reservation.ReservationId = reader.GetInt32(reader.GetOrdinal("ReservationId"));
            reservation.CheckOutDate = reader.GetDateTime(reader.GetOrdinal("CheckOutDate"));
            reservation.CheckInDate = reader.GetDateTime(reader.GetOrdinal("CheckInDate"));
            reservation.ContactInformation = reader.GetString(reader.GetOrdinal("ContactInformation"));
            reservation.PaymentStatus = reader.GetString(reader.GetOrdinal("PaymentStatus"));
            return reservation;
        }
    }
}
