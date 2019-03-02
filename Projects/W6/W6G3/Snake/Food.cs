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
            Generate();
        }

        public void Generate()
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);
            Point p = new Point
            {
                X = random.Next(0, 39),
                Y = random.Next(0, 39)
            };
            while (!GoodPoint(p))
            {
                p = new Point
                {
                    X = random.Next(0, 39),
                    Y = random.Next(0, 39)
                };
            }
            body.Add(p);
        }

        private bool GoodPoint(Point p)
        {
            return true;
        }
    }
}
