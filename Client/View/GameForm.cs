using Client.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.View.UserControls;
using System.Windows.Input;

namespace Client.View
{
    public partial class GameForm : Form
    {
        public GameForm(int hp, int damage, int speed)
        {
            InitializeComponent();
            Controller.Start(hp, damage, speed);


            this.DoubleBuffered = true;
            this.Controls.Add(new TankUserControl(Controller.PlayerTank));
            Controller.gameStarted += (sender, e) =>
            {
                foreach (var player in Controller.OtherPlayers)
                    this.BeginInvoke(new Action(() =>
                    {
                        this.Controls.Add(new TankUserControl(player));
                    }));
            };
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Controller.PlayerTank.IsDead) return;

            if (e.KeyChar == ' ') Controller.PlayerTank.Shoot();

            if (e.KeyChar == 'w') Controller.PlayerTank.Direction = "UP";
            else if (e.KeyChar == 's') Controller.PlayerTank.Direction = "DOWN";
            else if (e.KeyChar == 'd') Controller.PlayerTank.Direction = "RIGHT";
            else if (e.KeyChar == 'a') Controller.PlayerTank.Direction = "LEFT";
            else return;

            Controller.PlayerTank.Move();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}
