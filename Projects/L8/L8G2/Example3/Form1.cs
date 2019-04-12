using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        Point prevPoint;
        Bitmap bitmap;
        Graphics graphics;
        Pen p = new Pen(Color.Red);
        public Form1()
        {
            InitializeComponent();

            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.Clear(Color.White);
            graphics.DrawLine(p, 0, 0, 200, 200);
            pictureBox1.Image = bitmap;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
                graphics.FillEllipse(p.Brush, 50, 100, 200, 200);
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                toolStripStatusLabel1.Text = e.Location.ToString();
                graphics.DrawLine(p, prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            p.Width = trackBar1.Value;
        }
    }
}
