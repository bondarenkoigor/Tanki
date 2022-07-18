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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void HPAddButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(HPCount.Text) >= 10) return;
            this.HPCount.Text = (int.Parse(this.HPCount.Text) + 1).ToString();
        }

        private void DamageAddButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(DamageCount.Text) >= 10) return;
            this.DamageCount.Text = (int.Parse(this.DamageCount.Text) + 1).ToString();

        }

        private void SpeedAddButton_Click(object sender, EventArgs e)
        {
            if (int.Parse(DamageCount.Text) >= 20) return;
            this.SpeedCount.Text = (int.Parse(this.SpeedCount.Text) + 1).ToString();

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }
    }
}
