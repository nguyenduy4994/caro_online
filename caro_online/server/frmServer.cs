using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;

namespace server
{
    public partial class frmServer : Form
    {
        public TcpListener Server;
        public Dictionary<string, Client> Clients;
        public Dictionary<string, Game> Games;

        public delegate void WriteLogDelegate(string pString);
        public void Log(string pString)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new WriteLogDelegate(Log), new object[] { pString });
            }
            else
            {
                rLog.Text += pString + "\r\n";
            }
        }

        public frmServer()
        {
            InitializeComponent();

            Clients = new Dictionary<string, Client>();
            Games = new Dictionary<string, Game>();

            Server = new TcpListener(IPAddress.Any, 9999);
            Server.Start();
            Server.BeginAcceptTcpClient(AcceptCallback, Server);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            Server.BeginAcceptTcpClient(AcceptCallback, Server);
            TcpClient tcpClient = Server.EndAcceptTcpClient(ar);
            Client client = new Client();
            client.tcpClient = tcpClient;
            client.ns = tcpClient.GetStream();
            client.reader = new StreamReader(client.ns);
            client.writer = new StreamWriter(client.ns);
            client.FormServer = this;
            ThreadPool.QueueUserWorkItem(client.ClientHandle, client);
        }

        private void toolDanhSach_Click(object sender, EventArgs e)
        {
            frmDanhSachTaiKhoan frm = new frmDanhSachTaiKhoan();
            frm.ShowDialog();
        }

        private void toolThemNguoiDung_Click(object sender, EventArgs e)
        {
            frmThemTaiKhoan frm = new frmThemTaiKhoan();
            frm.ShowDialog();
        }
    }
}
