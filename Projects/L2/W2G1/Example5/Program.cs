using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5
{
    class Program
    {
        static void Solve(string str)
        {
            string[] x = str.Split(',');
            int sum = 0;

            foreach (var y in x)
            {
                sum += int.Parse(y);
            }

            Console.WriteLine(sum);
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
