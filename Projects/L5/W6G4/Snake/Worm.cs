using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point(20, 20));
        }
        public void Move(int dx, int dy)
        {
            Clear();
            for (int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0].X += dx;
            body[0].Y += dy;
        }
        public bool IsIntersected(List<Point> points)
        {
            bool res = false;

            foreach(Point p in points)
            {
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }

            return res;
        }

        public void Eat(List<Point> body)
        {
            this.body.Add(new Point(body[0].X, body[0].Y));
        }
    }
}
