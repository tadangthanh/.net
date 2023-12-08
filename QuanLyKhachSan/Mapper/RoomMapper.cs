using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Mapper
{
    internal class RoomMapper : RowMapper<Room>
    {
        public Room mappRow(SqlDataReader reader)
        {
            Room room = new Room();
            room.RoomId = reader.GetInt32(reader.GetOrdinal("RoomId"));
            room.RoomType = reader.GetString(reader.GetOrdinal("RoomType"));
            room.Price = reader.GetDecimal(reader.GetOrdinal("Price"));
            room.Status = reader.GetString(reader.GetOrdinal("Status"));
            room.RoomNumber = reader.GetInt32(reader.GetOrdinal("RoomNumber"));
            room.Desc = reader.GetString(reader.GetOrdinal("Description"));

            return room;
        }
    }
}
