using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace server
{
    public partial class frmDanhSachTaiKhoan : Form
    {
        public frmDanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmDanhSachTaiKhoan_Load(object sender, EventArgs e)
        {
            dgvDanhSach.AutoGenerateColumns = false;
            dgvDanhSach.DataSource = bus.GetList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan frm = new frmThemTaiKhoan();
            frm.ShowDialog();
            dgvDanhSach.DataSource = bus.GetList();
        }

        private void dgvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDanhSach.SelectedRows.Count != 1) return;

            user u = (user)dgvDanhSach.SelectedRows[0].DataBoundItem;
            frmSuaTaiKhoan frm = new frmSuaTaiKhoan();
            frm.u = u;
            frm.ShowDialog();
            dgvDanhSach.DataSource = bus.GetList();
        }
    }
}
