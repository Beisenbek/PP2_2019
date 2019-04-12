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
        public Form1()
        {
            InitializeComponent();
        }

        int r = 10;
        Point p0 = new Point(250, 120);
        Point p1 = new Point(350, 140);
        Pen pen = new Pen(Color.Red);
        Pen pen2 = new Pen(Color.Red);
        int w = 50;
        int h = 50;

        Color[] color = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow};
        int index = 0;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.DrawEllipse(pen, p0.X - r, p0.Y - r, w + 2 * r, h + 2 * r);
            e.Graphics.FillEllipse(pen.Brush, p0.X - r, p0.Y - r, w + 2 * r, h + 2 * r);
            e.Graphics.FillEllipse(pen2.Brush, p1.X - r, p1.Y - r, w + 2 * r, h + 2 * r);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            index = (index + 1) % color.Length;
            pen2 = new Pen(color[index]);

            Random random = new Random();
            pen = new Pen(Color.FromArgb(random.Next()));
            r += 5;
            Refresh();

            toolStripStatusLabel1.Text = string.Format("[r = {0}]", r);
        }
    }
}
