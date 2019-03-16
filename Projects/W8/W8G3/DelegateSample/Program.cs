using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateSample
{
    delegate void MyDelegate(string message);
    class Program
    {
        static void Main(string[] args)
        {
            Sample sample = new Sample();
            Sample2 sample2 = new Sample2();
            Sample3 sample3 = new Sample3();

            MyDelegate myDelegate = new MyDelegate(sample.PrintInfo);
            MyDelegate myDelegate2 = new MyDelegate(sample2.PrintInfo);
            MyDelegate myDelegate3 = new MyDelegate(sample3.DoIt);

            SampleRunner sampleRunner = new SampleRunner();
            sampleRunner.myDelegate = myDelegate3;
            sampleRunner.Run("Hello!");
        }
    }

    class SampleRunner
    {
        public MyDelegate myDelegate;
        public void Run(string message)
        {
            Thread.Sleep(1000);
            message += "@";
            myDelegate.Invoke(message);
        }
    }


    class Sample
    {
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Sample2
    {
        public void PrintInfo(string message)
        {
            using (StreamWriter sw = new StreamWriter("result.txt"))
            {
                sw.WriteLine(message);
            }
        }
    }

    class Sample3
    {
        public void DoIt(string msg)
        {
            Console.WriteLine(msg + "!!!" + msg);
        }
    }
}
