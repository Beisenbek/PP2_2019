using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Worm : GameObject
    {
        public Worm() : base()
        {

        }
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point { X = 20, Y = 20 });
            Dx = Dy = 0;
        }

        public int Dx
        {
            get;
            set;
        }
        public int Dy
        {
            get;
            set;
        }

        public void Move()
        {

            for(int i = body.Count - 1; i > 0; --i)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }

            body[0].X += Dx;
            body[0].Y += Dy;
        }

        public bool CheckIntersection(Point point)
        {
            bool res = false;

            if(body[0].X == point.X && 
               body[0].Y == point.Y)
            {
                res = true;
            }

            return res;
        }

        public void Eat(Point point)
        {
            body.Add(new Point { X = point.X, Y = point.Y });
        }
    }
}
