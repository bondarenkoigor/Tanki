﻿using System;
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
        public int PlayerNum { get; set; } = 3;

        public MyServer()
        {
            Players = new List<Socket>();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234));
            socket.Listen(PlayerNum);

            for (int i = 0; i < PlayerNum; i++) Players.Add(socket.Accept());
            for (int i = 1; i <= PlayerNum; i++)
            {
                Players[i - 1].Send(Encoding.UTF8.GetBytes($"{PlayerNum}|{i}"));
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
            List<byte> bytes = new List<byte>();
            do
            {
                player.Receive(buffer);
                bytes.AddRange(buffer);
            } while (player.Available > 0);

            return Encoding.UTF8.GetString(bytes.ToArray()).Trim('\0');
        }
    }
}