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
            //comment
            bool log = false;
            if (args.Length > 0)
            {
                if (args[0] == "-t")
                {
                    log = true;
                }
            }
            string s = Console.ReadLine();
            if (log == true)
            {
                Console.WriteLine("string s ready....");
            }
            Console.WriteLine(s + "!!");
            if (log == true)
            {
                Console.WriteLine("string s printed....");
            }
        }
    }
}
