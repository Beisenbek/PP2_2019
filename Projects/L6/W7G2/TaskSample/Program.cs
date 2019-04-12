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
            Action action = new Action(DoIt2);
            Task task = new Task(action);
            task.Start();
            //task.Wait(3000);


            while (true)
            {

            }

            //task.RunSynchronously();
        }
        public static void DoIt()
        {
            Thread.Sleep(2000);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Hello!");
        }

        public static void DoIt2()
        {
            while (true)
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello");
            }
        }
    }
}
