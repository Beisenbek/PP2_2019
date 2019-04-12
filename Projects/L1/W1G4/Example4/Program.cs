using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int c = int.Parse(Console.ReadLine());
            int a = 1;
            string b = Console.ReadLine();
            bool res = int.TryParse(b, out a);
            if (res == true)
            {
                Console.WriteLine("ok " + a);
            }
            else
            {
                Console.WriteLine("no " + a);
            }
        }
    }
}
