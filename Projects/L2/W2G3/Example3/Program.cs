using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void PrintInfo(FileSystemInfo fsi, int k)
        {
            string line = new string(' ', k);
            line = line + fsi.Name;
            Console.WriteLine(line);

            if(fsi.GetType() == typeof(DirectoryInfo))
            {
                var items = (fsi as DirectoryInfo).GetFileSystemInfos();
                foreach (var i in items)
                {
                    PrintInfo(i, k + 4);
                }
            }
        }

        private static void F3()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\test");
            PrintInfo(dir, 1);
        }

        private static void F2()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\FPC\3.0.4");
            var folders = dir.GetDirectories();
            foreach (var i in folders)
            {
                Console.WriteLine(i.Name);
            }
            var files = dir.GetFiles();
            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var i in files)
            {
                Console.WriteLine(i.Name);
            }
        }

        private static void F1()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\FPC\3.0.4");
            var items = dir.GetFileSystemInfos();
            foreach (var i in items)
            {
                if (i.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(i.Name);
            }
        }
    }
}
