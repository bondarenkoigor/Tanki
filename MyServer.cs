using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class MyServer
    {
        public List<Socket> Players { get; set; }
        public Socket socket { get; set; }
        public int PlayerCount { get; set; } = 4;

        public MyServer()
        {
            Players = new List<Socket>();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
            socket.Listen(PlayerCount);

            //for (int i = 0; i < PlayerCount; i++) Players.Add(socket.Accept());
            //for (int i = 1; i <= PlayerCount; i++)
            //{
            //    Players[i - 1].Send(Encoding.UTF8.GetBytes($"{PlayerCount}|{i}"));
            //}

            for (int i = 1; i <= PlayerCount; i++)
            {
                Players.Add(socket.Accept());
                if (i == 1)
                {
                    Players[i - 1].Send(Encoding.UTF8.GetBytes($"ENTER PLAYER COUNT|{i}"));
                    PlayerCount = int.Parse(ReceiveString(Players[i - 1]));
                    Players[i - 1].Send(Encoding.UTF8.GetBytes("confirmation"));
                }
                else
                    Players[i - 1].Send(Encoding.UTF8.GetBytes($"{PlayerCount}|{i}"));
            }

            Task task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    List<string> jsons = new List<string>();
                    foreach (var player in Players)
                    {
                        jsons.Add(ReceiveString(player));
                    }
                    string result = String.Join("|", jsons);
                    foreach (var player in Players)
                    {
                        player.Send(Encoding.UTF8.GetBytes(result));
                    }
                }
            });
        }

        private string ReceiveString(Socket player)
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = player.Receive(buffer);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, byteCount));
            } while (socket.Available > 0);
            return sb.ToString();
        }
    }
}
