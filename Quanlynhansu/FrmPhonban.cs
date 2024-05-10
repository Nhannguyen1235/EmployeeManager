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
    public partial class FrmPhonban : Form
    {

        string connectString = "Data Source=.;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public FrmPhonban()
        {
            InitializeComponent();
        }

        private bool IsDepartmentIdExist(string departmentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM PhongBan WHERE PbID = @PbID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PbID", departmentId);
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

        private void LoadEmployeeNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT NvID, HoDem, Ten FROM Nhanvien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa các mục cũ trong ComboBox trước khi đổ dữ liệu mới
                    CbbTennv.Items.Clear();

                    // Đổ dữ liệu Họ đệm và Tên vào ComboBox và lưu ID vào Tag của mỗi item
                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        string hoDem = reader["HoDem"].ToString();
                        string ten = reader["Ten"].ToString();
                        string fullName = hoDem + " " + ten;

                        // Lưu ID nhân viên vào Tag của mỗi item
                        CbbTennv.Items.Add(new KeyValuePair<string, string>(nvId, fullName));
                    }

                    // Đóng kết nối và đóng reader sau khi hoàn thành
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private bool IsMissingFields()
        {
            if (string.IsNullOrEmpty(txtIDphongban.Text) ||
                string.IsNullOrEmpty(txtTenpb.Text) ||
                string.IsNullOrEmpty(CbbTennv.Text))
            {
                return true;
            }
            return false;
        }

        private void LoadDepartmentData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Phongban";
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

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsManagerAssignedToOtherDepartment(string managerId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM PhongBan WHERE IDQuanly = @IDQuanly";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IDQuanly", managerId);
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

        private void btThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsMissingFields())
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string pbId = txtIDphongban.Text;
                string tenPb = txtTenpb.Text;
                string idQuanLy = txtIdnv.Text;

                if (IsDepartmentIdExist(pbId))
                {
                    MessageBox.Show("ID phòng ban đã tồn tại. Vui lòng chọn ID khác.");
                    return;
                }

                if (IsManagerAssignedToOtherDepartment(idQuanLy))
                {
                    MessageBox.Show("ID quản lý đã được gán cho phòng ban khác. Vui lòng chọn ID quản lý khác.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "INSERT INTO PhongBan (Tenpb, IDQuanly) VALUES (@Tenpb, @IDQuanly)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Tenpb", tenPb);
                    cmd.Parameters.AddWithValue("@IDQuanly", idQuanLy);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm phòng ban thành công.");
                        LoadDepartmentData(); // Cập nhật lại dữ liệu sau khi thêm
                    }
                    else
                    {
                        MessageBox.Show("Thêm phòng ban không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void FrmPhonban_Load(object sender, EventArgs e)
        {
            LoadDepartmentData();
            LoadEmployeeNames();
        }

        private void LoadEmployeeNameIntoComboBox(string employeeId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT HoDem, Ten FROM Nhanvien WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", employeeId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        string hoDem = reader["HoDem"].ToString();
                        string ten = reader["Ten"].ToString();
                        string fullName = hoDem + " " + ten;

                        // Đưa Họ đệm và Tên của nhân viên vào ComboBox và chọn mục tương ứng
                        CbbTennv.Text = fullName;
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ chưa
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string pbId = selectedRow.Cells["PbID"].Value.ToString();
                string tenPb = selectedRow.Cells["Tenpb"].Value.ToString();
                string idQuanLy = selectedRow.Cells["IDQuanly"].Value.ToString();

                // Hiển thị dữ liệu từ DataGridView vào các TextBox
                txtIDphongban.Text = pbId;
                txtTenpb.Text = tenPb;
                txtIdnv.Text = idQuanLy;

                // Đổ thêm tên nhân viên vào ComboBox
                LoadEmployeeNameIntoComboBox(idQuanLy);
            }
        }

        private void btncapnhap_Click(object sender, EventArgs e)
        {
            LoadDepartmentData();
        }

        private void btChinhsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsMissingFields())
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }

                string pbId = txtIDphongban.Text;
                string tenPb = txtTenpb.Text;
                string idQuanLy = txtIdnv.Text;

                if (IsManagerAssignedToOtherDepartment(idQuanLy))
                {
                    MessageBox.Show("ID quản lý đã được gán cho phòng ban khác. Vui lòng chọn ID quản lý khác.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "UPDATE PhongBan SET Tenpb = @Tenpb, IDQuanly = @IDQuanly WHERE PbID = @PbID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@PbID", pbId);
                    cmd.Parameters.AddWithValue("@Tenpb", tenPb);
                    cmd.Parameters.AddWithValue("@IDQuanly", idQuanLy);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin phòng ban thành công.");
                        LoadDepartmentData(); // Cập nhật lại dữ liệu sau khi chỉnh sửa
                    }
                    else
                    {
                        MessageBox.Show("Không có thông tin nào được cập nhật.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy ID của phòng ban từ TextBox
                string pbId = txtIDphongban.Text;

                // Kiểm tra xem ID phòng ban đã được nhập hay chưa
                if (string.IsNullOrEmpty(pbId))
                {
                    MessageBox.Show("Vui lòng nhập ID phòng ban để xóa.");
                    return;
                }

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng ban này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Thực hiện xóa phòng ban từ cơ sở dữ liệu
                    using (SqlConnection conn = new SqlConnection(connectString))
                    {
                        conn.Open();
                        string query = "DELETE FROM PhongBan WHERE PbID = @PbID";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@PbID", pbId);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa phòng ban thành công.");
                            LoadDepartmentData(); // Cập nhật lại dữ liệu sau khi xóa
                        }
                        else
                        {
                            MessageBox.Show("Không có phòng ban nào được xóa.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbbTennv_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem đã chọn một nhân viên từ ComboBox chưa
            if (CbbTennv.SelectedItem != null)
            {
                // Lấy ID nhân viên từ Tag của item đã chọn và đưa vào TextBox
                KeyValuePair<string, string> selectedEmployee = (KeyValuePair<string, string>)CbbTennv.SelectedItem;
                string nvId = selectedEmployee.Key;
                txtIdnv.Text = nvId;
            }
        }
    }
}
