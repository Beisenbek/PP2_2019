using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
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
            ObjectInfo objectInfo = ObjectInfo.AVI;

            switch (objectInfo)
            {
                case ObjectInfo.DIR:
                    Console.WriteLine("DIR!");
                    break;
                case ObjectInfo.FILE:
                    Console.WriteLine("FILE!");
                    break;
                case ObjectInfo.ZIP:
                    Console.WriteLine("ZIP!");
                    break;
                case ObjectInfo.AVI:
                    Console.WriteLine("AVI!");
                    break;
            }

        }
    }
}
