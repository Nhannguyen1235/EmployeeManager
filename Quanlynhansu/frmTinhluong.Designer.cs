namespace WindowsFormsApp2
{
    partial class frmTinhluong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtLuongcoban = new System.Windows.Forms.TextBox();
            this.btThem = new System.Windows.Forms.Button();
            this.btChinhsua = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtphucap = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNgaylam = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btncapnhap = new System.Windows.Forms.Button();
            this.CbbTennv = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLuongtong = new System.Windows.Forms.TextBox();
            this.txtIDnv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpThoigian = new System.Windows.Forms.DateTimePicker();
            this.txtNgaynghi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(76, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lương cơ bản";
            // 
            // txtLuongcoban
            // 
            this.txtLuongcoban.Location = new System.Drawing.Point(220, 87);
            this.txtLuongcoban.Name = "txtLuongcoban";
            this.txtLuongcoban.Size = new System.Drawing.Size(204, 22);
            this.txtLuongcoban.TabIndex = 27;
            this.txtLuongcoban.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHesoluong_KeyPress);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(874, 87);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(103, 34);
            this.btThem.TabIndex = 28;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThemnv_Click);
            // 
            // btChinhsua
            // 
            this.btChinhsua.Location = new System.Drawing.Point(874, 141);
            this.btChinhsua.Name = "btChinhsua";
            this.btChinhsua.Size = new System.Drawing.Size(103, 34);
            this.btChinhsua.TabIndex = 29;
            this.btChinhsua.Text = "Chỉnh sửa";
            this.btChinhsua.UseVisualStyleBackColor = true;
            this.btChinhsua.Click += new System.EventHandler(this.btChinhsua_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(874, 187);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(103, 34);
            this.btXoa.TabIndex = 30;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btDong
            // 
            this.btDong.Location = new System.Drawing.Point(874, 296);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(103, 34);
            this.btDong.TabIndex = 31;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = true;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1024, 71);
            this.label3.TabIndex = 32;
            this.label3.Text = "Bảng thông tin lương nhân viên";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtphucap
            // 
            this.txtphucap.Location = new System.Drawing.Point(220, 141);
            this.txtphucap.Name = "txtphucap";
            this.txtphucap.Size = new System.Drawing.Size(110, 22);
            this.txtphucap.TabIndex = 37;
            this.txtphucap.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(76, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 32);
            this.label4.TabIndex = 36;
            this.label4.Text = "Phụ cấp";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(430, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 32);
            this.label5.TabIndex = 38;
            this.label5.Text = "Tên nhân viên";
            // 
            // txtNgaylam
            // 
            this.txtNgaylam.Location = new System.Drawing.Point(470, 141);
            this.txtNgaylam.Name = "txtNgaylam";
            this.txtNgaylam.Size = new System.Drawing.Size(94, 22);
            this.txtNgaylam.TabIndex = 41;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(349, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 32);
            this.label6.TabIndex = 40;
            this.label6.Text = "Ngày làm";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(80, 273);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(717, 225);
            this.dataGridView1.TabIndex = 44;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btncapnhap
            // 
            this.btncapnhap.Location = new System.Drawing.Point(874, 235);
            this.btncapnhap.Name = "btncapnhap";
            this.btncapnhap.Size = new System.Drawing.Size(103, 34);
            this.btncapnhap.TabIndex = 45;
            this.btncapnhap.Text = "Cập nhật";
            this.btncapnhap.UseVisualStyleBackColor = true;
            this.btncapnhap.Click += new System.EventHandler(this.btncapnhap_Click);
            // 
            // CbbTennv
            // 
            this.CbbTennv.FormattingEnabled = true;
            this.CbbTennv.Location = new System.Drawing.Point(593, 87);
            this.CbbTennv.Name = "CbbTennv";
            this.CbbTennv.Size = new System.Drawing.Size(245, 24);
            this.CbbTennv.TabIndex = 46;
            this.CbbTennv.SelectedIndexChanged += new System.EventHandler(this.CbbIDnv_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(76, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 32);
            this.label8.TabIndex = 47;
            this.label8.Text = "Tổng";
            // 
            // txtLuongtong
            // 
            this.txtLuongtong.Location = new System.Drawing.Point(220, 224);
            this.txtLuongtong.Name = "txtLuongtong";
            this.txtLuongtong.ReadOnly = true;
            this.txtLuongtong.Size = new System.Drawing.Size(577, 22);
            this.txtLuongtong.TabIndex = 48;
            // 
            // txtIDnv
            // 
            this.txtIDnv.Location = new System.Drawing.Point(593, 187);
            this.txtIDnv.Name = "txtIDnv";
            this.txtIDnv.ReadOnly = true;
            this.txtIDnv.Size = new System.Drawing.Size(245, 22);
            this.txtIDnv.TabIndex = 50;
            this.txtIDnv.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(430, 187);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(302, 32);
            this.label2.TabIndex = 49;
            this.label2.Text = "ID nhân viên";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(76, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 32);
            this.label7.TabIndex = 51;
            this.label7.Text = "Thời gian";
            // 
            // dtpThoigian
            // 
            this.dtpThoigian.Location = new System.Drawing.Point(220, 187);
            this.dtpThoigian.Name = "dtpThoigian";
            this.dtpThoigian.Size = new System.Drawing.Size(200, 22);
            this.dtpThoigian.TabIndex = 52;
            // 
            // txtNgaynghi
            // 
            this.txtNgaynghi.Location = new System.Drawing.Point(744, 141);
            this.txtNgaynghi.Name = "txtNgaynghi";
            this.txtNgaynghi.Size = new System.Drawing.Size(94, 22);
            this.txtNgaynghi.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(589, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(143, 32);
            this.label9.TabIndex = 53;
            this.label9.Text = "Ngày nghỉ";
            // 
            // frmTinhluong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 510);
            this.Controls.Add(this.txtNgaynghi);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpThoigian);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIDnv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLuongtong);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CbbTennv);
            this.Controls.Add(this.btncapnhap);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtNgaylam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtphucap);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.btChinhsua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.txtLuongcoban);
            this.Controls.Add(this.label1);
            this.Name = "frmTinhluong";
            this.Text = "frmTinhluong";
            this.Load += new System.EventHandler(this.frmTinhluong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLuongcoban;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Button btChinhsua;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btDong;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtphucap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNgaylam;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btncapnhap;
        private System.Windows.Forms.ComboBox CbbTennv;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLuongtong;
        private System.Windows.Forms.TextBox txtIDnv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpThoigian;
        private System.Windows.Forms.TextBox txtNgaynghi;
        private System.Windows.Forms.Label label9;
    }
}