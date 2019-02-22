using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\test");

                foreach (var x in dir.GetDirectories("*.*", SearchOption.TopDirectoryOnly))
                {
                    int cnt = x.GetFiles("*.txt").Length;
                    Console.WriteLine(x.Name + " " + cnt);
                }

            foreach (var x in dir.GetFiles())
            {
                Console.WriteLine(x.Name);
            }
        }
    }
}
