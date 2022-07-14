using Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Client.Control
{
    internal class Controller
    {
        public TankModel PlayerTank { get; set; }
        public List<TankModel> OtherPlayers { get; set; } = new List<TankModel>();
        public Socket ClientSocket { get; set; }

        public Controller()
        {
            Random random = new Random();
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), 1234);

            string[] playerInfo = ReceiveString().Split('|');
            int playerCount = int.Parse(playerInfo[0]);
            PlayerTank = new TankModel(int.Parse(playerInfo[1]), new Point(random.Next(0, 800), random.Next(0, 400)), "UP");
            for (int i = 1; i <= playerCount; i++)
                if (i != PlayerTank.PlayerNum) OtherPlayers.Add(new TankModel(i, new Point(0, 0), "UP"));


            Task task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    try
                    {
                        string json = JsonSerializer.Serialize(PlayerTank.ToJsonModel());
                        ClientSocket.Send(Encoding.UTF8.GetBytes(json));
                        string[] otherJsons = ReceiveString().Split('|');
                        foreach (var otherJson in otherJsons)
                        {
                            try
                            {
                                var deserialized = JsonSerializer.Deserialize<JsonTankModel>(otherJson);
                                var found = OtherPlayers.Find(p => p.PlayerNum == deserialized.PlayerNum);
                                if (found != null) found.Update(deserialized);
                            }
                            catch(Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
            });
        }

        private string ReceiveString()
        {
            byte[] buffer = new byte[256];
            List<byte> bytes = new List<byte>();
            do
            {
                ClientSocket.Receive(buffer);
                bytes.AddRange(buffer);
            } while (ClientSocket.Available > 0);

            return Encoding.UTF8.GetString(bytes.ToArray()).Replace("\0", "");
        }
    }
}
