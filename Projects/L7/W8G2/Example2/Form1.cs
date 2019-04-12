using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {
        Calculator calculator;
        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator(new MyDelegate(ChangeLabelValue));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            calculator.Calc();
        }

        private void ChangeLabelValue(string msg)
        {
            label1.Text = msg;
        }
    }

    public delegate void MyDelegate(string message);
}
