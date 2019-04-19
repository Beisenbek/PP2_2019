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
    enum PaintToolState
    {
        Line,
        Rectangle,
        Pencil,
        Ellipse,
        Fill,
        Eraser
    }

    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Pen pen = new Pen(Color.Red);
        Pen eraserPen = new Pen(Color.White, 3);

        PaintToolState toolState = PaintToolState.Pencil;
        Point prevPoint;
        Point curPoint;
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            pictureBox1.Image = bitmap;

            //graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            eraserPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            eraserPen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void PencilBtn_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Pencil;
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Line;
        }

        private void RectangleBtn_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Rectangle;
        }

        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Ellipse;
        }

        private void FillBtn_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Fill;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                curPoint = e.Location;

                switch (toolState)
                {
                    case PaintToolState.Pencil:
                        graphics.DrawLine(pen, prevPoint, curPoint);
                        prevPoint = curPoint;
                        break;
                    case PaintToolState.Eraser:
                        graphics.DrawLine(eraserPen, prevPoint, curPoint);
                        prevPoint = curPoint;
                        break;
                    default:
                        break;
                }
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (toolState)
            {
                case PaintToolState.Line:
                    e.Graphics.DrawLine(pen, prevPoint, curPoint);
                    break;
                case PaintToolState.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
                    break;
                case PaintToolState.Pencil:
                    break;
                case PaintToolState.Ellipse:
                    e.Graphics.DrawEllipse(pen, GetRectangle(prevPoint, curPoint));
                    break;
                case PaintToolState.Fill:
                    break;
                default:
                    break;
            }
           
        }
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            switch (toolState)
            {
                case PaintToolState.Line:
                    graphics.DrawLine(pen, prevPoint, curPoint);
                    break;
                case PaintToolState.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(prevPoint, curPoint));
                    break;
                case PaintToolState.Pencil:
                    break;
                case PaintToolState.Ellipse:
                    graphics.DrawEllipse(pen, GetRectangle(prevPoint, curPoint));
                    break;
                case PaintToolState.Fill:
                    break;
                default:
                    break;
            }
        }

        Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle
            {
                X = Math.Min(p1.X, p2.X),
                Y = Math.Min(p1.Y, p2.Y),
                Height = Math.Abs(p1.Y - p2.Y),
                Width = Math.Abs(p1.X - p2.X)
            };
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            toolState = PaintToolState.Eraser;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (toolState == PaintToolState.Pencil)
            {
                pen.Width = int.Parse(numericUpDown1.Value.ToString());
            }
            else
            {
                eraserPen.Width = int.Parse(numericUpDown1.Value.ToString());
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            }
            else
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            }
        }
    }
}
