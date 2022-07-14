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

namespace Client
{
    public partial class Form1 : Form
    {
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Controls.Add(new TankUserControl(this.controller.PlayerTank));
            foreach (var player in controller.OtherPlayers) this.Controls.Add(new TankUserControl(player));
        }






        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == ' ') this.controller.PlayerTank.Shoot();

            if (e.KeyChar == 'w') this.controller.PlayerTank.Direction = "UP";
            else if (e.KeyChar == 's') this.controller.PlayerTank.Direction = "DOWN";
            else if (e.KeyChar == 'd') this.controller.PlayerTank.Direction = "RIGHT";
            else if (e.KeyChar == 'a') this.controller.PlayerTank.Direction = "LEFT";
            else return;

            controller.PlayerTank.Move();
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Space) 
        }
    }
}
