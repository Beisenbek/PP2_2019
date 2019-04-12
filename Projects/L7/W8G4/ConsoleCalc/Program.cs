using Calc1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowResultDelegate showResultDelegate = new ShowResultDelegate(PrintInfo);
            Brain brain = new Brain(showResultDelegate); 
            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                brain.Process(consoleKeyInfo.KeyChar.ToString());
            }
        }

        static void PrintInfo(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }
    }
}
