using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hippodrome
{
    public class Horse : MyObject
    {
        double angle;
        double radius;
        double radiusReserve;
        public bool isFinished;
        double time;
      

        public Rectangle rec;
        public Horse(int x, int y, int w, int h, double speed, Image im,string name, double angle, double radius)
            : base(x, y, w, h, speed, im,name)
        {
            this.angle = angle;
            this.radius = radius;
            rec = new Rectangle(x, y, w, h);
            radiusReserve = radius-30;
            time = 0;
            isFinished = false;
        }

        public void Move(int centrX,int сentrY, bool isOvertake)
        {
            if (!isFinished)
            {
                angle += speed;
                if (isOvertake)
                {
                    x = centrX + (int)(2*radiusReserve * Math.Cos(angle));
                    
                    y = сentrY - (int)(radiusReserve * Math.Sin(angle));
                }
                else
                {
                    x = centrX + (int)(2*radius * Math.Cos(angle));
                    
                    y = сentrY - (int)(radius * Math.Sin(angle));
                }
                rec = new Rectangle(x, y, w, h);
                time=time+0.1;
                if (angle > 6 * Math.PI) isFinished = true;
            }
        }

        public HorseResult GetResult()
        {
            return new HorseResult(name, Math.Round(angle * radius, 2), Math.Round(6 * Math.PI* radius - angle * radius,2), Math.Round(time,2));
        }


    }
}
