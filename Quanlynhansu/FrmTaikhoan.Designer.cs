namespace Quanlynhansu
{
    partial class FrmTaikhoan
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BtThem = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.BtChinhsua = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCapnhat = new System.Windows.Forms.Button();
            this.CbbTennv = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDtaikhoan = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDnv = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 296);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(776, 150);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(56, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 23);
            this.label4.TabIndex = 23;
            this.label4.Text = "Tên nhân viên";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(56, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(56, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Tên đăng nhập";
            // 
            // BtThem
            // 
            this.BtThem.Location = new System.Drawing.Point(606, 65);
            this.BtThem.Name = "BtThem";
            this.BtThem.Size = new System.Drawing.Size(103, 34);
            this.BtThem.TabIndex = 27;
            this.BtThem.Text = "Thêm";
            this.BtThem.UseVisualStyleBackColor = true;
            this.BtThem.Click += new System.EventHandler(this.BtThem_Click);
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(606, 128);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(103, 34);
            this.btXoa.TabIndex = 30;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // BtChinhsua
            // 
            this.BtChinhsua.Location = new System.Drawing.Point(606, 188);
            this.BtChinhsua.Name = "BtChinhsua";
            this.BtChinhsua.Size = new System.Drawing.Size(103, 34);
            this.BtChinhsua.TabIndex = 31;
            this.BtChinhsua.Text = "Chỉnh sửa";
            this.BtChinhsua.UseVisualStyleBackColor = true;
            this.BtChinhsua.Click += new System.EventHandler(this.BtChinhsua_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(602, 452);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 34);
            this.button2.TabIndex = 32;
            this.button2.Text = "Đóng";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Location = new System.Drawing.Point(212, 147);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(293, 22);
            this.txtTendangnhap.TabIndex = 34;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(212, 192);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.Size = new System.Drawing.Size(293, 22);
            this.txtMatkhau.TabIndex = 35;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DeepPink;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(800, 48);
            this.label5.TabIndex = 37;
            this.label5.Text = "Bảng tài khoản";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCapnhat
            // 
            this.btnCapnhat.Location = new System.Drawing.Point(126, 452);
            this.btnCapnhat.Name = "btnCapnhat";
            this.btnCapnhat.Size = new System.Drawing.Size(103, 34);
            this.btnCapnhat.TabIndex = 38;
            this.btnCapnhat.Text = "Cập nhật";
            this.btnCapnhat.UseVisualStyleBackColor = true;
            this.btnCapnhat.Click += new System.EventHandler(this.btnCapnhat_Click);
            // 
            // CbbTennv
            // 
            this.CbbTennv.Location = new System.Drawing.Point(212, 65);
            this.CbbTennv.Name = "CbbTennv";
            this.CbbTennv.Size = new System.Drawing.Size(293, 24);
            this.CbbTennv.TabIndex = 0;
            this.CbbTennv.SelectedIndexChanged += new System.EventHandler(this.CbbTennv_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(56, 235);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "ID Tài khoản";
            // 
            // txtIDtaikhoan
            // 
            this.txtIDtaikhoan.AcceptsTab = true;
            this.txtIDtaikhoan.Location = new System.Drawing.Point(212, 235);
            this.txtIDtaikhoan.Name = "txtIDtaikhoan";
            this.txtIDtaikhoan.ReadOnly = true;
            this.txtIDtaikhoan.Size = new System.Drawing.Size(293, 22);
            this.txtIDtaikhoan.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(56, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 23);
            this.label6.TabIndex = 40;
            this.label6.Text = "ID nhân viên";
            // 
            // txtIDnv
            // 
            this.txtIDnv.Location = new System.Drawing.Point(212, 107);
            this.txtIDnv.Name = "txtIDnv";
            this.txtIDnv.Size = new System.Drawing.Size(293, 22);
            this.txtIDnv.TabIndex = 41;
            // 
            // FrmTaikhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 507);
            this.Controls.Add(this.txtIDnv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbbTennv);
            this.Controls.Add(this.btnCapnhat);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtIDtaikhoan);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTendangnhap);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BtChinhsua);
            this.Controls.Add(this.btXoa);
            this.Controls.Add(this.BtThem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmTaikhoan";
            this.Text = "FrmTaikhoan";
            this.Load += new System.EventHandler(this.FrmTaikhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BtThem;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button BtChinhsua;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCapnhat;
        private System.Windows.Forms.ComboBox CbbTennv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDtaikhoan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIDnv;
    }
}