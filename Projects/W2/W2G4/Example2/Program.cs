using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{
    class Program
    { 
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"C:\test\testFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string text = sr.ReadLine();

            int[] numbers = F(text);
            sr.Close();
            fs.Close();

            FileStream fs2 = new FileStream(@"C:\test\testFileOut.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs2);
            //int[] oddNumbers = F2(numbers);


            //var y = numbers.Where(x => x % 2 == 0);
            foreach (var x in y)
            {
                Console.WriteLine(x + " ");
                //sw.Write(x + " ");
            }

            sw.Close();
            fs2.Close();
        }

        private static int[] F2(int[] numbers)
        {
            List<int> res = new List<int>();

            foreach(var x in numbers)
            {
                if(x % 2 == 1)
                {
                    res.Add(x);
                }
            }

            return res.ToArray();
        }

        private static int[] F(string text)
        {
            string[] parts = text.Split();
            int[] res = new int[parts.Length];
            for(int i = 0; i < parts.Length; ++i)
            {
                res[i] = int.Parse(parts[i]);
            }
            return res;
        }
    }
}
