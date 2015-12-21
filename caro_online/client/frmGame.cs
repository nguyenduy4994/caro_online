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
    public partial class frmGame : Form
    {
        public TcpClient Client;
        public NetworkStream ns;
        public StreamReader sr;
        public StreamWriter sw;
        public frmLogin FormLogin;
        public string Username;
        public string GuestUsername;
        public bool ToiLuot = false;
        public bool IsHost = false;
        public string sign;

        public int level;

        Graphics g;
        Bitmap bitmap;

        int[,] table = new int[18, 15];

        public frmGame()
        {
            InitializeComponent();

            bitmap = new Bitmap(picBanCo.Width, picBanCo.Height);
            g = Graphics.FromImage(picBanCo.Image);
        }

        private void frmGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormLogin.Show();
            FormLogin.WindowState = FormWindowState.Normal;
        }

        private void frmGame_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(RequestGetUserList);
            ThreadPool.QueueUserWorkItem(ClientCommandHandle);

            txtUsername.Text = Fullname;
        }

        public delegate void AddListDelegate(string username);
        public void AddList(string username)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new AddListDelegate(AddList), new object[] { username });
            }
            else
            {
                lstNguoiChoiOnline.Items.Add(username);
            }
        }

        void RequestGetUserList(object state)
        {
            // gui yeu cau danh sach user
            sw.WriteLine("listuser");
        }

        void ClientCommandHandle(object state)
        {
            while (true)
            {
                string command = sr.ReadLine();
                switch (command)
                {
                    case "listuser": // tra ve danh sach user
                        Command_listuser();
                        break;
                    case "newuser": // co nguoi choi moi dang nhap vao
                        Command_newuser();
                        break;
                    case "guest_playing": // nguoi choi duoc moi dang choi
                        Command_guest_playing();
                        break;
                    case "newgame": // co nguoi moi choi game
                        Command_newgame();
                        break;
                    case "accept_game": // nguoi choi dong y choi game
                        Command_accept_game();
                        break;
                    case "refuse_game": // nguoi choi tu choi choi game
                        Command_refuse_game();
                        break;
                    case "join_game": // start game
                        Command_join_game();
                        break;
                    case "start_game": // start game 
                        Command_start_game();
                        break;
                    case "host_sign":
                        Command_host_sign();
                        break;
                    case "guest_sign":
                        Command_guest_sign();
                        break;
                    case "host_win":
                        Command_host_win();
                        break;
                    case "guest_win":
                        Command_guest_win();
                        break;
                }
            }
        }

        private void Command_guest_win()
        {
            ResetGame();
            // Thông báo game đã kết thúc
            if (IsHost)
            {
                MessageBox.Show("Thất bại!" + GuestUsername + " đã giành chiến thắng");
            }
            else
            {
                MessageBox.Show("Chúc mừng bạn đã chiến thắng");
            }

            
        }

        private void ResetGame()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeLabelUserDelegate(ResetGame));
            }
            else
            {
                this.lblNguoiChoi.Text = string.Empty;
                this.btnMoiChoi.Enabled = true;
                this.lstNguoiChoiOnline.Enabled = true;
                this.btnXinHoa.Enabled = false;
                this.btnXinThua.Enabled = false;
                this.picBanCo.Enabled = false;
                this.picBanCo.Image = Properties.Resources.caro;

                g = Graphics.FromImage(picBanCo.Image);
            }
        }

        private void Command_host_win()
        {
            ResetGame();
            // Thông báo game đã kết thúc
            if (IsHost)
            {
                MessageBox.Show("Chúc mừng bạn đã chiến thắng");
            }
            else
            {
                MessageBox.Show("Thất bại!" + GuestUsername + " đã giành chiến thắng");
            }

            
        }

        private void Command_guest_sign()
        {
            int x = int.Parse(sr.ReadLine());
            int y = int.Parse(sr.ReadLine());
            table[x, y] = 2;
            DrawSign("O", x, y);

            ToiLuot = true;
        }

        private void Command_host_sign()
        {
            int x = int.Parse(sr.ReadLine());
            int y = int.Parse(sr.ReadLine());
            table[x, y] = 1;
            DrawSign("X", x, y);

            ToiLuot = true;
        }

        private void Command_start_game()
        {
            ChangeLabelUser();

            string user = sr.ReadLine(); // nguoi choi dau tien
            if (user == Username)
            {
                ToiLuot = true;
                sign = "X";
                IsHost = true;
                MessageBox.Show("Mời bạn chơi đầu tiên", this.Text);
            }
            else
            {
                sign = "O";
            }
        }

        private void Command_join_game()
        {
            picBanCo.Enabled = true;
            GuestUsername = sr.ReadLine();
            sw.WriteLine("guest_ready");
            sw.WriteLine(GuestUsername); // luc nay la Hostusername
        }

        private void Command_refuse_game()
        {
            MessageBox.Show("Người chơi từ chối lời mời của bạn", this.Text);
            btnMoiChoi.Enabled = true;
        }

        private void Command_accept_game()
        {
            picBanCo.Enabled = true;
            sw.WriteLine("host_ready");
            sw.WriteLine(GuestUsername);
            ChangeLabelUser();
        }

        public delegate void ChangeLabelUserDelegate();
        public void ChangeLabelUser()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new ChangeLabelUserDelegate(ChangeLabelUser));
            }
            else
            {
                this.lblNguoiChoi.Text = Username + " vs " + GuestUsername;
                this.btnMoiChoi.Enabled = false;
                this.lstNguoiChoiOnline.Enabled = false;
                this.btnXinHoa.Enabled = true;
                this.btnXinThua.Enabled = true;
                this.picBanCo.Enabled = true;
            }
        }

        private void Command_newgame()
        {
            string host = sr.ReadLine();
            DialogResult r = MessageBox.Show(host + " mời bạn chơi game. Bạn có muốn tham gia không?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.Yes)
            {
                sw.WriteLine("accept_game");
            }
            else
            {
                sw.WriteLine("refuse_game");
            }

            sw.WriteLine(host);
        }

        private void Command_guest_playing()
        {
            MessageBox.Show("Người chơi đang chơi do đó không thể mời khách", this.Text);
        }

        private void Command_newuser()
        {
            string username = sr.ReadLine();
            AddList(username);
        }

        private void Command_listuser()
        {
            // lay danh sach user
            while (true)
            {
                string username = sr.ReadLine();
                if (username == "__END__") break;

                // them user vao list
                AddList(username);
            }
        }

        private void btnMoiChoi_Click(object sender, EventArgs e)
        {
            sw.WriteLine("newgame");
            sw.WriteLine(GuestUsername);

            btnMoiChoi.Enabled = false;
        }

        private void lstNguoiChoiOnline_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuestUsername = lstNguoiChoiOnline.SelectedItem.ToString();
            btnMoiChoi.Enabled = !(GuestUsername == this.Username);
        }

        private void picBanCo_Click(object sender, EventArgs e)
        {
            if (ToiLuot == false)
            {
                MessageBox.Show("Chưa tới lượt bạn mà, gấp quá hà", this.Text);
                return;
            }

            
            Point p =  picBanCo.PointToClient(Cursor.Position);
            int x = (int)(p.X / 32);
            int y = (int)(p.Y / 32);

            if (table[x, y] != 0)
            {
                MessageBox.Show("Ô đã chọn rồi, vui lòng chọn ô khác", this.Text);
                return;
            }
            
            if (IsHost)
            {
                sw.WriteLine("host_sign");
                table[x, y] = 1;
            }
            else
            {
                sw.WriteLine("guest_sign");
                table[x, y] = 2;
            }

            sw.WriteLine(x.ToString());
            sw.WriteLine(y.ToString());

            DrawSign(sign, x, y);
            ToiLuot = false;
        }

        void DrawSign(string s, int x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new DrawBanCoDelegate(DrawSign), new object[] { s, x, y });
            }
            else
            {
                g.DrawString(s, new Font("Tahoma", 32), Brushes.Black, new Point(x * 32, y * 32));
                picBanCo.Refresh();
            }
            
        }

        delegate void DrawBanCoDelegate(string s, int x, int y);


        public string Fullname;
    }
}
