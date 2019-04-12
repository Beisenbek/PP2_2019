using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example5
{
    public partial class Form1 : Form
    {
        Point prevPoint;
        Point currentPoint;
        Graphics graphics;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            pictureBox1.Image = bitmap;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = e.Location;
                graphics.DrawLine(new Pen(Color.Red), prevPoint, currentPoint);
                prevPoint = currentPoint;
                toolStripStatusLabel1.Text = string.Format("[X = {0}, Y = {1}]", e.X, e.Y);
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }
    }
}
