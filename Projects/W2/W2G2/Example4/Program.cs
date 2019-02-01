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

        static bool IsPrime(int x)
        {
            if (x == 1) return false;
            if (x == 2) return true;

            bool functionResult = true;

            for (int i = 2; i < x; ++i)
            {
                if (x % i == 0)
                {
                    functionResult = false;
                    break;
                }
            }
            return functionResult;
        }

        static bool IsPrimeString(string s)
        {
            return IsPrime(int.Parse(s));
        }

        static void Main(string[] args)
        {

            List<string> res = new List<string>();

            FileStream fs = new FileStream(@"C:\test2\info.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            string[] nums = line.Split(' ');

            foreach (var x in nums)
            {
                if (IsPrimeString(x))
                {
                    res.Add(x);
                }
            }

            sr.Close();
            fs.Close();



            FileStream fs2 = new FileStream(@"C:\test2\res.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);

            foreach (var x in res)
            {
                sw.Write(x + " ");
                Console.Write(x + " ");
            }

            sw.Close();
            fs2.Close();
        }
    }
}
