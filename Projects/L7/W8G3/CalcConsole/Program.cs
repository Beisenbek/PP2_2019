using Calc1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CalcConsole
{
    class Program
    {
        static Brain brain;

        static void Main(string[] args)
        {
            MyDelegate myDelegate = new MyDelegate(PrintMessageToConsole); 
            brain = new Brain(myDelegate);

            while (true)
            {
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                brain.Process(consoleKeyInfo.KeyChar.ToString());
            }
        }

        static void PrintMessageToConsole(string message)
        {
            Console.Clear();
            Console.WriteLine(message);
        }
    }
}
