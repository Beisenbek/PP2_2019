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
        int d = 0;
        Color color = Color.Black;
        Color color2 = Color.Beige;

        Color[] colors = new Color[] { Color.Red, Color.Green, Color.Yellow, Color.Blue };
        int index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            HatchBrush hBrush = new HatchBrush(HatchStyle.DiagonalBrick, color, Color.FromArgb(255, 128, 255, 255));

            //e.Graphics.FillEllipse(new Pen(color, 3).Brush, 230 - d, 230 - d, 100 + 2 * d, 100 + 2 * d);

            e.Graphics.FillEllipse(hBrush, 230 - d, 230 - d, 200 + 2 * d, 200 + 2 * d);
            e.Graphics.DrawEllipse(new Pen(color2, 3), 430, 430, 60, 60);

        }

        Random random = new Random();
        private void Timer1_Tick(object sender, EventArgs e)
        {
            //color = Color.FromArgb(random.Next());
            index = (index + 1 ) % colors.Length;
            color = colors[index];
            d += 5;
            toolStripStatusLabel1.Text = string.Format("[d = {0}]", d);
            Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                color2 = colorDialog1.Color;
            }
        }
    }
}
