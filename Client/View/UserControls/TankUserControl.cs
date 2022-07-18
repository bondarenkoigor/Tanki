using Client.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            Image img;
            if(Tank.IsDead) img = Image.FromFile($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Resources\\DeadTank.png");
            else if(Tank.IsTakingDamage) img = Image.FromFile($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Resources\\TankTakingDamage.png");
            else if (Tank.IsShooting) img = Image.FromFile($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Resources\\ShootingTank.png");
            else img = Image.FromFile($"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName}\\Resources\\Tank.png");

            if (this.Tank.Direction == "DOWN") img.RotateFlip(RotateFlipType.Rotate180FlipNone);
            else if (this.Tank.Direction == "RIGHT") img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            else if (this.Tank.Direction == "LEFT") img.RotateFlip(RotateFlipType.Rotate270FlipNone);

            if (this.BackgroundImage != img) this.BackgroundImage = img;
            if (this.Location != Tank.Location) this.Location = Tank.Location;
        }
    }
}
