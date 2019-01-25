using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8
{
    class Program
    {
        static void Main(string[] args)
        {
            //comment
            int x = 1;
            string s = "123 fdsafadsf";
            bool res = int.TryParse(s, out x);
            if(res == true)
            {
                Console.WriteLine("ok " + x);
            }
            else
            {
                Console.WriteLine("no " + x);
            }
        }
    }
}
