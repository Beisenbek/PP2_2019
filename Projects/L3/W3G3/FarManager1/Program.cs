using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager1
{

    enum ObjectInfo
    {
        DIR,
        FILE,
        ZIP
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isDirInfo = false;
            ///...
            ///

            if (isDirInfo == true)
            {
                Console.WriteLine("DIR!");
            }
            else
            {
                Console.WriteLine("FILE!");
            }

            int isDirInfo2 = 2;
            /// 0 - DIR
            /// 1 - FILE
            /// 2 - ZIP

            if (isDirInfo2 == 0)
            {
                Console.WriteLine("DIR!");
            }
            else if (isDirInfo2 == 1)
            {
                Console.WriteLine("FILE!");
            }
            else if (isDirInfo2 == 2)
            {
                Console.WriteLine("ZIP!");
            }


            ObjectInfo objectInfo = default(ObjectInfo);

            if (objectInfo == ObjectInfo.DIR)
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
                default:
                    Console.WriteLine("DEFAULT!");
                    break;
            }



        }
    }
}
