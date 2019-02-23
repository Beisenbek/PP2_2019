using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example5
{
    public class Student
    {
        public string Name { get; set; }
        public string Gpa { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream("student.xml", FileMode.Create, FileAccess.Write);

            List<Student> students = new List<Student>();
            Random random = new Random(DateTime.Now.Second);

            for (int i = 0; i < 1000; ++i)
            {
                students.Add(new Student
                {
                    Name = Guid.NewGuid().ToString(),
                    Gpa = random.Next(0, 4).ToString()
                });
            }

            xmlSerializer.Serialize(fs, students);

            fs.Close();
        }
    }
}
