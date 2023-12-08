using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    internal interface IReservationDAO
    {
        int save(Reservation reservation);
        int delete(int id);
        int update(Reservation reservation);
        Reservation findOne(int id);
        List<Reservation> findAll();
    }
}
