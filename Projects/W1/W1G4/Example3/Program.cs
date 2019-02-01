using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        /*
         input:
         3
         1 2 3
         output:
         1 1 2 2 3 3
        */
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            //string[] parts = line2.Split(',');
            string[] parts = line2.Split(new char[] { ' ', ',', '$' });
            Console.WriteLine(parts.Length);
            for (int i = 0; i < parts.Length; ++i)
            {
                Console.WriteLine(parts[i]);
            }
        }
    }
}
