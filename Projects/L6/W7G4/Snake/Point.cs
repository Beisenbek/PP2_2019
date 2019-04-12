using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Point
    {
        int x;
        int y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = Filter(value);
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = Filter(value);
            }
        }
        int Filter(int v)
        {
            if(v < 0)
            {
                v = 39;
            }else if(v > 39)
            {
                v = 0;
            }
            return v;
        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point()
        {

        }
    }
}

