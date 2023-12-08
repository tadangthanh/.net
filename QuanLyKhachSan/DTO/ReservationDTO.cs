using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    internal class ReservationDTO
    {
        public string CustomerName { get; set; }
        public string RoomType { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PhoneNumber { get; set; }
    }
}
