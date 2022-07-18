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
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
            MainMenuForm mainForm = new MainMenuForm();
            mainForm.Show();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
        }

        private void StartupForm_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
