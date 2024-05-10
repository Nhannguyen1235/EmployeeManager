using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmTinhluong : Form
    {
        string connectString = "Data Source=.;" +
                  "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public frmTinhluong()
        {
            InitializeComponent();
        }

        private bool IsMissingFields()
        {
            if (string.IsNullOrEmpty(dtpThoigian.Text) || string.IsNullOrEmpty(txtIDnv.Text) || string.IsNullOrEmpty(txtLuongcoban.Text) || string.IsNullOrEmpty(txtphucap.Text)||string.IsNullOrEmpty(txtNgaylam.Text))
            {
                return true;
            }
            return false;
        }


        private void LoadEmployeeIds()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT NvID, HoDem, Ten FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        string hoDem = reader["HoDem"].ToString();
                        string ten = reader["Ten"].ToString();
                        string fullName = hoDem + " " + ten;

                        CbbTennv.Items.Add(new KeyValuePair<string, string>(nvId, fullName)); // Thêm họ đệm và tên nhân viên vào ComboBox
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private bool IsEmployeeIdExist(string employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM NhanVien WHERE NvID = @NvID";
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

        // Kiểm tra xem ID nhân viên đã tồn tại trong bảng BangLuong hay chưa
        private bool IsEmployeeIdExistInBangLuong(string employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM BangLuong WHERE NvID = @NvID";
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


        private void LoadSalaryData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BangLuong";
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

        private void btThemnv_Click(object sender, EventArgs e)
        {
            if (IsMissingFields())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            string employeeId = txtIDnv.Text;

            // Kiểm tra xem ID nhân viên đã tồn tại trong bảng BangLuong hay chưa
            if (IsEmployeeIdExistInBangLuong(employeeId))
            {
                MessageBox.Show("Nhân viên đã tồn tại trong bảng lương.");
                return;
            }

            if (!IsEmployeeIdExist(employeeId))
            {
                MessageBox.Show("Nhân viên không tồn tại trong cơ sở dữ liệu.");
                return;
            }

            decimal luongCoBan = decimal.Parse(txtLuongcoban.Text);
            decimal phuCap = decimal.Parse(txtphucap.Text);
            decimal ngayLam = decimal.Parse(txtNgaylam.Text);
            decimal ngaynghi = decimal.Parse(txtNgaynghi.Text);

            // Lấy thời gian từ DateTimePicker
            DateTime thoiGian = dtpThoigian.Value;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "INSERT INTO BangLuong (NvID, Luongcoban, Phucap, Songaylam, Songaynghi, ThoiGian, Luongtong) VALUES (@NvID, @LuongcoBan, @Phucap, @Songaylam, @Songaynghi, @ThoiGian, @LuongTong)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    cmd.Parameters.AddWithValue("@LuongcoBan", luongCoBan);
                    cmd.Parameters.AddWithValue("@Phucap", phuCap);
                    cmd.Parameters.AddWithValue("@Songaylam", ngayLam);
                    cmd.Parameters.AddWithValue("@Songaynghi", ngaynghi);
                    cmd.Parameters.AddWithValue("@ThoiGian", thoiGian); // Thêm tham số cho thời gian

                    // Tính lương tổng theo công thức
                    decimal luongTong = phuCap + luongCoBan * (ngayLam / 30);
                    cmd.Parameters.AddWithValue("@LuongTong", luongTong); // Thêm tham số cho lương tổng

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm dữ liệu thành công.");
                        LoadSalaryData();
                    }
                    else
                    {
                        MessageBox.Show("Thêm dữ liệu không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void btXoa_Click(object sender, EventArgs e)
        {
            string employeeId = txtIDnv.Text;

            if (string.IsNullOrEmpty(employeeId))
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectString))
                    {
                        conn.Open();
                        string query = "DELETE FROM BangLuong WHERE NvID = @NvID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@NvID", employeeId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa dữ liệu thành công.");
                            LoadSalaryData();
                            // Xóa nhân viên khỏi combobox
                            CbbTennv.Items.Remove(employeeId);
                        }
                        else
                        {
                            MessageBox.Show("Xóa dữ liệu không thành công.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void btChinhsua_Click(object sender, EventArgs e)
        {
            if (IsMissingFields())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            string employeeId = txtIDnv.Text;
            decimal luongCoBan = decimal.Parse(txtLuongcoban.Text);
            decimal phuCap = decimal.Parse(txtphucap.Text);
            decimal ngayLam = decimal.Parse(txtNgaylam.Text);
            decimal ngaynghi = decimal.Parse(txtNgaynghi.Text);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "UPDATE BangLuong SET LuongcoBan = @LuongcoBan, Phucap = @Phucap, Songaylam = @Songaylam, Songaynghi = @Songaynghi WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@LuongcoBan", luongCoBan);
                    cmd.Parameters.AddWithValue("@Phucap", phuCap);
                    cmd.Parameters.AddWithValue("@Songaynghi", ngaynghi);
                    cmd.Parameters.AddWithValue("@Songaylam", ngayLam);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật dữ liệu thành công.");
                        LoadSalaryData();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật dữ liệu không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txtHesoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void frmTinhluong_Load(object sender, EventArgs e)
        {
            LoadEmployeeIds();
            LoadSalaryData();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbbIDnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbbTennv.SelectedIndex != -1)
            {
                KeyValuePair<string, string> selectedEmployee = (KeyValuePair<string, string>)CbbTennv.SelectedItem;
                string nvId = selectedEmployee.Key;
                txtIDnv.Text = nvId;
                return;
            }

        }

        private void btncapnhap_Click(object sender, EventArgs e)
        {
            LoadSalaryData();
        }

        // Phương thức để lấy tên nhân viên từ bảng Nhân viên dựa trên ID nhân viên
        private string GetEmployeeNameById(string employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT CONCAT(HoDem, ' ', Ten) AS FullName FROM Nhanvien WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    string employeeName = cmd.ExecuteScalar()?.ToString();
                    return employeeName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return null;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ chưa
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string NvID = selectedRow.Cells["NvID"].Value.ToString();
                string luongCoBan = selectedRow.Cells["LuongcoBan"].Value.ToString();
                string thoigian = selectedRow.Cells["ThoiGian"].Value.ToString();
                string phuCap = selectedRow.Cells["Phucap"].Value.ToString();
                string ngayLam = selectedRow.Cells["Songaylam"].Value.ToString();
                string ngaynghi = selectedRow.Cells["Songaynghi"].Value.ToString();
                string tongluong = selectedRow.Cells["Luongtong"].Value.ToString();
                // Hiển thị dữ liệu từ DataGridView vào các TextBox
                txtIDnv.Text = NvID;
                txtLuongcoban.Text = luongCoBan;
                dtpThoigian.Text = thoigian;
                txtphucap.Text = phuCap;
                txtNgaynghi.Text = ngaynghi;
                txtNgaylam.Text = ngayLam;
                txtLuongtong.Text = tongluong;

                // Lấy tên nhân viên từ bảng Nhân viên dựa trên ID nhân viên và đưa vào ComboBox
                string employeeName = GetEmployeeNameById(NvID);
                if (employeeName != null)
                {
                    CbbTennv.Text = employeeName;
                }
            }
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
