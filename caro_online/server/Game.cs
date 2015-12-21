using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace server
{
    public class Game
    {
        // nguoi tao game
        public Client host;

        // nguoi choi duoc moi
        public Client guest;

        // ban co 
        public int[,] table;

        // constructor
        public Game(Client pHost)
        {
            host = pHost;
            table = new int[18, 15];
        }
    }
}
