using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example3
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics graphics;
        Pen p = new Pen(Color.Red);
        public Form1()
        {
            InitializeComponent();
            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            graphics.DrawLine(p, 0, 0, 200, 200);
            pictureBox1.Image = bitmap;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bitmap.Save(saveFileDialog1.FileName);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                p.Color = colorDialog1.Color;
                graphics.FillEllipse(p.Brush, 50, 100, 200, 200);
                pictureBox1.Refresh();
            }
        }
    }
}
