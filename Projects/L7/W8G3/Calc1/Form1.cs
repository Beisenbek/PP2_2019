using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc1
{
    public partial class Form1 : Form
    {
        Brain brain;
        public Form1()
        {
            InitializeComponent();
            brain = new Brain(new MyDelegate(ChangeDisplay));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            brain.Process(button.Text);
        }
        public void ChangeDisplay(string text)
        {
            textBox1.Text = text;
        }
    }

}
