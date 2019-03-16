using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Hello!");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            label1.Text = "sample text!";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += progressBar1.Step;
        }
    }
}
