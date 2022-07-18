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
using Microsoft.VisualBasic;

namespace Client.Control
{
    public static class Controller
    {
        public static TankModel PlayerTank { get; set; }
        public static List<TankModel> OtherPlayers { get; set; } = new List<TankModel>();
        public static Socket ClientSocket { get; set; }

        public static event EventHandler gameStarted;

        public static void Start(int hp, int damage, int speed)
        {
            Random random = new Random();
            ClientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            ClientSocket.Connect(IPAddress.Parse("127.0.0.1"), 1234);
            string[] playerInfo = ReceiveString().Split('|');
            PlayerTank = new TankModel(int.Parse(playerInfo[1]), new Point(random.Next(0, 800), random.Next(0, 400)), "UP");
            PlayerTank.Health = hp;
            PlayerTank.Damage = damage;
            PlayerTank.Speed = speed;
            

            Task task = Task.Factory.StartNew(async () =>
            {
                int playerCount = 4;
                if (playerInfo[0] == "ENTER PLAYER COUNT")
                {
                    string inputBoxResult = "";
                    do
                    {
                        inputBoxResult = Interaction.InputBox("Enter player count");
                    } while (!(int.TryParse(inputBoxResult, out playerCount) && playerCount > 1 && playerCount < 5));
                    ClientSocket.Send(Encoding.UTF8.GetBytes(inputBoxResult));
                    ReceiveString(); //confirmation

                }
                else
                {
                    playerCount = int.Parse(playerInfo[0]);
                }
                for (int i = 1; i <= playerCount; i++)
                    if (i != PlayerTank.PlayerNum) OtherPlayers.Add(new TankModel(i, new Point(100, 100), "UP"));

                gameStarted?.Invoke(null, EventArgs.Empty);
                while (true)
                {
                    try
                    {


                        string json = JsonSerializer.Serialize(PlayerTank.ToJsonModel());
                        ClientSocket.Send(Encoding.UTF8.GetBytes(json));
                        await Task.Delay(100);
                        string[] otherJsons = ReceiveString().Split('|');
                        foreach (var otherJson in otherJsons)
                        {
                            try
                            {
                                var deserialized = JsonSerializer.Deserialize<JsonTankModel>(otherJson.Split('\n')[0]);
                                var found = OtherPlayers.Find(p => p.PlayerNum == deserialized.PlayerNum);
                                if (found != null) found.Update(deserialized);
                            }
                            catch (Exception ex) { MessageBox.Show(ex.Message); }
                        }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
            });
        }

        private static string ReceiveString()
        {
            byte[] buffer = new byte[256];
            int byteCount = 0;
            StringBuilder sb = new StringBuilder();
            do
            {
                byteCount = ClientSocket.Receive(buffer);
                sb.Append(Encoding.UTF8.GetString(buffer, 0, byteCount));
            } while (ClientSocket.Available > 0);
            return sb.ToString();
        }
    }
}
