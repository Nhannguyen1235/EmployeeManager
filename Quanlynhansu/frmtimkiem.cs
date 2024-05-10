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

namespace WindowsFormsApp2
{
    public partial class frmtimkiem : Form
    {

        private SqlConnection connection;
        private string connectString = "Data Source=Localhost;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public frmtimkiem()
        {
            InitializeComponent();
            connection = new SqlConnection(connectString);
        }
        private bool Checkid(string checkid)
        {
            using (SqlConnection connection = new SqlConnection(connectString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM nhanvien WHERE idnv = @idnv", connection);
                command.Parameters.AddWithValue("@idnv", checkid);
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count == 0;

            }
        }
        public Boolean Check()
        {
            if (string.IsNullOrEmpty(txtSearchId.Text)) { return false; }
            else { return true; }
        }

        private void dtgDanhsach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string employeeId = txtSearchId.Text.Trim(); // Lấy ID nhân viên từ TextBox
            string departmentName = txtPb.Text.Trim(); // Lấy tên phòng ban từ TextBox
            string position = txtChucvu.Text.Trim(); // Lấy chức vụ từ TextBox
            string fullName = txtHoten.Text.Trim(); // Lấy họ và tên từ TextBox

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = @"
                    SELECT NhanVien.*, 
                    CASE 
                    WHEN PhongBan.PbID = 2 THEN 'Kế toán'
                    WHEN PhongBan.PbID = 3 THEN 'Nhân sự'
                    WHEN PhongBan.PbID = 4 THEN 'Kỹ thuật'
                    WHEN PhongBan.PbID = 6 THEN 'Quản trị'
                    ELSE 'Không xác định'
                    END AS Tenpb
                    FROM NhanVien
                    JOIN PhongBan ON NhanVien.PbID = PhongBan.PbID
                    WHERE 1 = 1";

                    // Thêm điều kiện tìm kiếm theo ID nhân viên (nếu được cung cấp)
                    if (!string.IsNullOrEmpty(employeeId))
                    {
                        query += " AND NhanVien.NvID = @EmployeeId";
                    }

                    // Thêm điều kiện tìm kiếm theo tên phòng ban (nếu được cung cấp)
                    if (!string.IsNullOrEmpty(departmentName))
                    {
                        query += " AND PhongBan.Tenpb LIKE @DepartmentName";
                    }

                    // Thêm điều kiện tìm kiếm theo chức vụ (nếu được cung cấp)
                    if (!string.IsNullOrEmpty(position))
                    {
                        query += " AND NhanVien.ChucVu LIKE @Position";
                    }

                    // Thêm điều kiện tìm kiếm theo họ và tên (nếu được cung cấp)
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        query += " AND (NhanVien.Hodem + ' ' + NhanVien.Ten) LIKE @FullName";
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Thêm các tham số và gán giá trị cho các tham số
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@DepartmentName", "%" + departmentName + "%");
                    cmd.Parameters.AddWithValue("@Position", "%" + position + "%");
                    cmd.Parameters.AddWithValue("@FullName", "%" + fullName + "%");

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị kết quả tìm kiếm trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        // Phương thức kiểm tra kết quả tìm kiếm
        private bool IsSearchSuccessful()
        {
            // Kiểm tra xem DataGridView có ít nhất một dòng được chọn hay không
            return dataGridView1.SelectedRows.Count > 0;
        }

        private void txtSearchId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearch.PerformClick();
                // Kiểm tra kết quả tìm kiếm
                if (!IsSearchSuccessful())
                {
                    MessageBox.Show("Không tìm thấy nhân viên có ID này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

