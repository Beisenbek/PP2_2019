using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example2
{

    class Student3
    {
        public string GPA
        {
            get;
            set;
        }
    }

    class Student2
    {
        private string gpa;
        public string GPA
        {
            get { return gpa; }
            set
            {
                if (value.Length < 2)
                {

                }
                else
                {
                    gpa = value;
                }
            }
        }
    }
    class Student
    {
        private string gpa;
        public void SetGPA(string g)
        {
            if (g.Length < 2)
            {

            }
            else
            {
                gpa = g;
            }
        }
        public string GetGPA()
        {
            return gpa;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.SetGPA("3.6");
            s1.SetGPA("3");
            Console.WriteLine(s1.GetGPA());

            Student2 s2 = new Student2();
            s2.GPA = "3.6";
            s2.GPA = "3";
            Console.WriteLine(s2.GPA);

            Student2 s22 = new Student2 { GPA = "4.0" };
            Console.WriteLine(s22.GPA);

            Student3 s3 = new Student3 { GPA = "2.0" };
            Console.WriteLine(s3.GPA);
        }
    }
}
