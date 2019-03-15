using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadForConsoleInput
{
    class Program
    {
        static ConsoleKey consoleKey = ConsoleKey.Spacebar;
        static void Main(string[] args)
        {
            Task task = new Task(new Action(DoIt));
            task.Start();

            while (true)
            {
                Console.WriteLine(consoleKey);
                Thread.Sleep(2000);
            }
        }

        static void DoIt()
        {
            while (true)
            {
                consoleKey = Console.ReadKey().Key;
            }
        }
    }
}
