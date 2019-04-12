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
        //[NonSerialized]
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
            F2();
        }

        private static void F2()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            Student student = bf.Deserialize(fs) as Student;
            student.PrintInfo();
            fs.Close();
        }

        private static void F1()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Student s = new Student();
            s.name = "AAAA";
            s.gpa = "3.5";

            FileStream fs = new FileStream("student.txt", FileMode.Create, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }
    }
}
