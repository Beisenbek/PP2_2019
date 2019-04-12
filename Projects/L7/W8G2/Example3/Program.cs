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
            Example2.Calculator calculator = new Example2.Calculator(new Example2.MyDelegate(DoIt));
            calculator.Calc();
        }

        private static void DoIt(string message)
        {
            Console.WriteLine(message);
        }
    }
}
