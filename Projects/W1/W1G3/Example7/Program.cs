using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example7
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] objs = { "apple", "orange" };
            foreach (var o in objs)
            {
                Console.WriteLine(o);
            }
        }
    }
}
