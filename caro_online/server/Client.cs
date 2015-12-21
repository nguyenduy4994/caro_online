using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace server
{
    public class Client
    {
        public TcpClient tcpClient;
        public NetworkStream ns;
        public StreamReader reader;
        public StreamWriter writer;

        public frmServer FormServer;

        public string Username;
        public string Password;
        public bool IsPlaying = false;

        public Game game;

        public user User;

        public void ClientHandle(object state)
        {
            // writer auto flush data
            writer.AutoFlush = true;

            // read username
            Username = reader.ReadLine();
            Password = reader.ReadLine();

            // process username
            string respone = string.Empty;
            if (FormServer.Clients.ContainsKey(Username))
            {
                respone = "islogged"; // da dang nhap o dau do roi
            }
            else
            {
                if ((User = bus.Login(Username, Password)) != null)
                {
                    respone = "successlogged"; // dang nhap thanh cong
                    FormServer.Clients.Add(Username, this);
                    FormServer.Log(Username + " connected");

                    ThreadPool.QueueUserWorkItem(SendNewUserToAllClient);
                }
                else
                {
                    respone = "wrong_pass";
                }
                
            }

            // write back to client
            writer.WriteLine(respone);

            if (respone == "successlogged")
            {
                writer.WriteLine(User.fullname);
            }

            while (true)
            {
                string command;
                try
                {
                    command = reader.ReadLine();
                }
                catch (Exception ex)
                {
                    FormServer.Log(Username + " mất kết nối");
                    break;
                }
                
                switch (command)
                {
                    case "listuser":
                        Command_listuser();
                        break;
                    case "newgame":
                        Command_newgame();
                        break;
                    case "accept_game":
                        Command_accept_game();
                        break;
                    case "refuse_game":
                        Command_refuse_game();
                        break;
                    case "host_ready":
                        Command_host_ready();
                        break;
                    case "guest_ready":
                        Command_guest_ready();
                        break;
                    case "host_sign":
                        Command_host_sign();
                        break;
                    case "guest_sign":
                        Command_guest_sign();
                        break;
                }
            }

            
            reader.Close();
            writer.Close();
            ns.Close();
            tcpClient.Close();
        }
        
        private void Command_guest_sign()
        {
            int x = int.Parse(reader.ReadLine());
            int y = int.Parse(reader.ReadLine());

            game.table[x, y] = 2;
            game.host.writer.WriteLine("guest_sign");
            game.host.writer.WriteLine(x.ToString());
            game.host.writer.WriteLine(y.ToString());

            if (CheckGame(2, x, y, game.table))
            {
                game.host.writer.WriteLine("guest_win");
                game.guest.writer.WriteLine("guest_win");

                game.host.IsPlaying = false;
                game.guest.IsPlaying = false;
            }
        }

        private void Command_host_sign()
        {
            int x = int.Parse(reader.ReadLine());
            int y = int.Parse(reader.ReadLine());

            game.table[x, y] = 1;
            game.guest.writer.WriteLine("host_sign");
            game.guest.writer.WriteLine(x.ToString());
            game.guest.writer.WriteLine(y.ToString());

            if (CheckGame(1, x, y, game.table))
            {
                game.host.writer.WriteLine("host_win");
                game.guest.writer.WriteLine("host_win");

                game.host.IsPlaying = false;
                game.guest.IsPlaying = false;
            }
        }

        private bool CheckGame(int p, int x, int y, int[,] table)
        {
            if (Check_hangngang(p, x, y, table))
            {
                return true;
            }
            if (Check_hangdoc(p, x, y, table))
            {
                return true;
            }
            if (Check_cheochinh(p, x, y, table))
            {
                return true;
            }
            if (Check_cheophu(p, x, y, table))
            {
                return true;
            }

            return false;
        }

        private bool Check_hangngang(int p, int x, int y, int[,] table)
        {
            int count = 0;
            int n = table.GetLength(0);
            for (int i = 0; i < n - 1; i++)
            {
                if (table[i, y] == p && table[i + 1, y] == p)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        private bool Check_hangdoc(int p, int x, int y, int[,] table)
        {
            int count = 0;
            int m = table.GetLength(1);
            for (int i = 0; i < m - 1; i++)
            {
                if (table[x, i] == p && table[x, i + 1] == p)
                {
                    count++;

                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        private bool Check_cheochinh(int p, int x, int y, int[,] table)
        {
            int count = 0;
            int n = table.GetLength(0);
            int m = table.GetLength(1);

            int i = x - 4;
            int j = y - 4;

            if (i < 0)
            {
                j += -i;
                i = 0;
            }
            if (j < 0)
            {
                i += -j;
                j = 0;
            }

            for (int t = 0; t < 10; t++)
            {
                if (i + t + 1 >= n || j + t + 1 >= m) break;
                if(table[i + t, j + t] == p && table[i + t + 1, j + t + 1] == p)
                {
                    count++;
                    if (count == 4) return true;
                }
                else
                {
                    count = 0;
                }
            }
            return false;
        }

        private bool Check_cheophu(int p, int x, int y, int[,] table)
        {
            int count = 0;
            int n = table.GetLength(0);
            int m = table.GetLength(1);

            int i = x - 4;
            int j = y + 4;

            if (i < 0)
            {
                j += i;
                i = 0;
            }

            if (j >= m)
            {
                i += (j - m - 1);
                j = m - 1;
            }

            for (int t = 0; t < 10; t++)
            {
                if (i + t + 1 >= n || j - t - 1 < 0) break;
                if (table[i + t, j - t] == p && table[i + t + 1, j - t - 1] == p)
                {
                    count++;
                    if (count == 4)
                        return true;
                }
                else
                {
                    count = 0;
                }
            }

            return false;
        }

        private void Command_guest_ready()
        {
            string username = reader.ReadLine();
            Game _game = FormServer.Games[username];
            _game.host.writer.WriteLine("start_game");
            _game.host.writer.WriteLine(_game.host.Username);

            _game.guest.writer.WriteLine("start_game");
            _game.guest.writer.WriteLine(_game.host.Username);

            _game.host.IsPlaying = true;
            _game.guest.IsPlaying = true;

            this.game = _game;
            _game.guest.game = _game;
        }

        private void Command_host_ready()
        {
            string guest = reader.ReadLine();
            
            FormServer.Clients[guest].writer.WriteLine("join_game");
            FormServer.Clients[guest].writer.WriteLine(Username);
            
            game = new Game(this);
            game.guest = FormServer.Clients[guest];
            
            FormServer.Games.Add(Username, game);
        }

        private void Command_refuse_game()
        {
            string host = reader.ReadLine();
            FormServer.Clients[host].writer.WriteLine("refuse_game");
        }

        private void Command_accept_game()
        {
            string host = reader.ReadLine();
            FormServer.Clients[host].writer.WriteLine("accept_game");
        }

        private void Command_newgame()
        {
            string guest = reader.ReadLine();
            if (FormServer.Clients[guest].IsPlaying)
            {
                writer.WriteLine("guest_playing");
            }
            else
            {
                FormServer.Clients[guest].writer.WriteLine("newgame");
                FormServer.Clients[guest].writer.WriteLine(Username);
            }
        }

        private void SendNewUserToAllClient(object state)
        {
            foreach (KeyValuePair<string, Client> client in FormServer.Clients)
            {
                if (client.Value.Username == Username) continue;
                client.Value.writer.WriteLine("newuser");
                client.Value.writer.WriteLine(Username);
            }
        }

        // gui danh sach cac user
        private void Command_listuser()
        {
            writer.WriteLine("listuser");
            foreach (KeyValuePair<string, Client> client in FormServer.Clients)
            {
                writer.WriteLine(client.Key);
            }

            writer.WriteLine("__END__");
        }
    }
}
