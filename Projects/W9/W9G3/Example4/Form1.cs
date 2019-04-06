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

namespace Example4
{
    public partial class Form1 : Form
    {
        Point prevPoint;
        Point currentPoint;
        Graphics graphics;
        Color color = Color.Red;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPoint = e.Location;
                graphics.DrawLine(new Pen(color), prevPoint, currentPoint);
                pictureBox1.Refresh();
                prevPoint = currentPoint;
                toolStripStatusLabel1.Text = string.Format("[X = {0}, Y = {1}]", e.X, e.Y);
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color = colorDialog1.Color;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddLine(100, 100, 200, 200);
            gp.AddEllipse(100, 100, 200, 200);
            gp.AddRectangle(new Rectangle(100,100,200,350));
            //graphics.DrawPath(new Pen(color), gp);
            graphics.FillPath(new Pen(color).Brush, gp);
            pictureBox1.Refresh();
        }
    }
}
