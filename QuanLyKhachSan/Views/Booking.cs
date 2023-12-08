using QuanLyKhachSan.DAO;
using QuanLyKhachSan.DAOImpl;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.Model;
using QuanLyKhachSan.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyKhachSan.Views
{
    public partial class Booking : Form
    {

        ICustomerDAO customerDao = new CustomerDAOImpl();
        IReservationDAO reservationDao = new ReservationDAOImpl();
        IBookingHistoryDAO bookingHistoryDAO = new BookingHistoryDAOImpl();
        IRoomDAO roomDao = new RoomDAOImpl();
        ICustomDAO<ReservationDTO> customDao = new CustomDAOImpl();

        private BindingList<String> roomType = new BindingList<String>();

        // danh sách khách đặt phòng
        private BindingList<ReservationDTO> reservations;
        private Validation validation = new Validation();

        //phòng khách đặt
        private Room roomBooking;
        public Booking()
        {
            InitializeComponent();
            init();
            dtgListReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HandlerCommon();
        }
        private void init()
        {
            // danh sách các loại phòng 
            /*List<Room> rooms = roomDao.findAll();
            BindingList<Room> roomList = new BindingList<Room>(rooms);*/
            roomType.Add("phòng 3 sao");
            roomType.Add("phòng 5 sao");
            cbbTypeRoom.DataSource = roomType;
        }
        private void HandlerCommon()
        {
            dtgListReservation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dpCheckIn.Value = DateTime.Now;
            txtSearchReservation.GotFocus += new EventHandler(textBox_GotFocus);
            void textBox_GotFocus(object sender, EventArgs e)
            {
                txtSearchReservation.Text = "";
            }
            reservations = new BindingList<ReservationDTO>(customDao.findAll());
            dtgListReservation.DataSource = reservations;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbUrlImg_Click(object sender, EventArgs e)
        {

        }

        //----------------- Sự kiện khi chọn loại phòng ---------------
        private void cbbTypeRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Room> rooms = roomDao.findAll();
            BindingList<Room> roomList = new BindingList<Room>(rooms);
            string selectedRoomType = cbbTypeRoom.SelectedItem as string;

            if (selectedRoomType != null)
            {
                foreach (Room room in roomList)
                {
                    if (room.RoomType.Equals(selectedRoomType))
                    {
                        roomBooking = room;
                        break;
                    }
                }

                if (roomBooking != null)
                {
                    //cbbRoomNumber.Text = string.Empty;
                    lbPrice.Text = roomBooking.Price.ToString();
                    txtDesc.Text = roomBooking.Desc.ToString();
                    lbStatus.Text = roomBooking.Status.ToString();
                    lbStatus.Text = roomBooking.Status.ToString();
                }
            }
        }

        //------------- Sự kiện chọn số phòng ---------------
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private Customer textToCustomer()
        {
            Customer customer = new Customer();
            string fullName = txtFullName.Text;
            string numberPhone = txtNumberPhone.Text;
            string address = txtAddress.Text;
            string cccd = txtCCCD.Text;
            customer.CitizenIdNumber = cccd;
            customer.Name = fullName;
            customer.Address = address;
            customer.PhoneNumber = numberPhone;
            return customer;
        }
        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            Customer customer = textToCustomer();
            Reservation reservation = new Reservation();
            BookingHistory bookingHistory = new BookingHistory();
            reservation.CheckInDate = DateTime.Now;
            reservation.CheckOutDate = dpCheckout.Value;
            reservation.Customer = customer;
            reservation.ContactInformation = customer.PhoneNumber;
            reservation.PaymentStatus = "Chưa thanh toán";
            reservation.Room = roomBooking;
            int insertedCustomerId = 0;
            int insertedReservationId = 0;
            // dialog xác nhận lại thông tin khách hàng
            string msg = "Họ tên khách hàng: " + customer.Name + "\n" + "Căn Cước công dân: " + customer.CitizenIdNumber + "\n"
                + "Địa chỉ :" + customer.Address + "\n"
                + "Số điện thoại: " + customer.PhoneNumber + "\n"
                + "Ngày nhận phòng: " + reservation.CheckInDate + "\n"
                + "Ngày trả phòng(dự kiến): " + reservation.CheckOutDate;
            DialogResult reconfirm = MessageBox.Show(msg, "Kiểm tra lại thông tin", MessageBoxButtons.YesNo);

            if (reconfirm == DialogResult.Yes && txtCCCD.Text.Length == 12)
            {
                // check nếu khách hàng tồn tại thì dùng luôn dữ liệu cũ của khách hàng
                if (!string.IsNullOrEmpty(lbCustomerId.Text))
                {
                    insertedCustomerId = int.Parse(lbCustomerId.Text);
                    customerDao.updateByCitizenIdNumber(customer);
                }
                else
                {   // thêm dữ liệu vào bảng customer
                    try
                    {
                        insertedCustomerId = customerDao.save(customer);
                        customer.CustomerId = insertedCustomerId;
                    }
                    catch { }

                }
                // thêm dữ liệu vào bảng đặt phòng (Reservation)
                reservation.Customer.CustomerId = insertedCustomerId;
                insertedReservationId = reservationDao.save(reservation);
                reservation.ReservationId = insertedReservationId;
                bookingHistory.Reservation = reservation;
                bookingHistory.Customer = customer;
                bookingHistory.TotalPrice = roomBooking.Price;
                bookingHistory.BookingTime = DateTime.Now;
                if (bookingHistoryDAO.save(bookingHistory) > 0)
                {
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ReservationDTO reservationDTO = new ReservationDTO();
                    reservationDTO.CheckInDate = reservation.CheckInDate;
                    reservationDTO.CheckOutDate = reservation.CheckOutDate;
                    reservationDTO.PhoneNumber = customer.PhoneNumber;
                    reservationDTO.CustomerName = customer.Name;
                    reservationDTO.PaymentStatus = reservation.PaymentStatus;
                    reservationDTO.RoomType = roomBooking.RoomType;
                    reservations.Add(reservationDTO);
                    dtgListReservation.DataSource = reservations;
                    btnDatPhong.Enabled = false;
                    sorting();
                    clearValueTextBox();
                }
            }

        }

        public void clearValueTextBox()
        {
            txtAddress.Text = "";
            txtCCCD.Text = "";
            txtFullName.Text = "";
            txtNumberPhone.Text = "";
            lbCustomerId.Text = "";
        }

        private void setTextFromCustomer(Customer c)
        {
                txtAddress.Text = c.Address;
                txtCCCD.Text = c.CitizenIdNumber;
                txtFullName.Text = c.Name;
                txtNumberPhone.Text = c.PhoneNumber;
        }

        //load dữ liệu cũ vào textbox nếu khách hàng tồn tại
        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text;
            validation.validate(txtCCCD, TypeRegex.CCCD, errCCCD);
            if (cccd.Length > 11)
            {
                btnDatPhong.Enabled = validation.checkAll() && !validation.validate(txtCCCD, TypeRegex.CCCD, errCCCD) ? true : false;
                try
                {
                    Customer c = customerDao.findByCitizenIdNumber(cccd);
                    if(c != null)
                    {
                        MessageBox.Show("Đã có dữ liệu của khách hàng cũ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lbCustomerId.Text = c.CustomerId.ToString();
                        setTextFromCustomer(c);
                    }
                }
                catch
                {

                }
            }
        }

        private void dpCheckout_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelected = dpCheckout.Value;
            if (dateSelected < DateTime.Now)
            {
                MessageBox.Show("Thời gian trả phòng không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dpCheckout.Value = DateTime.Now;
            }
        }

        //--------Phương thức sắp xếp----------
        private void sorting()
        {
            string sortingSelected = cbbSortReservation.SelectedItem as string;
            if (sortingSelected != null)
            {
                if (sortingSelected.Equals("Tên khách hàng"))
                {
                    var sortedReservations = new BindingList<ReservationDTO>(reservations.OrderBy(r => r.CustomerName).ToList());
                    reservations = sortedReservations;
                    dtgListReservation.DataSource = reservations;
                }
            }


        }

        //----------Sự kiện khi giá trị sắp xếp thay đổi -------------
        private void cbbSortReservation_SelectedIndexChanged(object sender, EventArgs e)
        {
            sorting();
        }

        //------------Phương thức tìm kiếm khách hàng-------------
        private void txtSearchReservation_TextChanged(object sender, EventArgs e)
        {          
            SqlConnection conn = Connection.GetConnection();
            string keyword = txtSearchReservation.Text.Trim();
            string sqlQuery = @"select c.Name ,r.RoomType ,v.CheckInDate ,v.CheckOutDate ,v.PaymentStatus ,c.PhoneNumber 
                                FROM dbo.Customer as c inner join dbo.Reservation as v on c.CustomerId=v.CustomerId inner join dbo.Room as r on v.RoomId=r.RoomId 
                                where c.Name like @Name";
            using (SqlCommand command = new SqlCommand(sqlQuery, conn))
            {
                reservations.Clear();
                if (!string.IsNullOrEmpty(keyword))
                {
                    command.Parameters.AddWithValue("@Name", "%" + keyword + "%");
                }
                else
                {
                    command.Parameters.AddWithValue("@Name", "%%");
                }
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReservationDTO reservationDTO = new ReservationDTO();
                        reservationDTO.CheckInDate = reader.GetDateTime(reader.GetOrdinal("CheckInDate"));
                        reservationDTO.CheckOutDate = reader.GetDateTime(reader.GetOrdinal("CheckOutDate"));
                        reservationDTO.CustomerName = reader.GetString(reader.GetOrdinal("Name"));
                        reservationDTO.RoomType = reader.GetString(reader.GetOrdinal("RoomType"));
                        reservationDTO.PaymentStatus = reader.GetString(reader.GetOrdinal("PaymentStatus"));
                        reservationDTO.PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"));
                        reservations.Add(reservationDTO);
                    }
                }

                dtgListReservation.DataSource = reservations;
                sorting();
            }
            Connection.CloseConnection(conn);
        }

        //Phương thức hiển thị lịch sử đặt phòng
        private void lịchSửĐặtPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox3.Text = "Lịch sử đặt phòng";   //setText cho bảng
            SqlConnection conn = Connection.GetConnection();    //Kết nối csdl
            string sqlQuery = @"select c.Name as 'Họ và Tên',b.CheckInDate as 'Ngày đặt phòng',b.CheckOutDate as 'Ngày trả phòng',r.RoomType as 'Loại phòng',b.PaymentStatus as 'Thanh thoán',h.TotalPrice as 'Tổng tiền' 
                                FROM dbo.BookingHistory as h inner join dbo.Customer as c on h.CustomerId = c.CustomerId inner join dbo.Reservation as b on c.CustomerId = b.CustomerId inner join dbo.Room as r on b.RoomId = r.RoomId;";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery,conn);  //Tạo 1 truy vẫn và chuyển đổi dữ liệu
            DataTable dataTable = new DataTable();  //Tạo bảng lưu trữ dữ liệu đã truy vấn được 
            sqlDataAdapter.Fill(dataTable); //Thực hiện truy vấn và Điền dữ liệu vào bảng
            dtgListReservation.DataSource = dataTable;  //Lấy dữ liệu từ bảng hiển thị lên giao diện
        }

        //Kiểm tra địng dạng số điện thoại
        private void txtNumberPhone_TextChanged(object sender, EventArgs e)
        {
            validation.validate(txtNumberPhone, TypeRegex.NumberPhone, errNumberPhone);
            btnDatPhong.Enabled = validation.checkAll() && txtCCCD.Text.Length == 12 ? true : false;
        }
        
        //Kiểm tra định dạng CCCD
        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            btnDatPhong.Enabled = validation.checkAll() && txtCCCD.Text.Length == 12 ? true : false;
            validation.validate(txtFullName, TypeRegex.Name, errName);
        }


        //Menu danh sách khách hàng
        private void btnListCustomer_Click(object sender, EventArgs e)
        {
            groupBox3.Text = "Danh sách khách hàng";
        }

        //Menu danh sách đặt phòng
        private void btnListBooking_Click(object sender, EventArgs e)
        {
            groupBox3.Text = "Danh sách đặt phòng";
        }

        //Hiển thị giao diện khi chạy form
        private void Booking_Load(object sender, EventArgs e)
        {
            txtSearchReservation_TextChanged(sender, e);          
        }

        //Hiển thị giao diện thống kê
        private void báoCáoThốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Statistical statistical = new Statistical();
            statistical.Show();
        }

        //Hiển thị giao diện thanh toán
        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pay pay = new Pay();
            pay.Show();
        }

    }
}
