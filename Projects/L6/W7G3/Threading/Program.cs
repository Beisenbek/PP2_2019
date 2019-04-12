using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();
            /*for (int i = 0; i < 100; ++i)
            {
                Console.WriteLine("Hello!");
            }*/
            DoIt();
            DoIt();
        }

        private static void DoIt()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            /*for (int i = 0; i < 100; ++i)
            {
                Console.WriteLine("Hi!");
            }*/
        }
    }
}
