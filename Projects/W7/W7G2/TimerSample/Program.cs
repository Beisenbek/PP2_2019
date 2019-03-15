using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TimerSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(2000);
            timer.Elapsed += DoIt;
            timer.Elapsed += DoIt2;
            timer.Start();
            while (true)
            {

            }
        }
        private static void DoIt(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello 1");
        }
        private static void DoIt2(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello 2");
        }
    }
}
