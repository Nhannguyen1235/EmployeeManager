using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Quanlynhansu
{
    public partial class Thongtinnhanvien : Form
    {
        public Thongtinnhanvien()
        {
            InitializeComponent();
        }

        string connectString = "Data Source=Localhost;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";


        private void LoadEmployeeNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT NvID, CONCAT(Hodem, ' ', Ten) AS HoTen FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        string hoTen = reader["HoTen"].ToString();
                        CbbTennv.Items.Add(new KeyValuePair<string, string>(nvId, hoTen));
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadEmployeeIds()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT NvID FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        CbbTennv.Items.Add(nvId);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = @"
                  SELECT NhanVien.*, PhongBan.Tenpb, Hopdong.Kieuhopdong, BangLuong.ThoiGian, BangLuong.Luongcoban, BangLuong.Phucap
                  FROM NhanVien
                  LEFT JOIN PhongBan ON NhanVien.PbID = PhongBan.PbID
                  LEFT JOIN Hopdong ON NhanVien.HdID = Hopdong.HdID
                  LEFT JOIN BangLuong ON NhanVien.NvID = BangLuong.NvID
                  WHERE NhanVien.NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", txtIdnv.Text.Trim()); // Giả sử txtIdnv chứa EmployeeID bạn muốn lấy
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtEmailnv.Text = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                        txthodem.Text = reader["Hodem"] != DBNull.Value ? reader["Hodem"].ToString() : "";
                        txtTen.Text = reader["Ten"] != DBNull.Value ? reader["Ten"].ToString() : "";
                        txtSdtnv.Text = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : "";
                        txtChucvunv.Text = reader["Chucvu"] != DBNull.Value ? reader["Chucvu"].ToString() : "";
                        txtDiachinv.Text = reader["Diachi"] != DBNull.Value ? reader["Diachi"].ToString() : "";
                        txtIDhopdong.Text = reader["HdID"] != DBNull.Value ? reader["HdID"].ToString() : "";
                        DateTime Ngaysinh = reader["Ngaysinh"] != DBNull.Value ? Convert.ToDateTime(reader["Ngaysinh"]) : DateTime.MinValue;
                        dtpNgaysinhnv.Value = Ngaysinh;
                        String Gioitinh = reader["Gioitinh"] != DBNull.Value ? reader["Gioitinh"].ToString() : "";
                        if (Gioitinh == "Nam")
                        {
                            radNam.Checked = true;
                        }
                        else if (Gioitinh == "Nữ")
                        {
                            radNu.Checked = true;
                        }
                        txtPhongban.Text = reader["Tenpb"] != DBNull.Value ? reader["Tenpb"].ToString() : "";
                        txtLoaiHD.Text = reader["Kieuhopdong"] != DBNull.Value ? reader["Kieuhopdong"].ToString() : "";
                        txtLuongcoban.Text = reader["Luongcoban"] != DBNull.Value ? reader["Luongcoban"].ToString() : "";
                        txtThoigian.Text = reader["ThoiGian"] != DBNull.Value ? reader["ThoiGian"].ToString() : "";
                        txtPhucap.Text = reader["Phucap"] != DBNull.Value ? reader["Phucap"].ToString() : "";
                        // Tính tổng lương
                        decimal luongcoban = reader["Luongcoban"] != DBNull.Value ? decimal.Parse(reader["Luongcoban"].ToString()) : 0;
                        decimal phucap = reader["Phucap"] != DBNull.Value ? decimal.Parse(reader["Phucap"].ToString()) : 0;
                        decimal tongLuong = luongcoban + phucap;
                        txtLuongtong.Text = tongLuong.ToString("N0");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên!");
                    }

                    reader.Close();
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }

        }


        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtIdnv_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            LoadEmployeeData();
        }

        private void dtpNgaysinhnv_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Thongtinnhanvien_Load(object sender, EventArgs e)
        {
            LoadEmployeeNames();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            pd.Print();
        }



        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 12);
            float lineHeight = font.GetHeight(e.Graphics) + 2;
            float startX = 10;
            float startY = 10;

            // Vẽ hộp thông tin nhân viên
            Rectangle employeeInfoBox = new Rectangle(10, 10, 350, 250);
            e.Graphics.DrawRectangle(Pens.Black, employeeInfoBox);
            e.Graphics.DrawString("Thông Tin Nhân Viên", font, Brushes.Black, employeeInfoBox.X + 5, employeeInfoBox.Y + 5);

            // Di chuyển đến vị trí bắt đầu của hộp thông tin nhân viên
            startX = employeeInfoBox.X + 10;
            startY = employeeInfoBox.Y + 30;

            // Vẽ thông tin nhân viên trong hộp
            e.Graphics.DrawString("Họ và tên: " + txthodem.Text + " " + txtTen.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            string gioiTinh = radNam.Checked ? "Nam" : (radNu.Checked ? "Nữ" : "Không xác định");
            e.Graphics.DrawString("Giới tính: " + gioiTinh, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Ngày sinh: " + dtpNgaysinhnv.Value.ToShortDateString(), font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Email: " + txtEmailnv.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Địa chỉ: " + txtDiachinv.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Số điện thoại : " + txtSdtnv.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Chức vụ: " + txtChucvunv.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Phòng ban: " + txtPhongban.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("ID hợp đồng: " + txtIDhopdong.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Loại hợp đồng: " + txtLoaiHD.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            // Vẽ hộp thông tin lương
            Rectangle salaryInfoBox = new Rectangle(370, 10, 300, 250);
            e.Graphics.DrawRectangle(Pens.Black, salaryInfoBox);
            e.Graphics.DrawString("Thông Tin Lương", font, Brushes.Black, salaryInfoBox.X + 5, salaryInfoBox.Y + 5);

            // Di chuyển đến vị trí bắt đầu của hộp thông tin lương
            startX = salaryInfoBox.X + 10;
            startY = salaryInfoBox.Y + 30;

            // Vẽ thông tin lương trong hộp
            e.Graphics.DrawString("Lương cơ bản: " + txtLuongcoban.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            DateTime dateTime;
            if (DateTime.TryParse(txtThoigian.Text, out dateTime))
            {
                // Lấy thông tin tháng
                string month = dateTime.ToString("MM");

                // Hiển thị thông tin tháng
                e.Graphics.DrawString("Thời gian: Tháng " + month, font, Brushes.Black, startX, startY);
                startY += lineHeight;
            }
            else
            {
                // Xử lý trường hợp chuỗi ngày không hợp lệ
                // Ví dụ: thông báo lỗi, hoặc xử lý khác
            }


            e.Graphics.DrawString("Phụ cấp: " + txtPhucap.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;

            e.Graphics.DrawString("Tổng lương: " + txtLuongtong.Text, font, Brushes.Black, startX, startY);
            startY += lineHeight;



            // Kết thúc trang in
            e.HasMorePages = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CbbNvID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy ID nhân viên từ ComboBox và cập nhật vào TextBox txtIdnv
            KeyValuePair<string, string> selectedEmployee = (KeyValuePair<string, string>)CbbTennv.SelectedItem;
            string selectedEmployeeId = selectedEmployee.Key;
            txtIdnv.Text = selectedEmployeeId;
        }
    } 
}

