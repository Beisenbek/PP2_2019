using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerWithTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(new Action(DoIt));
            task.RunSynchronously();
            /*Task task = Task.Run(new Action(DoIt));
            task.Wait();*/
            /*Task task = Task.Run(() => { DoIt(); });
            task.Wait();*/
        }

        private static void DoIt()
        {
            while (true)
            {
                Console.WriteLine("Hi!");
                Thread.Sleep(1000);
            }
        }
    }
}
