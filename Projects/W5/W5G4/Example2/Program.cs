using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example2
{
    public class Student
    {
        public Student()
        {
        }

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
            s.gpa = "4.0";
            s.name = "AAAA";

            XmlSerializer xs = new XmlSerializer(typeof(Student));
            FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, s);

            fs.Close();
        }
    }
}
