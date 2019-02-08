using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager2
{
    enum ViewMode
    {
        Dir,
        File
    }

    class Layer
    {
        public FileSystemInfo[] Content
        {
            get;
            set;
        }

        public int SelectedItem
        {
            get;
            set;
        }

        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            for (int i = 0; i < Content.Length; ++i)
            {
                if (i == SelectedItem)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(Content[i].Name);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\test");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(
                new Layer
                {
                    Content = dir.GetFileSystemInfos()
                }
            );

            ViewMode viewMode = ViewMode.Dir;
            bool esc = false;
            while (!esc)
            {
                if (viewMode == ViewMode.Dir)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        history.Peek().SelectedItem--;
                        break;
                    case ConsoleKey.DownArrow:
                        history.Peek().SelectedItem++;
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo = history.Peek().Content[x];

                        if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                        {
                            viewMode = ViewMode.Dir;
                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() });
                        }
                        else
                        {
                            viewMode = ViewMode.File;
                            using (FileStream fs = new FileStream(fileSystemInfo.FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Backspace:
                        if (viewMode == ViewMode.Dir)
                        {
                            history.Pop();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            viewMode = ViewMode.Dir;
                        }
                        break;
                    case ConsoleKey.Escape:
                        esc = true;
                        break;
                }
            }
        }
    }
}
