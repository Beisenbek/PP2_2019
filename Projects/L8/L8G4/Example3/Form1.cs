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

namespace Example3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddRectangle(new Rectangle(30, 40, 100, 100));
            gp.AddRectangle(new Rectangle(135, 40, 50, 50));
            e.Graphics.FillPath(new Pen(Color.Green).Brush, gp);
        }
    }
}
