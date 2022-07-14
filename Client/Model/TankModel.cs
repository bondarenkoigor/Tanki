using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
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

        public void Update(JsonTankModel updated)
        {
            this.Location = new Point(int.Parse(updated.LocationX), int.Parse(updated.LocationY));
            this.Direction = updated.Direction;
        }
        public JsonTankModel ToJsonModel()
        {
            return new JsonTankModel() {PlayerNum = this.PlayerNum, Direction = this.Direction, LocationX = this.Location.X.ToString(), LocationY = this.Location.Y.ToString() };
        }

        public void Move()
        {
            if (Direction == "UP") this.Location = new Point(this.Location.X, this.Location.Y - 10);
            else if (Direction == "DOWN") this.Location = new Point(this.Location.X, this.Location.Y + 10);
            else if (Direction == "RIGHT") this.Location = new Point(this.Location.X + 10, this.Location.Y);
            else if (Direction == "LEFT") this.Location = new Point(this.Location.X - 10, this.Location.Y);
        }

        public void Shoot()
        {
            this.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\ShootingTank.png");
            System.Threading.Thread.Sleep(1000);
            this.Image = Image.FromFile(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\Resources\\Tank.png");

        }

    }

    public class JsonTankModel
    {
        public int PlayerNum { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string Direction { get; set; }

    }

}
