using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args.Length);
            for (int i = 0; i < args.Length; ++i)
            {
                Console.WriteLine(args[i]);
            }
        }
    }
}
