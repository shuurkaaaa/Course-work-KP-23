using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hippodrome
{
    public class MyObject
    {
        public int x, y, w, h;
        public double speed;
        public Image Im;
        public string name;
        Font font;
        SolidBrush brush;
        public MyObject(int x, int y, int w, int h, double speed, Image im, string name)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.speed = speed;
            Im = im;
            this.name = name;
            font = new Font("Arial", 10);
            brush = new SolidBrush(Color.Blue);
        }
        public void Drow(Graphics g)
        {
            g.DrawImage(Im, x, y, w, h);
            g.DrawString(name, font, brush,x,y+h);
        }
    }
}
