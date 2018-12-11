using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace lab12
{
    class CEmblem : CFigure
    {
        private int _radius;

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value >= 200 ? 200 : value;
                _radius = value <= 5 ? 5 : value;
            }
        }

        public CEmblem(Graphics graphics, int X, int Y, int Radius)
        {
            this.graphics = graphics;
            this.X = X;
            this.Y = Y;
            this.Radius = Radius;
        }

        protected override void Draw(Pen pen)
        {
            Rectangle circle = new Rectangle(X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            graphics.DrawEllipse(pen, circle);
            Rectangle cube = new Rectangle(X - Radius, Y - Radius, Radius * 2, Radius * 2);
            graphics.DrawRectangle(pen, cube);
            double r = (Radius);
            Point p1 = new Point(X + (int)(r * Math.Cos(Math.PI / 6)), Y + (int)(r * Math.PI / 6));
            Point p2 = new Point(X + (int)(r * Math.Cos(Math.PI / 2)), Y - (int)(r * Math.PI / 3.2));
            Point p3 = new Point(X - (int)(r * Math.Cos(Math.PI / 6)), Y + (int)(r * Math.PI / 6));
            Point[] triangle = { p1, p2, p3 };
            graphics.DrawPolygon(pen, triangle);
        }

        override public void Expand(int dR)
        {
            Hide(); Radius = Radius + dR; Show();
        }
        override public void Collapse(int dR)
        {
            Hide(); Radius = Radius - dR; Show();
        }
    }
}
