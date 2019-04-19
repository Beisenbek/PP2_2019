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

namespace Example2
{
    public partial class Form1 : Form
    {
        SolidBrush brush = new SolidBrush(Color.Red);
        int r = 30;
        int a = 130;
        int b = 130;
        Point cPoint;

        public Form1()
        {
            InitializeComponent();
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(brush, new Rectangle(cPoint.X - r, cPoint.Y - r, 2 * r, 2 * r));
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                brush.Color = Color.Green;
                cPoint = e.Location;
            }
            else
            {
                brush.Color = Color.Red;
            }
            Refresh();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            cPoint = e.Location;
        }
    }
}
