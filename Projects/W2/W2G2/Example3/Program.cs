using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Layer
    {
        public int selectedItem;
        public FileSystemInfo[] items;

        public Layer(FileSystemInfo[] items)
        {
            selectedItem = 0;
            this.items = items;
        }

        public void Draw(bool mode)
        {
            if (mode == true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                for (int i = 0; i < items.Length; ++i)
                {
                    if (i == selectedItem)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    if (items[i].GetType() == typeof(DirectoryInfo))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(items[i].Name);
                }
            }
            else
            {

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\Far30b5254.x64.20180805\PluginSDK");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(new Layer(dirInfo.GetFileSystemInfos()));

            bool quit = false;

            bool mode = true;//1 - folder, 0 - file

            while (!quit)
            {
                history.Peek().Draw(mode);
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (history.Peek().selectedItem - 1 < 0)
                        {
                            history.Peek().selectedItem = history.Peek().items.Length - 1;
                        }
                        else
                        {
                            history.Peek().selectedItem--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (history.Peek().selectedItem + 1 >= history.Peek().items.Length)
                        {
                            history.Peek().selectedItem = 0;
                        }
                        else
                        {
                            history.Peek().selectedItem++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int x = history.Peek().selectedItem;
                        FileSystemInfo selectedFSI = history.Peek().items[x];
                        if (selectedFSI.GetType() == typeof(DirectoryInfo))
                        {
                            FileSystemInfo[] items = (selectedFSI as DirectoryInfo).GetFileSystemInfos();
                            history.Push(new Layer(items));
                        }
                        else
                        {
                            mode = false;
                            FileStream fs = new FileStream(selectedFSI.FullName, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fs);

                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.WriteLine(sr.ReadToEnd());

                            sr.Close();
                            fs.Close();
                        }

                        break;
                    case ConsoleKey.Backspace:
                        mode = true;
                        history.Pop();
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                }
            }
        }
    }
}
