using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    internal class Reservation
    {
        public int ReservationId { get; set; }
        public Room Room { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public Customer Customer { get; set; }
        public string ContactInformation { get; set; }
        public string PaymentStatus { get; set; }
    }
}
