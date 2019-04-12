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
        static Timer timer = new Timer(1000);

        static void Main(string[] args)
        {

            Console.CursorSize = 100;
            timer.Elapsed += Doit;
            timer.Elapsed += Doit2;

            timer.Start();

            while (true)
            {

            }

        }

        private static void Doit(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hello!" + DateTime.Now.ToLongTimeString());
        }

        private static void Doit2(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("Hi!");
        }
    }
}
