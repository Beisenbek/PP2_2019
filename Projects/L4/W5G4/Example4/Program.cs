using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Example4
{
    public class Complex
    {
        public double a;
        public double b;
        XmlSerializer xs = new XmlSerializer(typeof(Complex));
        string fname = "complex.xml";
        public void PrintInfo()
        {
            Console.WriteLine(string.Format("{0} + {1} * i", a, b));
        }

        public override string ToString()
        {
            return string.Format("{0} + {1}i", a, b);
        }

        public void Serialize()
        {
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, this);
            fs.Close();
        }

        public Complex Deserialize()
        {
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            Complex complex = xs.Deserialize(fs) as Complex;
            fs.Close();
            return complex;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex c = new Complex();
            c.a = 2;
            c.b = 3;
            c.PrintInfo();
            c.Serialize();

            Complex c2 = c.Deserialize();
            Console.WriteLine(c2);
        }
    }
}
