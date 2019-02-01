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
        public string thesis;
        public Master(string n, string g, string t):base(n, g)
        {
            thesis = t;
        }

        public void PrintInfo2()
        {
            base.PrintInfo();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Omarov", "3.5");
            Student s2 = new Student("Talipov", "4.0");
            /*s.name = "Omarov";
            s.gpa = "3.5";*/
            s.PrintInfo();
            s2.PrintInfo();
            Master m = new Master("Sabitov", "3.6", "C#");
            m.PrintInfo2();
        }
    }
}
