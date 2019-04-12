using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caclulator
{
    public partial class Form1 : Form
    {
        Brain brain;
        public Form1()
        {
            InitializeComponent();
            brain = new Brain(new DisplayTextDelegate(DisplayText));
        }

        void DisplayText(string msg)
        {
            textBox1.Text = msg;
        }

        void ButtonPresssed(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            brain.Process(btn.Text);
        }
    }
    public delegate void DisplayTextDelegate(string text);
}
