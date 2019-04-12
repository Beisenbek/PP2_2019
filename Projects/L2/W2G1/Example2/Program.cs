using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }


        private static void PrintInfo(FileSystemInfo[] x, ConsoleColor c)
        {
            Console.ForegroundColor = c;
            foreach (var t in x)
            {
                Console.WriteLine(t.Name);
            }
        }

        private static void F4()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test");
            PrintInfo(dirInfo.GetDirectories(), ConsoleColor.White);
            PrintInfo(dirInfo.GetFiles(), ConsoleColor.Yellow);
        }

        private static void F3()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test");
            var x = dirInfo.GetFileSystemInfos();
            foreach (var t in x)
            {
                if (t.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(t.Name);
            }
        }

        private static void F2()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test");
            var x = dirInfo.GetFileSystemInfos();
            foreach(var t in x)
            {
                Console.WriteLine(t.Name);
            }
        }

        private static void F1()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();
            for (int i = 0; i < x.Length; ++i)
            {
                Console.WriteLine(x[i].Name);
            }
        }
    }
}
