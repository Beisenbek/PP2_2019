using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Program
    {
        static void Main(string[] args)
        {
            F3();
        }

        private static void F3()
        {
            FileStream fs = new FileStream(@"C:\test\testFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();

            sr.Close();
            fs.Close();


            string output = F(line);

            FileStream fs2 = new FileStream(@"C:\test\testFileOut.txt",FileMode.OpenOrCreate,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            sw.WriteLine(output);
            sw.Close();
            fs2.Close();

        }

        private static string F(string line)
        {
            string res = "";
            string[] parts = line.Split();
            foreach(string x in parts)
            {
                int t = int.Parse(x);
                if(t % 2 == 0)
                {
                    res = res + " " + t;
                }
            }
            return res.Trim();
        }

        private static void F2()
        {
            FileStream fs = new FileStream(@"C:\test\testFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Console.WriteLine(line);
            }

            sr.Close();
            fs.Close();
        }

        private static void F1()
        {

            FileStream fs = new FileStream(@"C:\test\testFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            Console.WriteLine(sr.ReadToEnd());

            sr.Close();
            fs.Close();
        }
    }
}
