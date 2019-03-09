using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threading2
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(DoIt);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }
        private static void DoIt()
        {
            while(true)
            {
                Console.WriteLine("Hi!");
                Thread.Sleep(1000);
            }
        }
    }
}
