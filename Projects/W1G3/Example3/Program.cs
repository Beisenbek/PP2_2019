using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            //string b = Console.ReadLine();

            int aa = 1;

            bool result = int.TryParse(a, out aa);

            if (result == true)
            {
                Console.WriteLine("ok " + aa);
            }
            else
            {
                Console.WriteLine("no " + aa);
            }
        }
    }
}
