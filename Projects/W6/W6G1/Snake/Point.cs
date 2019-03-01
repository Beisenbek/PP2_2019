using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Point
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
                if (value < 0)
                {
                    x = 39;
                }
                else if (value >= 40)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
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
                if (value < 0)
                {
                    y = 39;
                }
                else if (value >= 40)
                {
                    y = 0;
                }
                else
                {
                    y = value;
                }
            }
        }
    }
}
