using Quanlynhansu;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmDangnhap : Form
    {
        public FrmDangnhap()
        {
            InitializeComponent();
        }

        string connectString = "Data Source=Localhost;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void BtDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtDangnhap_Click(object sender, EventArgs e)
        {
            string username = TbTaikhoan.Text.Trim();
            string password = TbMatkhau.Text.Trim();

            // Kiểm tra xem tài khoản và mật khẩu có hợp lệ không
            if (IsValidCredentials(username, password))
            {
                // Lấy quyền của nhân viên từ cơ sở dữ liệu
                int quyen = GetNhanVienQuyen(username);

                // Kiểm tra quyền và mở Form tương ứng
                if (quyen == 4)
                {
                    // Mở Form Thongtinnhanvien
                    FrmMenu menu = new FrmMenu();
                    menu.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Mở Form Thongtinnhanvien
                    Thongtinnhanvien thongTinNhanVienForm = new Thongtinnhanvien();
                    thongTinNhanVienForm.ShowDialog();
                    this.Close();
                }

                // Đóng Form đăng nhập sau khi đăng nhập thành công
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu. Vui lòng thử lại!");
            }
        }

    

        private bool IsValidCredentials(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenDangNhap", username);
                cmd.Parameters.AddWithValue("@MatKhau", password);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }

        private int GetNhanVienQuyen(string taiKhoan)
        {
            using (SqlConnection conn = new SqlConnection(connectString))
            {
                conn.Open();

                // Truy vấn để lấy ID của nhân viên từ bảng TaiKhoan
                string queryNvId = "SELECT NvID FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                SqlCommand cmdNvId = new SqlCommand(queryNvId, conn);
                cmdNvId.Parameters.AddWithValue("@TenDangNhap", taiKhoan);
                object resultNvId = cmdNvId.ExecuteScalar();

                if (resultNvId != null)
                {
                    // Chuyển đổi kết quả sang kiểu dữ liệu int
                    int nvId = Convert.ToInt32(resultNvId);

                    // Truy vấn để lấy IDQuyen từ bảng Quyennv dựa trên ID nhân viên
                    string queryQuyen = "SELECT IDQuyen FROM Quyennv WHERE NvID = @NvID";
                    SqlCommand cmdQuyen = new SqlCommand(queryQuyen, conn);
                    cmdQuyen.Parameters.AddWithValue("@NvID", nvId);
                    object resultQuyen = cmdQuyen.ExecuteScalar();

                    // Nếu có kết quả từ truy vấn Quyennv, trả về IDQuyen, ngược lại trả về -1
                    return resultQuyen == null ? -1 : Convert.ToInt32(resultQuyen);
                }
                else
                {
                    // Trường hợp không tìm thấy ID nhân viên tương ứng với tên đăng nhập
                    return -1;
                }
            }
        }





        private void Tbten_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Tbten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '.')&&!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtDangnhap_Click(sender, e);
            }
        }

        private void TbMatkhau_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void TbMatkhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtDangnhap_Click(sender, e);
            }
        }

        private void FrmDangnhap_Load(object sender, EventArgs e)
        {
             
        }
    }
    }
    


