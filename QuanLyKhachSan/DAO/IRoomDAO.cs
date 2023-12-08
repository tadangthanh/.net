using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    internal interface IRoomDAO
    {
        int save(Room room);
        int delete(int id);
        int update(Room room);
        Room findOne(int id);
        List<Room> findAll();
    }
}
