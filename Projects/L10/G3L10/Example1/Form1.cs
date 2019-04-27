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

        Pen pen0 = new Pen(Color.Black);
        Pen pen1 = new Pen(Color.Red);
        Pen pen2 = new Pen(Color.Blue);
        Pen pen3 = new Pen(Color.Green);
        Pen pen4 = new Pen(Color.Yellow);

        float r = 2;

        float f1(float x)
        {
            return -x;
        }

        float f2(double x)
        {
            double res = Math.Sin((x * 180) / Math.PI);
            return (float)res;
        }
        float f3(double x)
        {
            double res = Math.Sin((x * 180) / Math.PI) - x;
            return (float)res;
        }
        float f4(double x)
        {
            double res = Math.Sin((x * 180) / Math.PI) * x;
            return (float)res;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            #region draw base lines
            e.Graphics.DrawLine(pen0, Width / 2, 0, Width / 2, Height);
            e.Graphics.DrawLine(pen0, 0, Height / 2, Width, Height / 2);
            #endregion
            #region draw y = x func
            List<PointF> points1 = new List<PointF>();
            for (float i = -Width; i <= Width; i = i + 0.5f)
            {
                float x = i  + Width / 2;
                float y = f1(i)  + Height / 2;
                points1.Add(new PointF(x, y));
            }
            e.Graphics.DrawLines(pen1, points1.ToArray());
            #endregion
            #region draw y = sin(x) func
            List<PointF> points2 = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i = i + 0.1f)
            {
                float x = (float)i * 50 + Width / 2;
                float y = f2(i) * 20 + Height / 2;
                points2.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen2, points2.ToArray());
            #endregion
            #region draw y = sin(x) + x func
            List<PointF> points3 = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i = i + 0.1f)
            {
                float x = (float)i * 50 + Width / 2;
                float y = f3(i) * 20 + Height / 2;
                points3.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen3, points3.ToArray());
            #endregion
            #region draw y = sin(x) * x func
            List<PointF> points4 = new List<PointF>();
            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i = i + 0.1f)
            {
                float x = (float)i * 50 + Width / 2;
                float y = f4(i) * 20 + Height / 2;
                points4.Add(new PointF(x, y));
            }
            e.Graphics.DrawCurve(pen4, points4.ToArray());
            #endregion
        }
    }
}
