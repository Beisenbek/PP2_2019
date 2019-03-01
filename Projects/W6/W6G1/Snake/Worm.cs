using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Worm : GameObject
    {
        public Worm(char sign):base(sign)
        {
            body.Add(new Point(20, 20));
        }

        public void Move(int dx, int dy)
        {
            Clear();
            body[0].x = body[0].x + dx;
            body[0].y = body[0].y + dy;
        }
    }
}
