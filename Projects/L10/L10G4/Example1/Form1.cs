using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        Pen pen0 = new Pen(Color.Gray, 4);
        Pen pen01 = new Pen(Color.Gray, 1);
        Pen pen1 = new Pen(Color.Brown, 2);
        Pen pen2 = new Pen(Color.Green, 2);
        Pen pen3 = new Pen(Color.Blue, 2);
        Pen pen4 = new Pen(Color.Red, 2);

        public Form1()
        {
            InitializeComponent();
            pen0.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //pen0.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawBorders(e);
            DrawF1(e);
            DrawF2(e);
            DrawF3(e);
            DrawF4(e);
        }

        private void DrawF2(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = (float)f2(i) * 50 + Width / 2 + 20;
                points.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen2, points.ToArray());
        }

        private void DrawF3(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = -(float)f3(i) * 50 + Width / 2 + 20;
                points.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen3, points.ToArray());
        }

        private void DrawF4(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = (float)f4(i) * 50 + Width / 2 + 20;
                points.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen4, points.ToArray());
        }

        double f1(double x)
        {
            return -x;
        }
        double f2(double x)
        {
            double t = (x * 180) / Math.PI;
            return Math.Sin(t);
        }
        double f3(double x)
        {
            double t = (x * 180) / Math.PI;
            return Math.Sin(t) + x;
        }
        double f4(double x)
        {
            double t = (x * 180) / Math.PI;
            return Math.Sin(t) * x;
        }

        private void DrawF1(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -Width/2; i < Width/2; i += 0.1)
            {
                float x = (float)i + Width / 2;
                float y = (float)f1(i) + Width / 2 + 20;
                points.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen1, points.ToArray());
        }

        private void DrawBorders(PaintEventArgs e)
        {
            e.Graphics.DrawLine(pen0, 30, Height / 2, Width - 30, Height / 2);
            e.Graphics.DrawLine(pen0, Width / 2, Height - 30, Width / 2, 30);
            for (int i = 0; i < Width; i += 20)
            {
                e.Graphics.DrawLine(pen01, 0, i, Width, i);
                e.Graphics.DrawLine(pen01, i, 0, i, Height);
            }
        }
    }
}
