using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarManager
{
    class Layer
    {
        public int SelectedItem
        {
            get;
            set;
        }

        private FileSystemInfo[] content;
        public FileSystemInfo[] Content
        {
            get
            {
                return content;
            }
            set
            {
                if (value.Length > 0)
                {
                    content = value;
                    Console.WriteLine(content.Length);
                }
                else
                {
                    Console.WriteLine("bad array!");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Layer l = new Layer();
            //l.SetContent(...)
            //l.content2 = ...
            var y = new DirectoryInfo(@"C:\");
            l.Content = y.GetFileSystemInfos();
        }
    }
}
