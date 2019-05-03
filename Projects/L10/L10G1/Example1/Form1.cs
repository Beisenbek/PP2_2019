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
        public Form1()
        {
            InitializeComponent();
        }
        Pen pen = new Pen(Color.Black,2);
        Pen pen1 = new Pen(Color.Gray, 1);

        double f1(double x)
        {
            return -x;
        }
        double f2(double x)
        {
            return -(Math.Sin((180 * x) / Math.PI));
        }
        double f3(double x)
        {
            return -(Math.Sin((180 * x) / Math.PI)) - x;
        }
        double f4(double x)
        {
            return -(Math.Sin((180 * x) / Math.PI)) * x;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Width; i += 20)
            {
                e.Graphics.DrawLine(pen1, 0, i, Width, i);
                e.Graphics.DrawLine(pen1, i, 0, i, Height);
            }

            e.Graphics.DrawLine(pen, 0, Height / 2, Width, Height / 2);
            e.Graphics.DrawLine(pen, Width / 2, 0, Width / 2, Height);

            G(e, new FDelegate(f1),Color.Black);
            G(e, new FDelegate(f2), Color.Green);
            G(e, new FDelegate(f3), Color.Blue);
            G(e, new FDelegate(f4), Color.Red);
        }

        /*void G1(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i*50 + Width / 2;
                float y = (float)f1(i)*25 + Width / 2;
                points.Add(new PointF { X = x, Y = y });
            }
            e.Graphics.DrawCurve(pen1, points.ToArray());
        }
        void G2(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i+=0.1)
            {
                float x = (float)i*50 + Width / 2;
                float y = (float)f2(i)*25 + Width / 2;
                points.Add(new PointF { X = x, Y =  y });
            }
            e.Graphics.DrawCurve(pen2, points.ToArray());
        }
        void G3(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = (float)f3(i) * 25 + Width / 2;
                points.Add(new PointF { X = x, Y = y });
            }
            e.Graphics.DrawCurve(pen3, points.ToArray());
        }

        void G4(PaintEventArgs e)
        {
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = (float)f4(i) * 25 + Width / 2;
                points.Add(new PointF { X = x, Y = y });
            }
            e.Graphics.DrawCurve(pen4, points.ToArray());
        }*/

        void G(PaintEventArgs e, FDelegate f, Color color)
        {
            Pen pen0 = new Pen(color, 2);
            List<PointF> points = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = (float)f(i) * 50 + Width / 2;
                points.Add(new PointF { X = x, Y = y });
            }
            e.Graphics.DrawCurve(pen0, points.ToArray());
        }

    }

    delegate double FDelegate(double x);
}
