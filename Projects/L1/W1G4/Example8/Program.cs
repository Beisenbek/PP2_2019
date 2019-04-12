using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example8
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

    class Master : Student
    {
        string thesis;
        public Master(string n, string g, string t):base(n, g)
        {
            thesis = t;
        }
        public void PrintInfo2()
        {
            base.PrintInfo();
            Console.WriteLine(thesis);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Omarov", "4.0");
            s.PrintInfo();

            Master ms = new Master("Kuatov", "3.5", "C#");
            ms.PrintInfo2();

        }
    }
}
