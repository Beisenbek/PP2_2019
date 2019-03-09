using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action(DoIt);
            Task task = new Task(action);
            task.Start();
            task.Wait(3000);

            Console.WriteLine("ok");
            //task.RunSynchronously();
        }

        private static void DoIt()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hi!");
        }
    }
}
