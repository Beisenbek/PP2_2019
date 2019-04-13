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
    enum Tool
    {
        Line,
        Pencil,
        Rectangle,
        Ellipse,
        Fill,
        Fill2
    }
    public partial class Form1 : Form
    {
        
        Bitmap bmp;
        Graphics graphics;
        Pen pen = new Pen(Color.Red, 2);
        Tool activeTool = Tool.Pencil;
        Point firstPoint;
        Point secondPoint;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bmp);
            graphics.Clear(Color.White);
            graphics.DrawLine(pen, 0,0,100,100);
            pictureBox1.Image = bmp;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            firstPoint = e.Location;
            if (activeTool == Tool.Fill)
            {
                DummyFill dummyFill = new DummyFill();
                dummyFill.Fill(bmp, e.Location, pen.Color);
                pictureBox1.Refresh();
            }
            else if (activeTool == Tool.Fill2)
            {
                MapFill mapFill = new MapFill();
                mapFill.Fill(graphics, e.Location, pen.Color, ref bmp);
                graphics = Graphics.FromImage(bmp);
                pictureBox1.Image = bmp;
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            secondPoint = e.Location;

            switch (activeTool)
            {
                case Tool.Line:
                    graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tool.Pencil:
                    graphics.DrawLine(pen, firstPoint, secondPoint);
                    firstPoint = secondPoint;
                    break;
                case Tool.Rectangle:
                    graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.Ellipse:
                    graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.Fill:
                    break;
                default:
                    break;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                secondPoint = e.Location;

                switch (activeTool)
                {
                    case Tool.Line:
                        break;
                    case Tool.Pencil:
                        graphics.DrawLine(pen, firstPoint, secondPoint);
                        firstPoint = secondPoint;
                        break;
                    case Tool.Rectangle:
                        break;
                    case Tool.Ellipse:
                        break;
                    case Tool.Fill:
                        break;
                    default:
                        break;
                }

                pictureBox1.Refresh();

            }
        }

        private void PencilBtn_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Pencil;
        }

        private void RectangleBtn_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Rectangle;
        }

        private void EllipseBtn_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Ellipse;
        }

        private void LineBtn_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Line;
        }

        private void FillBtn_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Fill;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            switch (activeTool)
            {
                case Tool.Line:
                    e.Graphics.DrawLine(pen, firstPoint, secondPoint);
                    break;
                case Tool.Pencil:
                    break;
                case Tool.Rectangle:
                    e.Graphics.DrawRectangle(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.Ellipse:
                    e.Graphics.DrawEllipse(pen, GetRectangle(firstPoint, secondPoint));
                    break;
                case Tool.Fill:
                    break;
                default:
                    break;
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

        private void GetColorFromDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            activeTool = Tool.Fill2;
        }
    }
}
