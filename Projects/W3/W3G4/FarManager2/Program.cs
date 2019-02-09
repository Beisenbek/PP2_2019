using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    enum FARMode
    {
        DIR,
        FILE
    }
    class Program
    {
        static void Main(string[] args)
        {
            FARMode mode = FARMode.DIR;
            DirectoryInfo root = new DirectoryInfo(@"C:\test2");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(
                    new Layer
                    {
                        Content = root.GetFileSystemInfos().ToList(),
                        SelectedItem = 0
                    }
                );


            while (true)
            {
                if (mode == FARMode.DIR)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.Delete:
                        history.Peek().DeleteSelectedItem();
                        break;
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Backspace:
                        if (mode == FARMode.DIR)
                        {
                            history.Pop();
                        }
                        else
                        {
                            mode = FARMode.DIR;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];
                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo as DirectoryInfo;
                            history.Push(
                               new Layer
                               {
                                   Content = directoryInfo.GetFileSystemInfos().ToList(),
                                   SelectedItem = 0
                               });
                        }
                        else
                        {
                            mode = FARMode.FILE;
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Black;
                            using (StreamReader sr = new StreamReader(fileSystemInfo.FullName))
                            {
                                Console.WriteLine(sr.ReadToEnd());
                            }
                        }
                        break;
                }
            }
        }
    }
}
