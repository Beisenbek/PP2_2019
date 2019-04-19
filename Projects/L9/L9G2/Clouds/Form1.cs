using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clouds
{
    public partial class Form1 : Form
    {
        List<Bitmap> parts = new List<Bitmap>();
        int index = 0;
        public Form1()
        {
            InitializeComponent();
            Bitmap bitmap0 = Bitmap.FromFile(@"clouds/0.png") as Bitmap;
            Bitmap bitmap1 = Bitmap.FromFile(@"clouds/1.png") as Bitmap;
            Bitmap bitmap2 = Bitmap.FromFile(@"clouds/2.png") as Bitmap;
            Bitmap bitmap3 = Bitmap.FromFile(@"clouds/3.png") as Bitmap;
            parts.Add(bitmap0);
            parts.Add(bitmap1);
            parts.Add(bitmap2);
            parts.Add(bitmap3);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            index = (index + 1) % parts.Count;
            pictureBox1.Image = parts[index];
        }
    }
}
