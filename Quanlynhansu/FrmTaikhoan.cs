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

namespace Quanlynhansu
{
    public partial class FrmTaikhoan : Form
    {
        private string connectString = "Data Source=Localhost;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public FrmTaikhoan()
        {
            InitializeComponent();
        }

        private void ClearTextBoxes()
        {
            txtTendangnhap.Clear();
            txtMatkhau.Clear();
            txtIDtaikhoan.Clear();
            CbbTennv.Refresh();
        }

        private bool IsMissingFields()
        {
            if (string.IsNullOrEmpty(CbbTennv.Text) || string.IsNullOrEmpty(txtTendangnhap.Text) || string.IsNullOrEmpty(txtMatkhau.Text))
            {
                return true;
            }
            return false;
        }


        private bool IsEmployeeIdExist(string employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM TaiKhoan WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return false;
            }
        }

        private void LoadAccountData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT * FROM TaiKhoan";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
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
                    string query = "SELECT NvID, CONCAT(HoDem, ' ', Ten) AS HoTen FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        string hoTen = reader["HoTen"].ToString();
                        // Tạo một đối tượng mới chứa cả ID và tên của nhân viên
                        KeyValuePair<string, string> employee = new KeyValuePair<string, string>(nvId, hoTen);
                        // Thêm đối tượng vào ComboBox
                        CbbTennv.Items.Add(employee);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void BtThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsMissingFields()==true)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return ;
                }

                string employeeId = txtIDnv.Text;
                if (IsEmployeeIdExist(employeeId)==true)
                {
                    MessageBox.Show("ID nhân viên đã tồn tại trong hệ thống. Vui lòng chọn ID khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nvId = txtIDnv.Text;
                string tenDangNhap = txtTendangnhap.Text;
                string matKhau = txtMatkhau.Text;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "INSERT INTO TaiKhoan (TenDangNhap, MatKhau, NvID) VALUES (@TenDangNhap, @MatKhau, @NvID)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                    cmd.Parameters.AddWithValue("@NvID", nvId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm tài khoản thành công!");
                        LoadAccountData();
                        ClearTextBoxes();
                    }
                    else
                    {
                        MessageBox.Show("Thêm tài khoản thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        
        }

        private void FrmTaikhoan_Load(object sender, EventArgs e)
        {
            LoadEmployeeIds();
            LoadAccountData();
        }

        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            LoadAccountData();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string nvId = CbbTennv.Text;
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản của nhân viên có ID " + nvId + " không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectString))
                    {
                        conn.Open();
                        string query = "DELETE FROM TaiKhoan WHERE NvID = @NvID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@NvID", nvId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!");
                            LoadAccountData();
                            ClearTextBoxes(); 
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản của nhân viên có ID " + nvId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtChinhsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsMissingFields() == true)
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nvId = txtIDnv.Text;
                string tenDangNhap = txtTendangnhap.Text;
                string matKhau = txtMatkhau.Text;

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn chỉnh sửa tài khoản của nhân viên có ID " + nvId + " không?", "Xác nhận chỉnh sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectString))
                    {
                        conn.Open();
                        string query = "UPDATE TaiKhoan SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau WHERE NvID = @NvID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", matKhau);
                        cmd.Parameters.AddWithValue("@NvID", nvId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Chỉnh sửa tài khoản thành công!");
                            LoadAccountData(); 
                            ClearTextBoxes(); 
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản của nhân viên có ID " + nvId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private string GetEmployeeNameById(string employeeId)
        {
            string employeeName = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT CONCAT(HoDem, ' ', Ten) AS HoTen FROM NhanVien WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    employeeName = cmd.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return employeeName;
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0) // Kiểm tra xem người dùng đã nhấp vào hàng hợp lệ trong DataGridView chưa
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    // Lấy thông tin từ hàng được chọn
                    string nvId = row.Cells["NvID"].Value.ToString();
                    string tenDangNhap = row.Cells["TenDangNhap"].Value.ToString();
                    string matKhau = row.Cells["MatKhau"].Value.ToString();
                    string idTaiKhoan = row.Cells["TaiKhoanID"].Value.ToString();
                    // Cập nhật các TextBox với thông tin lấy được
                    txtIDnv.Text = nvId;
                    txtTendangnhap.Text = tenDangNhap;
                    txtMatkhau.Text = matKhau;
                    txtIDtaikhoan.Text = idTaiKhoan;

                    // Hiển thị tên nhân viên trong Label hoặc TextBox tùy theo nhu cầu
                    string tenNhanVien = GetEmployeeNameById(nvId);
                    CbbTennv.Text = tenNhanVien;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbbTennv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbbTennv.SelectedItem != null)
            {
                KeyValuePair<string, string> selectedEmployee = (KeyValuePair<string, string>)CbbTennv.SelectedItem;
                string nvId = selectedEmployee.Key;
                txtIDnv.Text = nvId;
            }
        }
    }
}
