using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();

            DoIt();
        }

        private static void DoIt()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Hi!");
        }
    }
}
