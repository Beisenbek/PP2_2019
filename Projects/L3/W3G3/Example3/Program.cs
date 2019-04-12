using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    class Program
    {
        static void Main(string[] args)
        {
            
            StreamWriter sw = File.CreateText("hello.txt");
            sw.WriteLine("test");
            sw.Close();
            File.Delete("hello.txt");
            /*

            FileStream fs =  File.Create("test.txt");
            fs.Close();
            File.Delete("test.txt");*/
        }
    }
}
