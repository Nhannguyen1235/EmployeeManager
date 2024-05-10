using System;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace Quanlynhansu
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void Nhanvien_Click(object sender, EventArgs e)
        {
            FrmQuanlynv frmQuanlynv = new FrmQuanlynv();
            frmQuanlynv.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void chứcNăngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tìmKiếmNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmtimkiem frmtimkiem = new frmtimkiem();
            frmtimkiem.ShowDialog();
        }

        private void ItemTaikhoan_Click(object sender, EventArgs e)
        {
            FrmTaikhoan frmTaikhoan = new FrmTaikhoan();
            frmTaikhoan.ShowDialog();
        }

        private void ItemLuong_Click(object sender, EventArgs e)
        {
            frmTinhluong frmTinhluong = new frmTinhluong();
            frmTinhluong.ShowDialog();
        }

        private void ItemPhongban_Click(object sender, EventArgs e)
        {
            FrmPhonban frm = new FrmPhonban();
            frm.ShowDialog();
        }

        private void ItemHopdongLD_Click(object sender, EventArgs e)
        {
            FrmHopdongLD frm = new FrmHopdongLD();
            frm.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmDangnhap frmDangnhap = new FrmDangnhap();
            frmDangnhap.ShowDialog();
        }
    }
}
