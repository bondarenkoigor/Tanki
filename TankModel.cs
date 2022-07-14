using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class TankModel
    {
        public int PlayerNum { get; set; }
        public Point Location { get; set; }
        public string Direction { get; set; } = "UP";
        public Image Image { get; set; }


        public TankModel(int num, Point location, string direction)
        {
            this.PlayerNum = num;
            this.Location = location;
            this.Direction = direction;
            this.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Tank.png");
        }

        public void Update(TankModel updated)
        {
            this.Location = updated.Location;
            this.Direction= updated.Direction;
        }
    }
}
