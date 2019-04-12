using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    enum FSIMode
    {
        Dir,
        File,
        Zip
    }

    class Program
    {
        static void Main(string[] args)
        {
            FSIMode mode = FSIMode.Zip;

            int mode2 = 2;
            //0 - dir
            //1 - file
            //2 - zip
            //..
            if(mode2 == 0)
            {
                Console.WriteLine("DIR!");
            }
            else if (mode2 == 1)
            {
                Console.WriteLine("FILE!");
            }
            else if (mode2 == 2)
            {
                Console.WriteLine("ZIP!");
            }
            //..
            //...
            //..
            if (mode == FSIMode.Dir)
            {
                Console.WriteLine("DIR!");
            }else if(mode == FSIMode.File)
            {
                Console.WriteLine("FILE!");
            }else if(mode == FSIMode.Zip)
            {
                Console.WriteLine("ZIP!");
            }
        }
    }
}
