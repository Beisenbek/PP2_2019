using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example9
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
        public override string ToString()
        {
            return name + " " + gpa;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //comment1
            Student s = new Student("Omarov", "4.0");
            Console.WriteLine(s);
        }
    }
}
