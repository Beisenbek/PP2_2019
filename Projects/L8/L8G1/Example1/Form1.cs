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

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Green);
            e.Graphics.DrawLine(pen, 0, 0, 100, 100);

            SolidBrush solidBrush = new SolidBrush(Color.Red);
            e.Graphics.FillRectangle(solidBrush, 120, 120, 200, 200);

            e.Graphics.FillEllipse(pen.Brush, 320, 320, 200, 200);

        }
    }
}
