using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.Control;

namespace Client.Model
{
    public class TankModel
    {
        public int PlayerNum { get; set; }
        public Point Location { get; set; }
        public string Direction { get; set; } = "UP";
        public bool IsShooting { get; set; }
        public bool IsDead { get; set; }
        public bool IsTakingDamage { get; set; }
        public int Health { get; set; } = 1;
        public int Damage { get; set; }


        public TankModel(int num, Point location, string direction, int health = 1, bool isDead = false)
        {
            this.PlayerNum = num;
            this.Location = location;
            this.Direction = direction;
            this.Health = health;
            this.IsDead = isDead;
            Task trackDamageTaking = Task.Factory.StartNew(() =>
             {
                 while (true)
                 {
                     foreach (var tank in Controller.OtherPlayers)
                     {
                         if (tank.IsShooting)
                         {
                             Rectangle bulletLine = new Rectangle();
                             if (tank.Direction == "UP") bulletLine = new Rectangle(tank.Location.X, 0, 3, tank.Location.Y);
                             else if (tank.Direction == "DOWN") bulletLine = new Rectangle(tank.Location.X, tank.Location.Y, 3, 9999);
                             else if (tank.Direction == "RIGHT") bulletLine = new Rectangle(tank.Location.X, tank.Location.Y, 9999, 3);
                             else if (tank.Direction == "LEFT") bulletLine = new Rectangle(0, tank.Location.Y, tank.Location.X, 3);

                             Rectangle thisTankRectangle = new Rectangle(this.Location, new Size(90, 90));
                             if (thisTankRectangle.IntersectsWith(bulletLine))
                             {
                                 this.TakeDamage();
                             }
                         }
                     }
                 }
             });
        }

        public void Update(JsonTankModel updated)
        {
            this.Location = new Point(int.Parse(updated.LocationX), int.Parse(updated.LocationY));
            this.Direction = updated.Direction;
            this.IsShooting = updated.IsShooting;
            this.IsTakingDamage = updated.IsTakingDamage;
            this.IsDead = updated.IsDead;


        }
        public JsonTankModel ToJsonModel()
        {
            return new JsonTankModel()
            {
                PlayerNum = this.PlayerNum,
                Direction = this.Direction,
                LocationX = this.Location.X.ToString(),
                LocationY = this.Location.Y.ToString(),
                IsShooting = this.IsShooting,
                IsTakingDamage = this.IsTakingDamage,
                IsDead = this.IsDead
            };
        }

        public void Move()
        {
            if (Direction == "UP") this.Location = new Point(this.Location.X, this.Location.Y - 10);
            else if (Direction == "DOWN") this.Location = new Point(this.Location.X, this.Location.Y + 10);
            else if (Direction == "RIGHT") this.Location = new Point(this.Location.X + 10, this.Location.Y);
            else if (Direction == "LEFT") this.Location = new Point(this.Location.X - 10, this.Location.Y);
        }

        public async void Shoot()
        {
            this.IsShooting = true;
            await Task.Delay(1000);
            this.IsShooting = false;

        }
        public async void TakeDamage(int damage = 1)
        {
            this.IsTakingDamage = true;
            this.Health -= damage;
            await Task.Delay(1000);
            this.IsTakingDamage = false;
            if (Health <= 0) this.IsDead = true;
        }


    }

    public class JsonTankModel
    {
        public int PlayerNum { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public string Direction { get; set; }
        public bool IsShooting { get; set; }
        public bool IsDead { get; set; }
        public bool IsTakingDamage { get; set; }


    }

}
