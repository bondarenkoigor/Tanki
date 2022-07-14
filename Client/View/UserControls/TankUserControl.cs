using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.View.UserControls
{
    public partial class TankUserControl : UserControl
    {
        public TankModel Tank { get; set; }
        public TankUserControl(TankModel tank)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Tank = tank;

            Task update = Task.Factory.StartNew(async () =>
            {
                while (true)
                {
                    this.UpdateTank();
                    await Task.Delay(100);
                }
            });
        }

        private void UpdateTank()
        {

            var tmp = new Bitmap(this.Tank.Image);
            if (this.Tank.Direction == "DOWN") tmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if (this.Tank.Direction == "RIGHT") tmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (this.Tank.Direction == "LEFT") tmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (this.BackgroundImage != tmp) this.BackgroundImage = tmp;
            if (this.Location != Tank.Location) this.Location = Tank.Location;
        }
    }
}
