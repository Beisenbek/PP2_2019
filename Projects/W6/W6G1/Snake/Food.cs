using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Food : GameObject
    {
        public Food(char sign):base(sign)
        {
            body.Add(new Point(30, 20));
        }
    }
}
