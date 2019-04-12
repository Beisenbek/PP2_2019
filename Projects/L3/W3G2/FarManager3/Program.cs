using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager3
{
    enum ViewMode
    {
        ShowDirContent,
        ShowFileContent
    }

    class Program
    {
        static void Main(string[] args)
        { 
            DirectoryInfo dir = new DirectoryInfo(@"C:\test2");
            Stack<Layer> history = new Stack<Layer>();
            history.Push(
                new Layer
                {
                    Content = dir.GetFileSystemInfos()
                }
            );

            ViewMode viewMode = ViewMode.ShowDirContent;
            bool esc = false;
            while (!esc)
            {
                if (viewMode == ViewMode.ShowDirContent)
                {
                    history.Peek().Draw();
                }
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.F2:
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Clear();
                        string name = Console.ReadLine();
                        int x3 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo3 = history.Peek().Content[x3];
                        if (fileSystemInfo3.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo3 as DirectoryInfo;
                            Directory.Move(fileSystemInfo3.FullName, directoryInfo.Parent + "/" + name);
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo3 as FileInfo;
                            File.Move(fileSystemInfo3.FullName, fileInfo.Directory.FullName + "/" + name);
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();
                        }

                        break;
                    case ConsoleKey.Delete:
                        int x2 = history.Peek().SelectedItem;
                        FileSystemInfo fileSystemInfo2 = history.Peek().Content[x2];
                        history.Peek().SelectedItem--;
                        if (fileSystemInfo2.GetType() == typeof(DirectoryInfo))
                        {
                            DirectoryInfo directoryInfo = fileSystemInfo2 as DirectoryInfo;
                            Directory.Delete(fileSystemInfo2.FullName, true);
                            history.Peek().Content = directoryInfo.Parent.GetFileSystemInfos();
                        }
                        else
                        {
                            FileInfo fileInfo = fileSystemInfo2 as FileInfo;
                            File.Delete(fileSystemInfo2.FullName);
                            history.Peek().Content = fileInfo.Directory.GetFileSystemInfos();
                        }


                        break;
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
                            viewMode = ViewMode.ShowDirContent;
                            DirectoryInfo selectedDir = fileSystemInfo as DirectoryInfo;
                            history.Push(new Layer { Content = selectedDir.GetFileSystemInfos() });
                        }
                        else
                        {
                            viewMode = ViewMode.ShowFileContent;
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
                        if (viewMode == ViewMode.ShowDirContent)
                        {
                            history.Pop();
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            viewMode = ViewMode.ShowDirContent;
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
