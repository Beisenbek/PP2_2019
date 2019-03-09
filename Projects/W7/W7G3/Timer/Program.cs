using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer1
{
    class Program
    {
        static void Main(string[] args)
        {
            TimerCallback timerCallback = new TimerCallback(DoIt);
            Timer timer = new Timer(timerCallback);
            timerCallback.Invoke("123");
        }

        private static void DoIt(object state)
        {
            Console.WriteLine("Hi!");
        }
    }
}
