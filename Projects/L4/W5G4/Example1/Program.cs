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
        static bool IsPalindrom(string str)
        {
            bool res = true;
            for(int i = 0; i < str.Length / 2; ++i)
            {
                if(str[i] != str[str.Length - i - 1])
                {
                    res = false;
                    break;
                }
            }
            return res;
        }

        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            var dirs = dir.GetDirectories();
            //var files = dir.GetFiles("*.txt");

            foreach (var subd in dirs)
            {

                try
                {
                    var files = subd.GetFiles();
                    int cnt = 0;
                    foreach (var f in files)
                    {
                        string fname = Path.GetFileNameWithoutExtension(f.Name);
                        if (IsPalindrom(fname))
                        {
                            cnt++;
                        }
                    }
                    Console.WriteLine(subd.Name + " " + cnt);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
