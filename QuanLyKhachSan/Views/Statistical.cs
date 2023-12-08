using QuanLyKhachSan.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace QuanLyKhachSan.Views
{
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
        }

        private void Statistical_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetConnection();    //Kết nối csdl
            string sqlQuery = @"select b.CheckOutDate as 'Ngày',r.RoomType as 'Loại phòng',h.TotalPrice as 'Tổng tiền',r.Price as 'Giá phòng',b.PaymentStatus as 'Thanh toán' 
                                FROM dbo.BookingHistory as h inner join dbo.Reservation as b on h.ReservationId = b.ReservationId inner join dbo.Room as r on b.RoomId = r.RoomId";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);  //Tạo 1 truy vẫn và chuyển đổi dữ liệu
            DataTable dataTable = new DataTable();  //Tạo bảng lưu trữ dữ liệu đã truy vấn được 
            sqlDataAdapter.Fill(dataTable); //Thực hiện truy vấn và Điền dữ liệu vào bảng
           
            //Duyệt danh sách dữ liệu từ cột tổng tiền và tính tổng doanh thu
            decimal doanhThu = 0;
            decimal tienPhong = 0;
            decimal tienPhongUocTinh = 0;
            decimal doanhThuUocTinh = 0;
            int dangPhucVu = 0;
            int daPhucVu = 0;
            int phong3Sao = 0;
            int phong5Sao = 0;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                decimal tongTien = (decimal)dataTable.Rows[i]["Tổng tiền"];
                decimal giaPhong = (decimal)dataTable.Rows[i]["Giá phòng"];
                string thanhToan = (string)dataTable.Rows[i]["Thanh toán"];
                string loaiPhong = (string)dataTable.Rows[i]["Loại phòng"];

                if (thanhToan.Equals("Đã thanh toán"))
                {
                    daPhucVu++;
                    doanhThu += tongTien;
                    tienPhong += giaPhong;
                }
                else 
                { 
                     dangPhucVu++;              
                }

                if (loaiPhong.Equals("Phòng 3 sao"))
                {
                    phong3Sao++;
                } 
                else
                {
                    phong5Sao++;              
                }

                doanhThuUocTinh += tongTien;
                tienPhongUocTinh += giaPhong;
            }

            lbDoanhThuUocTinh.Text = doanhThuUocTinh.ToString();
            lbTienPhongUocTinh.Text = tienPhongUocTinh.ToString();
            lbChiPhiKhacUocTinh.Text = (doanhThuUocTinh-tienPhongUocTinh).ToString();
            lbDoanhThu.Text = doanhThu.ToString();
            lbTienPhong.Text = tienPhong.ToString();
            lbChiPhiKhac.Text = (doanhThu-tienPhong).ToString();
            lbSoPhong.Text = (phong3Sao+phong5Sao).ToString();
            lbDaPhucVu.Text = daPhucVu.ToString();
            lbDangPhucVu.Text = dangPhucVu.ToString();
            lbphong3sao.Text = phong3Sao.ToString();
            lbphong5sao.Text= phong5Sao.ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Statistical_Load(sender, e);
            viewDanhSach.Visible = false;
            viewND.Visible = true;
        }

        private void btnDanhSach_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Connection.GetConnection();    //Kết nối csdl
            string sqlQuery = @"select b.CheckOutDate as 'Ngày',r.RoomType as 'Loại phòng',h.TotalPrice as 'Tổng tiền',r.Price as 'Giá phòng',b.PaymentStatus as 'Thanh toán' 
                                FROM dbo.BookingHistory as h inner join dbo.Reservation as b on h.ReservationId = b.ReservationId inner join dbo.Room as r on b.RoomId = r.RoomId
                                where b.PaymentStatus = N'Đã thanh toán'";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlQuery, conn);  //Tạo 1 truy vẫn và chuyển đổi dữ liệu
            DataTable dataTable = new DataTable();  //Tạo bảng lưu trữ dữ liệu đã truy vấn được 
            sqlDataAdapter.Fill(dataTable); //Thực hiện truy vấn và Điền dữ liệu vào bảng
            dtgvDanhSachThongKe.DataSource = dataTable;
            viewDanhSach.Visible = true;
            viewND.Visible = false;
               
            decimal tongDoanhThu = 0;
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {                
                    tongDoanhThu = tongDoanhThu + (decimal)dataTable.Rows[i]["Tổng tiền"];      
            }
            lbDoanhThu1.Text = tongDoanhThu.ToString();
        }
    }
}
