using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDelegate d = new MyDelegate(DoIt2);
            Calculator calculator = new Calculator(d);
            calculator.Calc();
        }

        static void DoIt2(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
