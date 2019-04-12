using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example4
{
    enum Tool
    {
        Line,
        Rectangle
    }
    public partial class Form1 : Form
    {
        Tool tool = Tool.Line;
        Point prevPoint;
        Point curPoint;
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
            pictureBox1.Image = bitmap;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            Rectangle res = new Rectangle();
            res.X = Math.Min(p1.X, p2.X);
            res.Y = Math.Min(p1.Y, p2.Y);
            res.Width = Math.Abs(p1.X - p2.X);
            res.Height = Math.Abs(p1.Y - p2.Y);
            return res;
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (tool)
            {
                case Tool.Line:
                    graphics.DrawLine(p, prevPoint, e.Location);
                    break;
                case Tool.Rectangle:
                    graphics.DrawRectangle(p, GetRectangle(prevPoint, e.Location));
                    break;
                default:
                    break;
            }
            pictureBox1.Refresh();
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            switch (tool)
            {
                case Tool.Line:
                    e.Graphics.DrawLine(p, prevPoint, curPoint);
                    break;
                case Tool.Rectangle:
                    e.Graphics.DrawRectangle(p, GetRectangle(prevPoint, curPoint));
                    break;
                default:
                    break;
            }
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Line;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Rectangle;
        }
    }
}
