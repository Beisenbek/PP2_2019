using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    enum ObjectInfo
    {
        DIR,
        FILE,
        ZIP,
        AVI
    }

    class Program
    {
        static void Main(string[] args)
        {
            ObjectInfo objectInfo = ObjectInfo.DIR;

            if (objectInfo == ObjectInfo.AVI)
            {
                Console.WriteLine("AVI!");
            }
            else if (objectInfo == ObjectInfo.DIR)
            {
                Console.WriteLine("DIR!");
            }
            else if (objectInfo == ObjectInfo.FILE)
            {
                Console.WriteLine("FILE!");
            }
            else if (objectInfo == ObjectInfo.ZIP)
            {
                Console.WriteLine("ZIP!");
            }
        }
    }
}
