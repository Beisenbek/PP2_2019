using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Example3
{
    [Serializable]
    class Student
    {
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
            F1();
        }

        private static void F2()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("student.bin", FileMode.Open, FileAccess.Read);
            Student t = binaryFormatter.Deserialize(fileStream) as Student;
            t.PrintInfo();
            fileStream.Close();
        }

        private static void F1()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStream = new FileStream("student.bin", FileMode.Create, FileAccess.Write);

            Student s = new Student();
            s.gpa = "4.0";
            s.name = "AAAA";

            binaryFormatter.Serialize(fileStream, s);

            fileStream.Close();
        }
    }
}
