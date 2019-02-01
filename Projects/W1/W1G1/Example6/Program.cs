using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example6
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5];
            a[0] = 1;
            a[1] = 2;
            a[2] = 3;
            a[3] = 4;
            a[4] = 5;

            for (int i = 0; i < a.Length; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    Console.Write(a[i] + " ");
                }
            }
        }
    }
}
