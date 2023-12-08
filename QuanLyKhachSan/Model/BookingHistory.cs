using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    internal class BookingHistory
    {
        public int BookingHistoryId { get; set; }
        public Reservation Reservation { get; set; }
        public DateTime BookingTime { get; set; }
        public decimal TotalPrice { get; set; }
        public Customer Customer { get; set; }
    }
}
