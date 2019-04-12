using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            int isitfolder = 2;

            /*
             0 - DIR
             1 - FILE
             2 - ZIP
             3...
             53 - 
             */
            if (isitfolder == 0)
            {
                Console.WriteLine("DIR!");
            }
            else if(isitfolder == 1)
            {
                Console.WriteLine("FILE!");
            }else 
            if (isitfolder == 2)
            {
                Console.WriteLine("ZIP!");
            }
        }
    }
}
