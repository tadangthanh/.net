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
    internal class RoomDAOImpl : Commons<Room>, IRoomDAO
    {
        RoomMapper roomMapper = new RoomMapper();
        public int delete(int id)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Delete from Room where RoomId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                command.Parameters.AddWithValue("@id", id);
                result = command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public List<Room> findAll()
        {
            List<Room> list = new List<Room>();
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Room";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(roomMapper.mappRow(reader));
                    }
                }
            }
            Connection.CloseConnection(sqlConn);
            return list;
        }

        public Room findOne(int id)
        {
            Room room = null;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "Select * from Room where RoomId = @id";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        room = roomMapper.mappRow(reader);
                    }
                }
            }
            return room;
        }

        public int save(Room room)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "INSERT INTO Room (RoomType,Price,Status,RoomNumber,Description) OUTPUT INSERTED.RoomId VALUES (@RoomType,@Price, @Status, @RoomNumber,@Description)";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, room.RoomType, room.Price, room.Status, room.RoomNumber, room.Desc);
                result = (int)command.ExecuteScalar();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }

        public int update(Room room)
        {
            int result = 0;
            SqlConnection sqlConn = Connection.GetConnection();
            string sqlQuery = "UPDATE Room set RoomType = @RoomType,Price = @Price, Status = @Status, RoomNumber = @RoomNumber,Description=@Description where RoomId= @RoomId";
            using (SqlCommand command = new SqlCommand(sqlQuery, sqlConn))
            {
                setParameter(command, sqlQuery, room.RoomType, room.Price, room.Status, room.RoomNumber, room.Desc, room.RoomId);
                result = (int)command.ExecuteNonQuery();
            }
            Connection.CloseConnection(sqlConn);
            return result;
        }
    }
}
