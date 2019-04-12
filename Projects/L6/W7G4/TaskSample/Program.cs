using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Action action = new Action(DoIt);
            Task task = new Task(action);
            task.Start();
            task.Wait(1000);
        }

        private static void DoIt()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(500);
            Console.WriteLine("Hi!");
        }
    }
}
