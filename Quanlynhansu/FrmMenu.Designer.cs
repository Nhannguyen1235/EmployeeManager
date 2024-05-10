namespace Quanlynhansu
{
    partial class FrmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Nhanvien = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemPhongban = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemHopdongLD = new System.Windows.Forms.ToolStripMenuItem();
            this.ItemTaikhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmNhânViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hỗTrợToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.chứcNăngToolStripMenuItem,
            this.tìmKiếmNhânViênToolStripMenuItem,
            this.hỗTrợToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1192, 28);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("hệThốngToolStripMenuItem.Image")));
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(105, 24);
            this.hệThốngToolStripMenuItem.Text = "&Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("đăngXuấtToolStripMenuItem.Image")));
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thoátToolStripMenuItem.Image")));
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Nhanvien,
            this.ItemPhongban,
            this.ItemLuong,
            this.ItemHopdongLD,
            this.ItemTaikhoan});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.chứcNăngToolStripMenuItem.Text = "Quản lý";
            this.chứcNăngToolStripMenuItem.Click += new System.EventHandler(this.chứcNăngToolStripMenuItem_Click);
            // 
            // Nhanvien
            // 
            this.Nhanvien.Name = "Nhanvien";
            this.Nhanvien.Size = new System.Drawing.Size(224, 26);
            this.Nhanvien.Text = "Nhân viên";
            this.Nhanvien.Click += new System.EventHandler(this.Nhanvien_Click);
            // 
            // ItemPhongban
            // 
            this.ItemPhongban.Name = "ItemPhongban";
            this.ItemPhongban.Size = new System.Drawing.Size(224, 26);
            this.ItemPhongban.Text = "Phòng ban";
            this.ItemPhongban.Click += new System.EventHandler(this.ItemPhongban_Click);
            // 
            // ItemLuong
            // 
            this.ItemLuong.Name = "ItemLuong";
            this.ItemLuong.Size = new System.Drawing.Size(224, 26);
            this.ItemLuong.Text = "lương";
            this.ItemLuong.Click += new System.EventHandler(this.ItemLuong_Click);
            // 
            // ItemHopdongLD
            // 
            this.ItemHopdongLD.Name = "ItemHopdongLD";
            this.ItemHopdongLD.Size = new System.Drawing.Size(224, 26);
            this.ItemHopdongLD.Text = "Hợp đồng lao động";
            this.ItemHopdongLD.Click += new System.EventHandler(this.ItemHopdongLD_Click);
            // 
            // ItemTaikhoan
            // 
            this.ItemTaikhoan.Name = "ItemTaikhoan";
            this.ItemTaikhoan.Size = new System.Drawing.Size(224, 26);
            this.ItemTaikhoan.Text = "Tài khoản";
            this.ItemTaikhoan.Click += new System.EventHandler(this.ItemTaikhoan_Click);
            // 
            // tìmKiếmNhânViênToolStripMenuItem
            // 
            this.tìmKiếmNhânViênToolStripMenuItem.Name = "tìmKiếmNhânViênToolStripMenuItem";
            this.tìmKiếmNhânViênToolStripMenuItem.Size = new System.Drawing.Size(151, 24);
            this.tìmKiếmNhânViênToolStripMenuItem.Text = "Tìm kiếm nhân viên";
            this.tìmKiếmNhânViênToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmNhânViênToolStripMenuItem_Click);
            // 
            // hỗTrợToolStripMenuItem
            // 
            this.hỗTrợToolStripMenuItem.Name = "hỗTrợToolStripMenuItem";
            this.hỗTrợToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.hỗTrợToolStripMenuItem.Text = "Hỗ trợ";
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 445);
            this.Controls.Add(this.menuStrip2);
            this.Name = "FrmMenu";
            this.Text = "Menu";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Nhanvien;
        private System.Windows.Forms.ToolStripMenuItem hỗTrợToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ItemPhongban;
        private System.Windows.Forms.ToolStripMenuItem ItemLuong;
        private System.Windows.Forms.ToolStripMenuItem ItemHopdongLD;
        private System.Windows.Forms.ToolStripMenuItem ItemTaikhoan;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmNhânViênToolStripMenuItem;
    }
}

