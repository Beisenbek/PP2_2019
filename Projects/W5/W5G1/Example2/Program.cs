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
        public string name;
        //[XmlIgnore]
        protected string gpa;
        public Student()
        {
            name = "AAAA";
            gpa = "3.4";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            Student t = xs.Deserialize(fs) as Student;

            fs.Close();
        }

        private static void F1()
        {
            Student s = new Student();

            FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Student));

            xs.Serialize(fs, s);

            fs.Close();
        }
    }
}
