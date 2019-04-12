using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Example2
{
    class Program
    {
        static void Main(string[] args)
        {
            F4();
        }

        private static void Draw(FileSystemInfo[] x, int index)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < x.Length; ++i)
            {
                if (i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (x[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(x[i].Name);
            }
        }

        private static void F4()
        {
            int index = 0;
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test2");
            bool quit = false;
            while (!quit) {
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    index--;
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    index++;
                }
                else if (pressedKey.Key == ConsoleKey.Enter)
                {

                }
                Draw(dirInfo.GetFileSystemInfos(), index);
            }
        }
        private static void F3()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test2");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();
            int index = 0;

            for (int i = 0; i < x.Length; ++i)
            {
                if( i == index)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (x[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(x[i].Name);
            }
        }


        private static void F2()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test2");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();

            for (int i = 0; i < x.Length; ++i)
            {
                if(x[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(x[i].Name);
            }
        }

        private static void F1()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\test2");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();

            for (int i = 0; i < x.Length; ++i)
            {
                Console.WriteLine(x[i].FullName);
            }
        }
    }
}
