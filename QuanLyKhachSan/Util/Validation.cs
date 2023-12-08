using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Util
{
    internal class Validation
    {
        // Sử dụng Dictionary để lưu trữ trạng thái lỗi của các TextBox
        private Dictionary<TextBox, bool> errorProviderForTextBox = new Dictionary<TextBox, bool>();

        // Phương thức để kiểm tra và xác thực dữ liệu nhập vào TextBox
        public bool validate(TextBox tb, TypeRegex typeRegex, ErrorProvider err)
        {
            // Kiểm tra kiểu dữ liệu cần kiểm tra
            if (typeRegex == TypeRegex.NumberPhone)
            {
                // Sử dụng biểu thức chính quy để kiểm tra số điện thoại
                if (!Regex.IsMatch(tb.Text, @"^\d{10}$") && tb.Text.Length > 0)
                {
                    // Hiển thị thông báo lỗi nếu số điện thoại không hợp lệ và TextBox không trống
                    err.SetError(tb, "Số không hợp lệ!");
                    errorProviderForTextBox[tb]=true;
                    return true; // Trả về true để biểu thị có lỗi
                }
                else
                {
                    // Đánh dấu TextBox không có lỗi và xóa thông báo lỗi (nếu có)
                    errorProviderForTextBox[tb] = false;
                    err.Clear();
                }
            }

            // Kiểm tra kiểu dữ liệu là Email
            if (typeRegex == TypeRegex.Email)
            {
                // Sử dụng biểu thức chính quy để kiểm tra định dạng email
                if (!Regex.IsMatch(tb.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$") && tb.Text.Length > 0)
                {
                    // Hiển thị thông báo lỗi nếu email không hợp lệ và TextBox không trống
                    err.SetError(tb, "Email không hợp lệ!");
                    errorProviderForTextBox[tb] = true;
                    return true;    // Trả về true để biểu thị có lỗi
                }
                else
                {
                    // Đánh dấu TextBox không có lỗi và xóa thông báo lỗi (nếu có)
                    errorProviderForTextBox[tb] = false;
                    err.Clear();
                }
            }

            // Kiểm tra kiểu dữ liệu là CCCD (Căn cước công dân)
            if (typeRegex == TypeRegex.CCCD)
            {
                // Sử dụng biểu thức chính quy để kiểm tra CCCD
                if (!Regex.IsMatch(tb.Text, @"^\d{12}$") )
                {
                    // Hiển thị thông báo lỗi nếu CCCD không hợp lệ
                    err.SetError(tb, "Căn cước không hợp lệ!");
                    errorProviderForTextBox[tb] = true;
                    return true;    // Trả về true để biểu thị có lỗi
                }
                else
                {
                    // Đánh dấu TextBox không có lỗi và xóa thông báo lỗi (nếu có)
                    errorProviderForTextBox[tb] = false;
                    err.Clear();
                }
            }

            // Kiểm tra kiểu dữ liệu là tên
            if (typeRegex == TypeRegex.Name)
            {
                // Sử dụng biểu thức chính quy để kiểm tra tên
                if (!Regex.IsMatch(tb.Text, @"[\p{L}]") && tb.Text.Length >0)
                {
                    // Hiển thị thông báo lỗi nếu tên không hợp lệ và TextBox không trống
                    err.SetError(tb, "Kí tự không hợp lệ!");
                    errorProviderForTextBox[tb] = true;
                    return true;    // Trả về true để biểu thị có lỗi
                }
                else
                {
                    // Đánh dấu TextBox không có lỗi và xóa thông báo lỗi (nếu có)
                    errorProviderForTextBox[tb] = false;
                    err.Clear();
                }
            }

            // Trả về false để biểu thị không có lỗi
            return false;
        }

        // Phương thức để kiểm tra xem có lỗi nào trong danh sách TextBox không
        public bool checkAll()
        {
            // Kiểm tra nếu có ít nhất một TextBox có lỗi thì trả về false, ngược lại trả về true
            if (errorProviderForTextBox.ContainsValue(true)) return false;
            return true;
        }

    }
}
