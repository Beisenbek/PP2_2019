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
        //[XmlIgnore]
        public string name;
        public string gpa;
        public Student()
        {

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
            F1();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("student.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Student));
            Student s = xs.Deserialize(fs) as Student;
            s.PrintInfo();
            fs.Close();
        }

        private static void F1()
        {
            Student s = new Student();
            s.name = "AAAA";
            s.gpa = "3.5";
            s.PrintInfo();

            FileStream fs = new FileStream("student.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            xs.Serialize(fs, s);

            fs.Close();
        }
    }
}
