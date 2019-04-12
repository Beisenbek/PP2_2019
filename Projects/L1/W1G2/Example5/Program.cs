using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5
{
    class Student
    {
        string name;
        string gpa;

        public Student(string n, string g)
        {
            name = n;
            gpa = g;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + " " + gpa);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Omarov", "3.54");
            s.PrintInfo();
        }
    }
}
