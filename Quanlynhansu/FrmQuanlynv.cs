using Quanlynhansu;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class FrmQuanlynv : Form
    {
        
        public FrmQuanlynv()
        {
            InitializeComponent();
            
    }
        string connectString = "Data Source=Localhost;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public void Clear()
        {
            this.txtIdnv.Clear();
            this.txthodem.Clear();
            this.txtTen.Clear();
            this.CbbPhongban.Refresh();
            this.txtChucvunv.Clear();
            this.txtSdtnv.Clear();
            this.txtDiachinv.Clear();
            this.txtEmailnv.Clear();
            this.txtChucvunv.Clear();
        }

        public Boolean Check()
        {

            if (
                string.IsNullOrEmpty(txtDiachinv.Text) || string.IsNullOrEmpty(txtTen.Text)||
                string.IsNullOrEmpty(txthodem.Text)|| string.IsNullOrEmpty(txtChucvunv.Text) ||
                string.IsNullOrEmpty(txtEmailnv.Text) || string.IsNullOrEmpty(txtSdtnv.Text)||string.IsNullOrEmpty(txtChucvunv.Text)||string.IsNullOrEmpty(CbbPhongban.Text)) { return false; }
            else { return true; }
        }

        private void CapNhatDataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = @"
                SELECT NhanVien.NvID, NhanVien.HoDem, NhanVien.Ten, NhanVien.GioiTinh, NhanVien.NgaySinh, 
                       NhanVien.DiaChi, NhanVien.ChucVu, NhanVien.SDT, PhongBan.Tenpb AS PhongBan, NhanVien.Email
                FROM NhanVien
                JOIN PhongBan ON NhanVien.PbID = PhongBan.PbID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT * FROM NhanVien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
            private void txtMasv_TextChanged(object sender, EventArgs e)
        {

        }

        private void btThemnv_Click(object sender, EventArgs e)
        {
            try
            {
                if (Check())
                {
                    using (SqlConnection connection = new SqlConnection(connectString))
                    {
                        connection.Open();
                        string idnv = txtIdnv.Text;
                        // Kiểm tra độ dài của ID nhân viên
                        if (idnv.Length > 8)
                        {
                            MessageBox.Show("ID nhân viên không được vượt quá 8 ký tự!");
                            return; // Kết thúc phương thức nếu ID nhân viên vượt quá 8 ký tự
                        }
                        string hoDem = txthodem.Text;
                        string ten = txtTen.Text;
                        string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                        string ngaySinh = dtpNgaysinhnv.Value.ToString("yyyy-MM-dd");
                        string diaChi = txtDiachinv.Text;
                        string chucVu = txtChucvunv.Text;
                        string soDienThoai = txtSdtnv.Text;
                        string Phongban = CbbPhongban.Text;
                        string Email = txtEmailnv.Text;

                        // Xác định PbID tương ứng với tên phòng ban được chọn
                        int pbId = -1; // Giá trị mặc định nếu không có phòng ban được chọn
                        string selectedPhongBan = CbbPhongban.Text;
                        switch (selectedPhongBan)
                        {
                            case "Kế toán":
                                pbId = 2;
                                break;
                            case "Nhân sự":
                                pbId = 3;
                                break;
                            case "Kỹ thuật":
                                pbId = 4;
                                break;
                            case "Quản trị":
                                pbId = 6;
                                break;
                            default:
                                // Xử lý trường hợp không có phòng ban được chọn
                                break;
                        }

                        // Nếu có phòng ban được chọn, thêm nhân viên vào cơ sở dữ liệu
                        if (pbId != -1)
                        {
                            string query = @"INSERT INTO NhanVien (NvID, Hodem, Ten, Gioitinh, Ngaysinh, Diachi, Chucvu, SDT, PbID, Email) 
                             VALUES (@NvID, @HoDem, @Ten, @GioiTinh, @NgaySinh, @DiaChi, @ChucVu, @SoDienThoai, @PbID, @Email)";
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@NvID", idnv);
                            command.Parameters.AddWithValue("@HoDem", hoDem);
                            command.Parameters.AddWithValue("@Ten", ten);
                            command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                            command.Parameters.AddWithValue("@NgaySinh", ngaySinh);
                            command.Parameters.AddWithValue("@DiaChi", diaChi);
                            command.Parameters.AddWithValue("@ChucVu", chucVu);
                            command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                            command.Parameters.AddWithValue("@PbID", pbId);
                            command.Parameters.AddWithValue("@Email", Email);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Thêm nhân viên thành công!");
                                // Sau khi thêm thành công, làm sạch các trường nhập liệu
                                Clear();
                                CapNhatDataGridView();
                            }
                            else
                            {
                                MessageBox.Show("Thêm nhân viên thất bại!");
                            }
                        }
                        else
                        {
                            // Xử lý trường hợp không có phòng ban được chọn
                            MessageBox.Show("Vui lòng chọn phòng ban!");
                        }
                    }
                } else { MessageBox.Show("Vui lòng nhập đầy đủ thông tin"); }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            dataGridView1.Refresh();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    // Lấy thông tin từ hàng được chọn
                    string nvId = row.Cells["NvID"].Value.ToString();
                    string hoDem = row.Cells["Hodem"].Value.ToString();
                    string ten = row.Cells["Ten"].Value.ToString();
                    string gioiTinh = row.Cells["Gioitinh"].Value.ToString();
                    DateTime ngaySinh = Convert.ToDateTime(row.Cells["Ngaysinh"].Value);
                    string diaChi = row.Cells["Diachi"].Value.ToString();
                    string chucVu = row.Cells["Chucvu"].Value.ToString();
                    string soDienThoai = row.Cells["SDT"].Value.ToString();
                    string phongBan = row.Cells["PhongBan"].Value.ToString();
                    string email = row.Cells["Email"].Value.ToString();
                    // Cập nhật các TextBox với thông tin lấy được
                    txtIdnv.Text = nvId;
                    txthodem.Text = hoDem;
                    txtTen.Text = ten;
                    if (gioiTinh == "Nam")
                    {
                        radNam.Checked = true;
                    }
                    else
                    {
                        radNu.Checked = true;
                    }
                    dtpNgaysinhnv.Value = ngaySinh;
                    txtDiachinv.Text = diaChi;
                    txtChucvunv.Text = chucVu;
                    txtSdtnv.Text = soDienThoai;
                    CbbPhongban.Text = phongBan;
                    txtEmailnv.Text = email;
                

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }

        private void XoaNhanVien(string nvId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();

                    // Xóa dữ liệu từ bảng tài khoản liên quan đến nhân viên
                    string deleteAccQuery = "DELETE FROM TaiKhoan WHERE NvID = @NvID";
                    SqlCommand deleteAccCmd = new SqlCommand(deleteAccQuery, conn);
                    deleteAccCmd.Parameters.AddWithValue("@NvID", nvId);
                    deleteAccCmd.ExecuteNonQuery();

                    // Xóa dữ liệu từ cột NvID của bảng QuyenNV liên quan đến nhân viên
                    string deletePermissionQuery = "DELETE FROM QuyenNV WHERE NvID = @NvID";
                    SqlCommand deletePermissionCmd = new SqlCommand(deletePermissionQuery, conn);
                    deletePermissionCmd.Parameters.AddWithValue("@NvID", nvId);
                    deletePermissionCmd.ExecuteNonQuery();

                    // Cập nhật dữ liệu từ cột IDQuanly của bảng Phongban liên quan đến nhân viên
                    string updateDepartmentQuery = "UPDATE Phongban SET IDQuanly = NULL WHERE IDQuanly = @NvID";
                    SqlCommand updateDepartmentCmd = new SqlCommand(updateDepartmentQuery, conn);
                    updateDepartmentCmd.Parameters.AddWithValue("@NvID", nvId);
                    updateDepartmentCmd.ExecuteNonQuery();

                    // Xóa dữ liệu từ bảng Hợp đồng liên quan đến nhân viên
                    string deleteContractQuery = "DELETE FROM Hopdong WHERE NvID = @NvID";
                    SqlCommand deleteContractCmd = new SqlCommand(deleteContractQuery, conn);
                    deleteContractCmd.Parameters.AddWithValue("@NvID", nvId);
                    deleteContractCmd.ExecuteNonQuery();

                    // Xóa dữ liệu từ bảng Lương liên quan đến nhân viên
                    string deleteSalaryQuery = "DELETE FROM BangLuong WHERE NvID = @NvID";
                    SqlCommand deleteSalaryCmd = new SqlCommand(deleteSalaryQuery, conn);
                    deleteSalaryCmd.Parameters.AddWithValue("@NvID", nvId);
                    deleteSalaryCmd.ExecuteNonQuery();

                    // Sau khi xóa dữ liệu từ cả bảng QuyenNV, bảng Phongban, bảng Hợp đồng và bảng Lương, tiếp tục xóa nhân viên
                    string deleteEmployeeQuery = "DELETE FROM NhanVien WHERE NvID = @NvID";
                    SqlCommand deleteEmployeeCmd = new SqlCommand(deleteEmployeeQuery, conn);
                    deleteEmployeeCmd.Parameters.AddWithValue("@NvID", nvId);
                    int rowsAffected = deleteEmployeeCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã xóa nhân viên thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần xóa!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private void btXoanv_Click(object sender, EventArgs e)
        {
            string nvId = txtIdnv.Text; // Lấy ID của nhân viên cần xóa từ TextBox hoặc nơi khác trên giao diện người dùng
            XoaNhanVien(nvId);
            CapNhatDataGridView();
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Btthemsv_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void ChinhSuaNhanVien(string nvId, string hoDem, string ten, string gioiTinh, DateTime ngaySinh, string diaChi, string chucVu, string soDienThoai, string phongBan, string email)
        {
            int pbId = -1; // Khởi tạo pbId với giá trị mặc định

            // Chuyển đổi tên phòng ban thành PbID tương ứng
            switch (phongBan)
            {
                case "Kế toán":
                    pbId = 2;
                    break;
                case "Nhân sự":
                    pbId = 3;
                    break;
                case "Kỹ thuật":
                    pbId = 4;
                    break;
                case "Quản trị":
                    pbId = 6;
                    break;
                default:
                    // Xử lý trường hợp không có phòng ban được chọn
                    MessageBox.Show("Vui lòng chọn phòng ban!");
                    return; // Kết thúc phương thức nếu không có phòng ban được chọn
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = @"UPDATE NhanVien 
                             SET Hodem = @Hodem, Ten = @Ten, Gioitinh = @Gioitinh, Ngaysinh = @Ngaysinh, Diachi = @Diachi, Chucvu = @Chucvu, SDT = @SDT, PbID = @PbID, Email = @Email
                             WHERE NvID = @NvID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@NvID", nvId);
                    cmd.Parameters.AddWithValue("@Hodem", hoDem);
                    cmd.Parameters.AddWithValue("@Ten", ten);
                    cmd.Parameters.AddWithValue("@Gioitinh", gioiTinh);
                    cmd.Parameters.AddWithValue("@Ngaysinh", ngaySinh);
                    cmd.Parameters.AddWithValue("@Diachi", diaChi);
                    cmd.Parameters.AddWithValue("@Chucvu", chucVu);
                    cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                    cmd.Parameters.AddWithValue("@PbID", pbId); // Sử dụng pbId đã được chuyển đổi
                    cmd.Parameters.AddWithValue("@Email", email);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thông tin nhân viên đã được cập nhật thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            string nvId = txtIdnv.Text; // Lấy ID của nhân viên cần chỉnh sửa từ TextBox hoặc nơi khác trên giao diện người dùng
            string hoDem = txthodem.Text; // Lấy thông tin cập nhật từ các TextBox hoặc các điều khiển khác
            string ten = txtTen.Text;
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
            DateTime ngaySinh = dtpNgaysinhnv.Value;
            string diaChi = txtDiachinv.Text;
            string chucVu = txtChucvunv.Text;
            string soDienThoai = txtSdtnv.Text;
            string phongBan = CbbPhongban.Text; // Lấy tên phòng ban từ ComboBox hoặc nơi khác
            string email = txtEmailnv.Text;
            ChinhSuaNhanVien(nvId, hoDem, ten, gioiTinh, ngaySinh, diaChi, chucVu, soDienThoai, phongBan, email);// Gọi phương thức để chỉnh sửa thông tin nhân viên
            CapNhatDataGridView();
            Clear();
        }

        private void txtIdnv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != '.') && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                btThemnv_Click(sender, e);
            }
        }

        private void txtHovatennv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtChucvunv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void txtSdtnv_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void Btnluongnv_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection connection = new SqlConnection(connectString);
                String commandString = "SELECT *FROM luongnv";
                SqlDataAdapter da = new SqlDataAdapter(commandString, connection);

                DataSet ds = new DataSet();
                da.Fill(ds, "BangLuongnv");

                dataGridView1.DataSource = ds.Tables["BangLuongnv"];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

            private void button3_Click(object sender, EventArgs e)
        {
            frmTinhluong frm = new frmTinhluong();
            frm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmtimkiem frmt = new frmtimkiem();
            frmt.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void FrmQuanlynv_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = @"
                SELECT NhanVien.NvID, NhanVien.HoDem, NhanVien.Ten, NhanVien.GioiTinh, NhanVien.NgaySinh, 
                       NhanVien.DiaChi, NhanVien.ChucVu, NhanVien.SDT, PhongBan.Tenpb AS PhongBan, NhanVien.Email
                FROM NhanVien
                JOIN PhongBan ON NhanVien.PbID = PhongBan.PbID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Hiển thị dữ liệu trong DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadPhongBan()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT Tenpb FROM PhongBan";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                      
                        string phongBan = reader["Tenpb"].ToString();
                        if (!CbbPhongban.Items.Contains(phongBan))
                        {
                            CbbPhongban.Items.Add(phongBan);
                        }
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }


        private void CbbPhongban_Click_1(object sender, EventArgs e)
        {
            LoadPhongBan();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
          
        }
    }
}
