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
        Bitmap bmp;
        Graphics gfx;
        Point prevPoint;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Red);
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);
            gfx.DrawLine(pen, 0, 0, 300, 300);
            pictureBox1.Image = bmp;
            pen.EndCap = LineCap.Round;
            pen.StartCap = LineCap.Round;
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                gfx.DrawLine(pen, prevPoint, e.Location);
                prevPoint = e.Location;
                pictureBox1.Refresh();
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath(FillMode.Winding);
            gp.AddRectangle(new Rectangle(30, 30, 400, 20));
            gp.AddEllipse(new Rectangle(35, 30, 50, 20));

            gfx.FillPath(pen.Brush, gp);
            pictureBox1.Refresh();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(saveFileDialog1.FileName);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = colorDialog1.Color;
            }
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = trackBar1.Value.ToString();
            pen.Width = trackBar1.Value;
        }
    }
}
