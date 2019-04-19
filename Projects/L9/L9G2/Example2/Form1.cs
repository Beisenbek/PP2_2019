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
        int a = 100;
        int b = 100;
        int r = 30;

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
        }

        bool isVisible = false;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (gp.IsVisible(e.Location))
            {
                isVisible = true;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && isVisible)
            {
                a = e.Location.X - r;
                b = e.Location.Y - r;
                gp.Reset();
                brush.Color = Color.Green;
                gp.AddEllipse(new Rectangle(a, b, 2 * r, 2 * r));
                Refresh();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isVisible = false;
            brush.Color = Color.Red;
            Refresh();
        }
    }
}
