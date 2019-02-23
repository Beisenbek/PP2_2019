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
            Console.WriteLine(string.Format("{0} {1}", name, gpa));
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
            FileStream fs = new FileStream("student.txt", FileMode.Open,FileAccess.Read);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
            Student student = xmlSerializer.Deserialize(fs) as Student;
            student.PrintInfo();
            fs.Close();
        }

        private static void F1()
        {
            Student student = new Student();
            student.gpa = "4.0";
            student.name = "AAAA";
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, student);
            fs.Close();
        }
    }
}
