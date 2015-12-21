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
    public partial class frmSuaTaiKhoan : Form
    {
        public user u;

        public frmSuaTaiKhoan()
        {
            InitializeComponent();
        }

        private void frmSuaTaiKhoan_Load(object sender, EventArgs e)
        {
            txtTentaikhoan.Text = u.username;
            txtHovaten.Text = u.fullname;
            EnableBtnCreate();
        }

        private void txtMatkhau_Click(object sender, EventArgs e)
        {
            txtMatkhau.SelectAll();
            txtMatkhau.PasswordChar = '*';
        }

        private void txtXacnhanmatkhau_TextChanged(object sender, EventArgs e)
        {
            if (txtMatkhau.Text != txtXacnhanmatkhau.Text)
            {
                txtXacnhanmatkhau.BackColor = Color.Red;
            }
            else
            {
                txtXacnhanmatkhau.BackColor = SystemColors.Window;
            }

            EnableBtnCreate();
        }

        void EnableBtnCreate()
        {
            if (txtTentaikhoan.Text == string.Empty || txtTentaikhoan.BackColor == Color.Red || txtXacnhanmatkhau.BackColor == Color.Red || txtHovaten.Text == string.Empty)
            {
                btnCapNhat.Enabled = false;
            }
            else
            {
                btnCapNhat.Enabled = true;
            }
        }

        private void txtMatkhau_TextChanged(object sender, EventArgs e)
        {
            EnableBtnCreate();
        }

        private void txtHovaten_TextChanged(object sender, EventArgs e)
        {
            EnableBtnCreate();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMatkhau.Text != "Nhập nếu muốn thay đổi mật khẩu");
                u.password = Encrypt.SHA256(txtMatkhau.Text);
                u.fullname = txtHovaten.Text;

                bus.Update(u);
                MessageBox.Show("Cập nhật thành công", this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi trong quá trình cập nhật\r\n" + ex.Message, this.Text);
            }
        }
    }
}
