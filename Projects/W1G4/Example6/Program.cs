using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example6
{
    class Student
    {
        public string name;
        public string gpa;
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + gpa);
        }
        public static void SayHello()
        {
            Console.WriteLine("hello!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.name = "Omarov";
            s.gpa = "4.0";
            s.PrintInfo();

            Student.SayHello();
        }
    }
}
