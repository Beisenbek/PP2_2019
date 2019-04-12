using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            var presssedKey = Console.ReadKey();

            DirectoryInfo directoryInfo = new DirectoryInfo(@"C:\test3");
            var subdirs = directoryInfo.GetDirectories();
            foreach(var d in subdirs)
            {
                int cnt = F(d, presssedKey.KeyChar);
                Console.WriteLine(string.Format("{0} ({1})", d.Name, cnt));
            }
        }

        private static int F(DirectoryInfo d, char c)
        {
            int res = 0;

            try
            {
                var files = d.GetFiles();
                foreach(var f in files)
                {
                    if(f.Name[0] == c)
                    {
                        res++;
                    }
                }

            }catch (Exception e)
            {
                res = -1;
            }

            return res;
        }
    }
}
