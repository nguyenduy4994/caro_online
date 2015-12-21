using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace client
{
    public partial class frmLogin : Form
    {
        public TcpClient Client;
        public NetworkStream ns;
        public StreamReader sr;
        public StreamWriter sw;

        public delegate void LoginDelegate();
        public void LoginComplete()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new LoginDelegate(LoginComplete));
            }
            else
            {
                string fullname = sr.ReadLine();
                frmGame frm = new frmGame();
                frm.Username = txtUser.Text;
                frm.Client = Client;
                frm.FormLogin = this;
                frm.Fullname = fullname;
                frm.ns = this.ns;
                frm.sr = this.sr;
                frm.sw = this.sw;
                frm.Text = txtUser.Text + " " + frm.Text;

                frm.Show();

                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Client = new TcpClient();
            Client.BeginConnect(txtHost.Text, 9999, ConnectCallback, Client);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            Client.EndConnect(ar);

            ns = Client.GetStream();
            sw = new StreamWriter(ns);
            sr = new StreamReader(ns);

            sw.AutoFlush = true;
            sw.WriteLine(txtUser.Text);
            sw.WriteLine(txtPass.Text);

            string checklog = sr.ReadLine();
            if (checklog == "successlogged")
            {
                LoginComplete();
            }
            else if(checklog == "wrong_pass")
            {
                MessageBox.Show("Sai tên đăng nhập hoặc password");
            }
            else 
            {
                MessageBox.Show("Vui lòng thử lại");
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            if (Dns.GetHostName() == "duy-laptop")
            {
                txtHost.Text = "127.0.0.1";
            }
            else
            {
                txtHost.Text = "172.20.10.6";
            }
        }
    }
}
