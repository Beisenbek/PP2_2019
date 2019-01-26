using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            string lineA = Console.ReadLine();
            string lineB = Console.ReadLine();
            Console.WriteLine(lineA + lineB);

            int a = int.Parse(lineA);
            int b = int.Parse(lineB);
            Console.WriteLine(a + b);

        }
    }
}
