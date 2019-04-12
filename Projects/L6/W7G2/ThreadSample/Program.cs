using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadSample
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();
            DoIt();
            DoIt();
        }

        public static void DoIt()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId + " Hello!");
        }
    }
}
