using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2G1
{

    class Student
    {
        string gpa;
        public void SetGPA(string g)
        {
            gpa = g;
        }
        public string GetGPA()
        {
            return gpa;
        }
    }

    class Student2
    {
        string gpa;
        public string GPA
        {
            get
            {
                return gpa;
            }
            set
            {
                if (value.Length <= 2)
                {
                    throw new Exception("not allowed!");
                }
                else
                {
                    gpa = value;
                }
            }
        }
    }

    class Student3
    {
        public string GPA
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           
            Student s = new Student();
            s.SetGPA("4.0");
            Console.WriteLine(s.GetGPA());


            Student2 s2 = new Student2();
            s2.GPA = "3.2";
            Console.WriteLine(s2.GPA);

            Student3 s3 = new Student3 { GPA = "4.0" };
            Console.WriteLine(s3.GPA);
        }
    }
}
