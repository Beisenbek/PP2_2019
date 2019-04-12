using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example6
{
    class Student
    {
        protected string name;
        protected string gpa;

        public Student(string name, string gpa)
        {
            this.name = name;
            this.gpa = gpa;
        }

        public void PrintInfo()
        {
            Console.WriteLine(name + " " + gpa);
        }
    }

    class MasterStudent : Student
    {
        public MasterStudent(string n, string g) : base(n, g)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s = new Student("Omarov", "3.54");
            s.PrintInfo();

            MasterStudent ms = new MasterStudent("Abaev", "4");
            ms.PrintInfo();
        }
    }
}
