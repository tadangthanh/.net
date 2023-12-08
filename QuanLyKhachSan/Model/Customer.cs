using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.Model
{
    internal class Customer
    {
        // căn cước công dân
        public string CitizenIdNumber { get; set; }
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
