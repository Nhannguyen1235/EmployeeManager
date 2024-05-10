namespace WindowsFormsApp2
{
    partial class FrmDangnhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TbTaikhoan = new System.Windows.Forms.TextBox();
            this.TbMatkhau = new System.Windows.Forms.TextBox();
            this.BtDangnhap = new System.Windows.Forms.Button();
            this.BtDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(608, 113);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(89, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tài khoản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(89, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mât Khẩu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TbTaikhoan
            // 
            this.TbTaikhoan.Location = new System.Drawing.Point(219, 171);
            this.TbTaikhoan.Name = "TbTaikhoan";
            this.TbTaikhoan.Size = new System.Drawing.Size(260, 22);
            this.TbTaikhoan.TabIndex = 3;
            this.TbTaikhoan.TextChanged += new System.EventHandler(this.Tbten_TextChanged);
            this.TbTaikhoan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Tbten_KeyPress);
            // 
            // TbMatkhau
            // 
            this.TbMatkhau.Location = new System.Drawing.Point(219, 250);
            this.TbMatkhau.Name = "TbMatkhau";
            this.TbMatkhau.PasswordChar = '*';
            this.TbMatkhau.Size = new System.Drawing.Size(260, 22);
            this.TbMatkhau.TabIndex = 4;
            this.TbMatkhau.TextChanged += new System.EventHandler(this.TbMatkhau_TextChanged);
            this.TbMatkhau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbMatkhau_KeyPress);
            // 
            // BtDangnhap
            // 
            this.BtDangnhap.Location = new System.Drawing.Point(219, 362);
            this.BtDangnhap.Name = "BtDangnhap";
            this.BtDangnhap.Size = new System.Drawing.Size(103, 34);
            this.BtDangnhap.TabIndex = 5;
            this.BtDangnhap.Text = "Đăng nhập";
            this.BtDangnhap.UseVisualStyleBackColor = true;
            this.BtDangnhap.Click += new System.EventHandler(this.BtDangnhap_Click);
            // 
            // BtDong
            // 
            this.BtDong.Location = new System.Drawing.Point(441, 362);
            this.BtDong.Name = "BtDong";
            this.BtDong.Size = new System.Drawing.Size(85, 34);
            this.BtDong.TabIndex = 6;
            this.BtDong.Text = "Đóng";
            this.BtDong.UseVisualStyleBackColor = true;
            this.BtDong.Click += new System.EventHandler(this.BtDong_Click);
            // 
            // FrmDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 450);
            this.Controls.Add(this.BtDong);
            this.Controls.Add(this.BtDangnhap);
            this.Controls.Add(this.TbMatkhau);
            this.Controls.Add(this.TbTaikhoan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmDangnhap";
            this.Text = "Nguyễn Thành Nhân";
            this.Load += new System.EventHandler(this.FrmDangnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TbTaikhoan;
        private System.Windows.Forms.TextBox TbMatkhau;
        private System.Windows.Forms.Button BtDangnhap;
        private System.Windows.Forms.Button BtDong;
    }
}