using QuanLyKhachSan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAO
{
    internal interface IBookingHistoryDAO
    {
        int save(BookingHistory customer);
        int delete(int id);
        int update(BookingHistory customer);
        BookingHistory findOne(int id);
        List<BookingHistory> findAll();
    }
}
