using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Green);
        SolidBrush solidBrush = new SolidBrush(Color.Red);
        HatchBrush hBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.Red, Color.FromArgb(255, 128, 255, 255));

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen, 10, 10, 400, 300);
            e.Graphics.DrawEllipse(pen, 40, 50, 200, 200);
            e.Graphics.FillEllipse(pen.Brush, 140, 150, 200, 200);
            e.Graphics.FillEllipse(solidBrush, 240, 100, 20, 20);

            e.Graphics.FillEllipse(hBrush, 340, 350, 200, 200);

        }
    }
}
