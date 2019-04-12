using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example4
{
    class Student
    {
        public string name;
        public string gpa;
        public void PrintInfo()
        {
            Console.WriteLine(name + " " + gpa);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.name = "Omarov";
            s.gpa = "3.54";
            s.PrintInfo();
        }
    }
}
