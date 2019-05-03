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

        double f1(double x)
        {
            return x;
        }

        double f2(double x)
        {
            return Math.Sin((180 * x) / Math.PI);
        }
        double f3(double x)
        {
            return Math.Sin((180 * x) / Math.PI) + x;
        }

        double f4(double x)
        {
            return Math.Sin((180 * x) / Math.PI) * x;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            for (int i = 0; i < Height; i += 20)
            {
                e.Graphics.DrawLine(new Pen(Color.Gray), 0, i, Width, i);
                e.Graphics.DrawLine(new Pen(Color.Gray), i, 0, i, Height);
            }

            /*  DrawGraphic(e, new FDelegate(f1), Color.Black);
              DrawGraphic(e, new FDelegate(f2), Color.Green);
              DrawGraphic(e, new FDelegate(f3), Color.Blue);
              DrawGraphic(e, new FDelegate(f4), Color.Red);
              */

            if (points1.Count > 1)
            {
                e.Graphics.DrawCurve(new Pen(Color.Black, 1), points1.ToArray());
                e.Graphics.DrawCurve(new Pen(Color.Green, 1), points2.ToArray());
                e.Graphics.DrawCurve(new Pen(Color.Blue, 1), points3.ToArray());
                e.Graphics.DrawCurve(new Pen(Color.Red, 1), points4.ToArray());
            }
        }



        void DrawGraphic(PaintEventArgs e, FDelegate f, Color color)
        {
            List<PointF> points = new List<PointF>();

            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i += 0.1)
            {
                float x = (float)i * 50 + Width / 2;
                float y = -(float)f(i) * 50 + Width / 2;
                points.Add(new PointF { X = x, Y = y });
            }

            e.Graphics.DrawCurve(new Pen(color, 1), points.ToArray());
        }

        double i2 = -2*Math.PI;
        static List<PointF> points1 = new List<PointF>();
        static List<PointF> points2 = new List<PointF>();
        static List<PointF> points3 = new List<PointF>();
        static List<PointF> points4 = new List<PointF>();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            float x = (float)i2 * 50 + Width / 2;
            float y1 = -(float)f1(i2) * 50 + Width / 2;
            float y2 = -(float)f2(i2) * 50 + Width / 2;
            float y3 = -(float)f3(i2) * 50 + Width / 2;
            float y4 = -(float)f4(i2) * 50 + Width / 2;

            points1.Add(new PointF { X = x, Y = y1 });
            points2.Add(new PointF { X = x, Y = y2 });
            points3.Add(new PointF { X = x, Y = y3 });
            points4.Add(new PointF { X = x, Y = y4 });

            i2 += 0.1;
            Refresh();

            if (i2 >= 2 * Math.PI)
            {
                timer1.Enabled = false;
            }
        }
    }

    delegate double FDelegate(double v);
}
