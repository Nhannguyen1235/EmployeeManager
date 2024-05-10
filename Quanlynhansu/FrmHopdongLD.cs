using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Quanlynhansu
{
    public partial class FrmHopdongLD : Form
    {
        string connectString = "Data Source=.;" +
                 "Initial Catalog=QuanLyNhanSu;Integrated Security=True";
        public FrmHopdongLD()
        {
            InitializeComponent();
        }

        private bool IsMissingFields()
        {
            if (CbbTennv.SelectedItem == null ||
                string.IsNullOrEmpty(txtKieuhopdong.Text) ||
                string.IsNullOrEmpty(txtThoihan.Text))
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
                    string query = "SELECT COUNT(*) FROM HopDong WHERE NvID = @NvID";
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
        Dictionary<string, string> employeeInfo = new Dictionary<string, string>();
        private void CbbTennv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbbTennv.SelectedItem != null)
            {
                string selectedEmployeeName = CbbTennv.SelectedItem.ToString();


                // Nếu tìm thấy tên nhân viên trong từ điển, hiển thị ID tương ứng trong TextBox
                if (CbbTennv.SelectedItem != null)
                {
                    KeyValuePair<string, string> selectedEmployee = (KeyValuePair<string, string>)CbbTennv.SelectedItem;
                    string nvId = selectedEmployee.Key;
                    txtIDnv.Text = nvId;
                    return;
                }
            }
        }

        private void LoadEmployeeNames()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT NvID, CONCAT(HoDem, ' ', Ten) AS HoTen FROM Nhanvien";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Xóa các mục cũ trong ComboBox trước khi đổ dữ liệu mới
                    CbbTennv.Items.Clear();

                    // Đổ dữ liệu vào ComboBox
                    while (reader.Read())
                    {
                        string nvId = reader["NvID"].ToString();
                        string hoTen = reader["HoTen"].ToString();
                        CbbTennv.Items.Add(new KeyValuePair<string, string>(nvId, hoTen));
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

        private void DisplayEmployeeName(string employeeId)
        {
            foreach (KeyValuePair<string, string> item in CbbTennv.Items)
            {
                if (item.Key == employeeId)
                {
                    CbbTennv.SelectedItem = item; // Chọn nhân viên trong ComboBox dựa trên ID nhân viên
                    return;
                }
            }
        }






        private void LoadContractData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "SELECT * FROM HopDong";
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

        private void FrmHopdongLD_Load(object sender, EventArgs e)
        {
            LoadEmployeeNames();
            LoadContractData();
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng hợp lệ chưa
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string hdID = selectedRow.Cells["HdID"].Value.ToString();
                string nvId = selectedRow.Cells["NvID"].Value.ToString();
                string loaiHopDong = selectedRow.Cells["Kieuhopdong"].Value.ToString();
                string thoiHan = selectedRow.Cells["Thoihan"].Value.ToString();
                DateTime ngayBatDau = Convert.ToDateTime(selectedRow.Cells["Ngaybatdau"].Value);
                DateTime ngayKetThuc = Convert.ToDateTime(selectedRow.Cells["Ngayket"].Value);

                // Hiển thị dữ liệu từ DataGridView vào các TextBox
                txtIDnv.Text = nvId;
                txtIDhopdong.Text = hdID;
                txtKieuhopdong.Text = loaiHopDong;
                txtThoihan.Text = thoiHan;
                DtNgaybatdau.Value = ngayBatDau;
                DtNgayketthuc.Value = ngayKetThuc;

                DisplayEmployeeName(nvId);
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

                string nvId = txtIDnv.Text;

                if (IsEmployeeIdExist(nvId))
                {
                    MessageBox.Show("ID nhân viên đã tồn tại trong bảng Hợp đồng.");
                    return;
                }

                string kieuHopDong = txtKieuhopdong.Text;
                string thoiHan = txtThoihan.Text;
                DateTime ngayBatDau = DtNgaybatdau.Value;
                DateTime ngayKetThuc = DtNgayketthuc.Value;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string queryInsert = "INSERT INTO HopDong (NvID, Kieuhopdong, Thoihan, Ngaybatdau, Ngayket) VALUES (@NvID, @Kieuhopdong, @Thoihan, @Ngaybatdau, @Ngayket)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@NvID", nvId);
                    cmdInsert.Parameters.AddWithValue("@Kieuhopdong", kieuHopDong);
                    cmdInsert.Parameters.AddWithValue("@Thoihan", thoiHan);
                    cmdInsert.Parameters.AddWithValue("@Ngaybatdau", ngayBatDau);
                    cmdInsert.Parameters.AddWithValue("@Ngayket", ngayKetThuc);
                    int rowsAffected = cmdInsert.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Sau khi thêm hợp đồng mới thành công, lấy HdID tương ứng
                        string querySelectHdID = "SELECT HdID FROM HopDong WHERE NvID = @NvID AND Ngaybatdau = @Ngaybatdau";
                        SqlCommand cmdSelectHdID = new SqlCommand(querySelectHdID, conn);
                        cmdSelectHdID.Parameters.AddWithValue("@NvID", nvId);
                        cmdSelectHdID.Parameters.AddWithValue("@Ngaybatdau", ngayBatDau);
                        object hdIdObj = cmdSelectHdID.ExecuteScalar();

                        if (hdIdObj != null)
                        {
                            int hdId = Convert.ToInt32(hdIdObj);
                            // Cập nhật HdID vào bản nhân viên
                            string queryUpdateNhanVien = "UPDATE NhanVien SET HdID = @HdID WHERE NvID = @NvID";
                            SqlCommand cmdUpdateNhanVien = new SqlCommand(queryUpdateNhanVien, conn);
                            cmdUpdateNhanVien.Parameters.AddWithValue("@HdID", hdId);
                            cmdUpdateNhanVien.Parameters.AddWithValue("@NvID", nvId);
                            int rowsAffectedUpdate = cmdUpdateNhanVien.ExecuteNonQuery();

                            if (rowsAffectedUpdate > 0)
                            {
                                MessageBox.Show("Thêm hợp đồng và cập nhật HdID thành công.");
                                LoadContractData(); // Cập nhật lại dữ liệu sau khi thêm
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật HdID không thành công.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy HdID tương ứng.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm hợp đồng không thành công.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
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

                string hdId = txtIDhopdong.Text;


                string kieuHopDong = txtKieuhopdong.Text;
                string thoiHan = txtThoihan.Text;
                DateTime ngayBatDau = DtNgaybatdau.Value;
                DateTime ngayKetThuc = DtNgayketthuc.Value;

                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    string query = "UPDATE HopDong SET  Kieuhopdong = @Kieuhopdong, Thoihan = @Thoihan, Ngaybatdau = @Ngaybatdau, Ngayket = @Ngayket WHERE HdID = @HdID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HdID", hdId);
                    cmd.Parameters.AddWithValue("@Kieuhopdong", kieuHopDong);
                    cmd.Parameters.AddWithValue("@Thoihan", thoiHan);
                    cmd.Parameters.AddWithValue("@Ngaybatdau", ngayBatDau);
                    cmd.Parameters.AddWithValue("@Ngayket", ngayKetThuc);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Chỉnh sửa hợp đồng thành công.");
                        LoadContractData(); // Cập nhật lại dữ liệu sau khi chỉnh sửa
                    }
                    else
                    {
                        MessageBox.Show("Không có hợp đồng nào được chỉnh sửa.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btncapnhap_Click(object sender, EventArgs e)
        {
            LoadContractData();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

            try
            {
                // Lấy ID của hợp đồng từ TextBox
                string hdId = txtIDhopdong.Text;

                // Kiểm tra xem ID hợp đồng đã được nhập hay chưa
                if (string.IsNullOrEmpty(hdId))
                {
                    MessageBox.Show("Vui lòng nhập ID hợp đồng để xóa.");
                    return;
                }

                // Thực hiện xóa hợp đồng từ bảng HopDong
                using (SqlConnection conn = new SqlConnection(connectString))
                {
                    conn.Open();
                    // Thực hiện xóa số HdID trong bảng nhân viên theo HdID trong bảng hợp đồng
                    string queryDeleteNvHd = "UPDATE NhanVien SET HdID = NULL WHERE HdID = @HdID";
                    SqlCommand cmdDeleteNvHd = new SqlCommand(queryDeleteNvHd, conn);
                    cmdDeleteNvHd.Parameters.AddWithValue("@HdID", hdId);
                    int rowsAffectedNvHd = cmdDeleteNvHd.ExecuteNonQuery();

                    
                    string queryDeleteHopDong = "DELETE FROM HopDong WHERE HdID = @HdID";
                    SqlCommand cmdDeleteHopDong = new SqlCommand(queryDeleteHopDong, conn);
                    cmdDeleteHopDong.Parameters.AddWithValue("@HdID", hdId);
                    int rowsAffectedHopDong = cmdDeleteHopDong.ExecuteNonQuery();


                    // Kiểm tra xem đã xóa hợp đồng và HdID thành công hay không
                    if (rowsAffectedHopDong > 0)
                    {
                        MessageBox.Show("Xóa hợp đồng thành công từ bảng HopDong.");
                        LoadContractData(); // Cập nhật lại dữ liệu sau khi xóa
                    }
                    else
                    {
                        MessageBox.Show("Không có hợp đồng nào được xóa từ bảng HopDong hoặc không tìm thấy hợp đồng trong bảng HopDong.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
