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
        static void Solve(string str)
        {

            bool ok = true;

            for(int i = 0; i < str.Length; ++i)
            {
                if(str[str.Length - 1 - i] != str[i])
                {
                    ok = false;
                    break;
                }
            }

            if (ok)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\test\innerTest\hello.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();

            Solve(line);


            sr.Close();
            fs.Close();

        }
    }
}
