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
            GenerateLocation();
        }
        public void GenerateLocation()
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);

            Point p = new Point(random.Next(0, 39), random.Next(0, 39));

            while (!IsGoodPoint(p))
            {
                p = new Point(random.Next(0, 39), random.Next(0, 39));
            }
            body.Add(p);
        }

        bool IsGoodPoint(Point p)
        {
            return true;
        }
    }
}
