using QuanLyKhachSan.DAO;
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
    internal class ReservationDAOImpl : Commons<Reservation>, IReservationDAO
    {
        ReservationMapper reservationMapper = new ReservationMapper();
        public int delete(int id)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Delete from Reservation where ReservationId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                command.Parameters.AddWithValue("@id", id);
                result = command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public List<Reservation> findAll()
        {
            List<Reservation> list = new List<Reservation>();
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Reservation";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(reservationMapper.mappRow(reader));
                    }
                }
            }
            Connection.CloseConnection(sqlConn);
            return list;
        }

        public Reservation findOne(int id)
        {
            Reservation reservation = null;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Reservation where ReservationId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        reservation = reservationMapper.mappRow(reader);
                    }
                }
            }
            return reservation;
        }

        public int save(Reservation reservation)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "INSERT INTO Reservation (RoomId,CheckInDate, CheckOutDate, CustomerId,ContactInformation,PaymentStatus) OUTPUT INSERTED.ReservationId VALUES (@RoomId,@CheckInDate, @CheckOutDate, @CustomerId,@ContactInformation,@PaymentStatus)";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, reservation.Room.RoomId, reservation.CheckInDate, reservation.CheckOutDate, reservation.Customer.CustomerId, reservation.ContactInformation, reservation.PaymentStatus);
                result = (int)command.ExecuteScalar();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public int update(Reservation reservation)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Update Reservation set RoomId=@RoomId,CheckInDate = @checkindate,CheckOutDate=@Checkoutdate,CustomerId=@customerid,ContactInformation=@contactinfomation,PaymentStatus=@paymentsatus where ReservationId=@id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, reservation.Room.RoomId, reservation.CheckInDate, reservation.CheckOutDate, reservation.Customer.CustomerId, reservation.ContactInformation, reservation.PaymentStatus, reservation.ReservationId);
                result = (int)command.ExecuteScalar();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }
    }
}
