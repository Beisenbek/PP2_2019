using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintApp
{
    enum Tools
    {
        Pencil,
        Rectangle,
        Line,
        Ellipse,
        Fill,
        Fill2
    }
    public partial class Form1 : Form
    {
        Tools currTool = Tools.Pencil;
        Point firstPoint;
        Point secondPoint;
        Graphics graphics;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Red, 3);
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);

            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;

            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            currTool = Tools.Line;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            currTool = Tools.Rectangle;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            currTool = Tools.Ellipse;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            currTool = Tools.Pencil;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            currTool = Tools.Fill;
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle
            {
                X = Math.Min(p1.X, p2.X),
                Y = Math.Min(p1.Y, p2.Y),
                Width = Math.Abs(p1.X - p2.X),
                Height = Math.Abs(p1.Y - p2.Y)
            };
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (currTool == Tools.Fill)
            {
                DummyFill dummyFill = new DummyFill();
                dummyFill.Fill(bitmap, pen.Color, e.Location);
                pictureBox1.Refresh();
            }
            else if (currTool == Tools.Fill2)
            {
                MapFill mapFill = new MapFill();
                mapFill.Fill(graphics, e.Location, pen.Color, ref bitmap);

                graphics = Graphics.FromImage(bitmap);
                pictureBox1.Image = bitmap;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (currTool)
            {
                case Tools.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Line:
                    graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Ellipse:
                    graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;
                switch (currTool)
                {
                    case Tools.Pencil:
                        graphics.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tools.Rectangle:
                        break;
                    case Tools.Line:
                        break;
                    case Tools.Ellipse:
                        break;
                    case Tools.Fill:
                        break;
                    default:
                        break;
                }

                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (currTool)
            {
                case Tools.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tools.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tools.Ellipse:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
            }
        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            else
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = int.Parse(numericUpDown1.Value.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            currTool = Tools.Fill2;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            graphics.Clear(Color.White);
            pictureBox1.Refresh();
        }
    }
}
