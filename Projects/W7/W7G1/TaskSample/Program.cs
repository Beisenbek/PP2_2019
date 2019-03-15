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
            F1();
        }

        private static void F2()
        {
            Task.Run(() => { DoIt(); });
        }
        private static void F1()
        {
            Action action = new Action(DoIt);
            Task task = new Task(action);
            //task.RunSynchronously();
            task.Start();
            task.Wait(3000);
        }


        public static void DoIt()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello!");
        }
    }
}
