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
    public class Student
    {
        public string name;

        [NonSerialized]
        public string gpa;
    }

    class Program
    {
        static void Main(string[] args)
        {
            F2();
        }

        private static void F1()
        {
            Student s = new Student();
            s.name = "AAAA";
            s.gpa = "3.5";

            FileStream fs = new FileStream("student.txt", FileMode.OpenOrCreate, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(fs, s);

            fs.Close();
        }

        private static void F2()
        {
            FileStream fs = new FileStream("student.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();

            Student t =  bf.Deserialize(fs) as Student;

            fs.Close();
        }
    }
}
