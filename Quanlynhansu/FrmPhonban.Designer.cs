namespace Quanlynhansu
{
    partial class FrmPhonban
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtIDphongban = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenpb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btncapnhap = new System.Windows.Forms.Button();
            this.btDong = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btChinhsua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.CbbTennv = new System.Windows.Forms.ComboBox();
            this.txtIdnv = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(800, 71);
            this.label3.TabIndex = 33;
            this.label3.Text = "Bảng phòng ban";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtIDphongban
            // 
            this.txtIDphongban.Location = new System.Drawing.Point(327, 99);
            this.txtIDphongban.Name = "txtIDphongban";
            this.txtIDphongban.Size = new System.Drawing.Size(204, 22);
            this.txtIDphongban.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(152, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 32);
            this.label1.TabIndex = 34;
            this.label1.Text = "ID phòng ban";
            // 
            // txtTenpb
            // 
            this.txtTenpb.Location = new System.Drawing.Point(327, 150);
            this.txtTenpb.Name = "txtTenpb";
            this.txtTenpb.Size = new System.Drawing.Size(204, 22);
            this.txtTenpb.TabIndex = 37;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(152, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 32);
            this.label2.TabIndex = 36;
            this.label2.Text = "Tên phòng ban";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(152, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(169, 32);
            this.label4.TabIndex = 38;
            this.label4.Text = "Tên quản lý";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(124, 313);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(557, 150);
            this.dataGridView1.TabIndex = 40;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // btncapnhap
            // 
            this.btncapnhap.Location = new System.Drawing.Point(687, 93);
            this.btncapnhap.Name = "btncapnhap";
            this.btncapnhap.Size = new System.Drawing.Size(103, 34);
            this.btncapnhap.TabIndex = 50;
            this.btncapnhap.Text = "Cập nhật";
            this.btncapnhap.UseVisualStyleBackColor = true;
            this.btncapnhap.Click += new System.EventHandler(this.btncapnhap_Click);
            // 
            // btDong
            // 
            this.btDong.Location = new System.Drawing.Point(687, 150);
            this.btDong.Name = "btDong";
            this.btDong.Size = new System.Drawing.Size(103, 34);
            this.btDong.TabIndex = 49;
            this.btDong.Text = "Đóng";
            this.btDong.UseVisualStyleBackColor = true;
            this.btDong.Click += new System.EventHandler(this.btDong_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(578, 193);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(103, 34);
            this.btnXoa.TabIndex = 48;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btChinhsua
            // 
            this.btChinhsua.Location = new System.Drawing.Point(578, 147);
            this.btChinhsua.Name = "btChinhsua";
            this.btChinhsua.Size = new System.Drawing.Size(103, 34);
            this.btChinhsua.TabIndex = 47;
            this.btChinhsua.Text = "Chỉnh sửa";
            this.btChinhsua.UseVisualStyleBackColor = true;
            this.btChinhsua.Click += new System.EventHandler(this.btChinhsua_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(578, 93);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(103, 34);
            this.btThem.TabIndex = 46;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // CbbTennv
            // 
            this.CbbTennv.FormattingEnabled = true;
            this.CbbTennv.Location = new System.Drawing.Point(327, 199);
            this.CbbTennv.Name = "CbbTennv";
            this.CbbTennv.Size = new System.Drawing.Size(204, 24);
            this.CbbTennv.TabIndex = 51;
            this.CbbTennv.SelectedIndexChanged += new System.EventHandler(this.CbbTennv_SelectedIndexChanged);
            // 
            // txtIdnv
            // 
            this.txtIdnv.Location = new System.Drawing.Point(327, 247);
            this.txtIdnv.Name = "txtIdnv";
            this.txtIdnv.Size = new System.Drawing.Size(204, 22);
            this.txtIdnv.TabIndex = 53;
            this.txtIdnv.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.Location = new System.Drawing.Point(152, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 32);
            this.label5.TabIndex = 52;
            this.label5.Text = "ID quản lý";
            // 
            // FrmPhonban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.txtIdnv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CbbTennv);
            this.Controls.Add(this.btncapnhap);
            this.Controls.Add(this.btDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btChinhsua);
            this.Controls.Add(this.btThem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTenpb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDphongban);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Name = "FrmPhonban";
            this.Text = "FrmPhonban";
            this.Load += new System.EventHandler(this.FrmPhonban_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIDphongban;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenpb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btncapnhap;
        private System.Windows.Forms.Button btDong;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btChinhsua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.ComboBox CbbTennv;
        private System.Windows.Forms.TextBox txtIdnv;
        private System.Windows.Forms.Label label5;
    }
}