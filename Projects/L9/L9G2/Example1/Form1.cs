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

namespace Example1
{
    public partial class Form1 : Form
    {
        int r = 30;
        int b = 40;
        int a = 40;
        SolidBrush brush = new SolidBrush(Color.Red);
        GraphicsPath gp = new GraphicsPath();

        public Form1()
        {
            InitializeComponent();
            gp.AddEllipse(new Rectangle(a - r, b - r, 2 * r, 2 * r));
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillPath(brush, gp);
            // e.Graphics.FillEllipse(brush, new Rectangle(a - r, b - r, 2 * r, 2 * r));
        }

        int Sqr(int v)
        {
            return v * v;
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            /*if (Sqr(e.X - a) + Sqr(e.Y - b) <= r * r)
            {
                brush.Color = Color.Green;
            }
            else
            {
                brush.Color = Color.Red;
            }*/

            if (gp.IsVisible(e.Location))
            {
                brush.Color = Color.Green;
            }
            else
            {
                brush.Color = Color.Red;
            }
            Refresh();
        }
    }
}
