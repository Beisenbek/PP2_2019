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
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();


            ThreadStart threadStart2 = new ThreadStart(DoIt);
            Thread thread2 = new Thread(threadStart2);
            thread2.Start();

            DoIt();
        }

        static void DoIt()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
