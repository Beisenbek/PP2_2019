using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example4
{
    public class Student
    {
        public string Name
        {
            get;
            set;
        }
        public string Gpa
        {
            get;
            set;
        }
        public Student()
        {

        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Name, Gpa);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            List<Student> students = new List<Student>();
            Random random = new Random(DateTime.Now.Second);

            for (int i = 0; i < 100; ++i)
            {
                students.Add(new Student
                {
                    Name = Guid.NewGuid().ToString(),
                    Gpa = random.Next(1, 4).ToString()
                });
            }

            FileStream fs = new FileStream("students.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Student>));
            xs.Serialize(fs, students);
            fs.Close();
        }
    }
}