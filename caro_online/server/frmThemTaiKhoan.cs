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
    public partial class frmThemTaiKhoan : Form
    {
        public frmThemTaiKhoan()
        {
            InitializeComponent();
        }

        void EnableBtnCreate()
        {
            if (txtTentaikhoan.Text == string.Empty || txtTentaikhoan.BackColor == Color.Red || txtXacnhanmatkhau.BackColor == Color.Red || txtHovaten.Text == string.Empty)
            {
                btnTao.Enabled = false;
            }
            else
            {
                btnTao.Enabled = true;
            }
        }

        private void txtTentaikhoan_TextChanged(object sender, EventArgs e)
        {
            if (bus.Exist(txtTentaikhoan.Text) || txtTentaikhoan.Text == string.Empty)
            {
                txtTentaikhoan.BackColor = Color.Red;
            }
            else
            {
                txtTentaikhoan.BackColor = SystemColors.Window;
            }

            EnableBtnCreate();
        }

        private void txtXacnhanmatkhau_TextChanged(object sender, EventArgs e)
        {
            if (txtXacnhanmatkhau.Text != txtMatkhau.Text)
            {
                txtXacnhanmatkhau.BackColor = Color.Red;
            }
            else
            {
                txtXacnhanmatkhau.BackColor = SystemColors.Window;
            }

            EnableBtnCreate();
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            user u = new user();
            u.username = txtTentaikhoan.Text;
            u.password = Encrypt.SHA256(txtMatkhau.Text);
            u.fullname = txtHovaten.Text;
            u.win = u.draw = u.lose = 0;
            try
            {
                bus.Create(u);
                MessageBox.Show("Tạo tài khoản thành công", this.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình tao\r\n"+ ex.Message, this.Text);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtHovaten_TextChanged(object sender, EventArgs e)
        {
            EnableBtnCreate();
        }
    }
}
