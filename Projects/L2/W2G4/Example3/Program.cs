using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        /// <summary>
        /// Главная точка входа в проект
        /// </summary>
        /// <param name="args">аргументы командной строки</param>
        static void Main(string[] args)
        {
            int[] oddNumbers;

            //считали данные из фал
            using (FileStream fs = new FileStream(@"C:\test\testFile.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string text = sr.ReadLine();
                    int[] numbers = F(text);
                    oddNumbers = F2(numbers);

                }
            }
            //записали результат
            using (FileStream fs2 = new FileStream(@"C:\test\testFileOut.txt", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs2))
                {
                    foreach (var x in oddNumbers)
                    {
                        sw.Write(x + " ");
                    }
                }
            }
        }
        /// <summary>
        /// фильтр нечетных чисел
        /// </summary>
        /// <param name="numbers">все сырые числа</param>
        /// <returns></returns>
        private static int[] F2(int[] numbers)
        {
            List<int> res = new List<int>();

            foreach (var x in numbers)
            {
                if (x % 2 == 1)
                {
                    res.Add(x);
                }
            }
            return res.ToArray();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static int[] F(string text)
        {
            string[] parts = text.Split();
            int[] res = new int[parts.Length];
            for (int i = 0; i < parts.Length; ++i)
            {
                res[i] = int.Parse(parts[i]);
            }
            return res;
        }
    }
}
