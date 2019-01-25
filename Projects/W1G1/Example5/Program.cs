using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example5
{
    class Student
    {
        public string name;
        public string sname;
        public string gpa;

        public Student(string name, string sname, string gpa)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;
        }

        public Student()
        {
            sname = Console.ReadLine();
            name = Console.ReadLine();
            gpa = Console.ReadLine();
        }

        public void PrintInfo()
        {
            Console.WriteLine(sname);
            Console.WriteLine(name);
            Console.WriteLine(gpa);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student();
            s.PrintInfo();
        }
    }
}
