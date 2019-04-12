using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateSample
{
    class Program
    {
        static void Main(string[] args)
        {

            PrintDelegate printDelegate = new PrintDelegate(BWPrintSilk);
            printDelegate += ColorPrint;
            printDelegate += BWPrint;

            PrinterJob printer = new PrinterJob(printDelegate);
            printer.Print("Hello!");
        }

        static void ColorPrint(string message)
        {
            Console.WriteLine("color: " + message);
        }
        static void BWPrint(string message)
        {
            Console.WriteLine("bw: " + message);
        }
        static void BWPrintSilk(string message)
        {
            Console.WriteLine("silk: " + message);
        }
    }

    delegate void PrintDelegate(string msg);

    class PrinterJob
    {
        PrintDelegate printDelegate;

        public void SetupDelegate(PrintDelegate printDelegate)
        {
            this.printDelegate = printDelegate;
        }
        public PrinterJob(PrintDelegate printDelegate)
        {
            this.printDelegate = printDelegate;
        }
        public void Print(string msg)
        {
            Thread.Sleep(2000);
            printDelegate.Invoke(msg);
        }
    }
}
