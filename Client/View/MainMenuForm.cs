using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View
{
    public partial class MainMenuForm : Form
    {
        public int HP { get; set; } = 1;
        public int Damage { get; set; } = 1;
        public int Speed { get; set; } = 1;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var game = new GameForm(HP,Damage,Speed);
            game.Show();
            this.Close();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            var menu = new SettingsForm();
            menu.ShowDialog();
            menu.SaveButton.Click += (s, ev) =>
            {
                this.HP = int.Parse(menu.HPCount.Text);
                this.Damage = int.Parse(menu.DamageCount.Text);
                this.Speed = int.Parse(menu.SpeedCount.Text);
                menu.Close();
            };
        }

        private void QuitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {

        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
