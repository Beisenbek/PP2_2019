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
        public string sname;
        public string gpa;

        /*public void Init(string name, string sname, string gpa)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;
        }*/

        public Student(string name, string sname, string gpa)
        {
            this.name = name;
            this.sname = sname;
            this.gpa = gpa;
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
            Student student = new Student("Omarov", "Kuanysh", "3.5");
            //student.Init("Omarov", "Kuanysh", "3.5");
            /*student.sname = "Omarov";
            student.name = "Kuanysh";
            student.gpa = "3.5";*/

            student.PrintInfo();

        }
    }
}
