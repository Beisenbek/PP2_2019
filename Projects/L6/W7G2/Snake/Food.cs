using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Food:GameObject
    {
        public Food(char sign) : base(sign)
        {
        }

        public Food() : base()
        {

        }

        public void Generate(List<Point> wormBody, List<Point> wallBody)
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point
            {
                X = random.Next(0, 39),
                Y = random.Next(0, 39)
            };

            while (!IsGoodPoint(p,wormBody) || !IsGoodPoint(p, wallBody))
            {
                p = new Point
                {
                    X = random.Next(0, 39),
                    Y = random.Next(0, 39)
                };
            }

            body.Add(p);
        }

        bool IsGoodPoint(Point p, List<Point> usedPoints)
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


    }
}
