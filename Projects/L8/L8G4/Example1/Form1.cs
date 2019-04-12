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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.Red);
            e.Graphics.DrawLine(pen, 10, 10, 300, 300);
            e.Graphics.DrawEllipse(pen, 10, 10, 300, 300);

            e.Graphics.FillRectangle(pen.Brush, 100, 100, 300, 300);

            SolidBrush solid = new SolidBrush(Color.FromArgb(255,255,255,0));
            e.Graphics.FillRectangle(solid, 300, 100, 300, 300);

            HatchBrush hBrush = new HatchBrush(HatchStyle.DiagonalBrick, Color.Red, Color.FromArgb(255, 128, 255, 255));
            e.Graphics.FillEllipse(hBrush, 0, 0, 100, 60);
        }
    }
}
