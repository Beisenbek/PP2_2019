using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food:GameObject
    {
        public Food(char sign) : base(sign)
        {
            
        }

        private bool GoodPoint(Point p, List<Point> usedPoints)
        {
            bool res = true;

            foreach(Point t in usedPoints)
            {
                if(t.X == p.X && t.Y == p.Y)
                {
                    res = false;
                    break;
                }
            }

            return res;
        }

        public void Generate(List<Point> usedPoints1, List<Point> usedPoints2)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point
            {
                X = random.Next(0, 39),
                Y = random.Next(0, 39)
            };
            while (!GoodPoint(p, usedPoints1) || !GoodPoint(p, usedPoints2))
            {
                p = new Point
                {
                    X = random.Next(0, 39),
                    Y = random.Next(0, 39)
                };
            }
            body.Add(p);
        }
    }
}
