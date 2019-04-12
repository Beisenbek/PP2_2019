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
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 255, 0, 0));
            e.Graphics.FillEllipse(solidBrush, 0, 0, 100, 60);

            HatchBrush hBrush = new HatchBrush(HatchStyle.DiagonalBrick,Color.Red,Color.FromArgb(255, 128, 255, 255));
            e.Graphics.FillEllipse(hBrush, 110, 0, 100, 160);
        }
    }
}
