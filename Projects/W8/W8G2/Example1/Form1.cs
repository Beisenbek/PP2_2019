using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("test!");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 2000;
            timer1.Start();
        }
    }
}
