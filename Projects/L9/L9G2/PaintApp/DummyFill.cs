using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintApp
{
    class DummyFill
    {
        Queue<Point> q = new Queue<Point>();
        Bitmap bitmap;
        Color originColor;
        Color colorToFill;
        public void Fill(Bitmap bitmap, Color colorToFill, Point originPoint)
        {
            this.bitmap = bitmap;
            this.colorToFill = colorToFill;
            originColor = bitmap.GetPixel(originPoint.X, originPoint.Y);

            bitmap.SetPixel(originPoint.X, originPoint.Y, colorToFill);
            q.Enqueue(originPoint);

            while (q.Count > 0)
            {
                Point p = q.Dequeue();
                Step(p.X + 1, p.Y);
                Step(p.X, p.Y + 1);
                Step(p.X - 1, p.Y);
                Step(p.X, p.Y - 1);
            }
        }

        void Step(int x, int y)
        {
            if (x < 0 || y < 0) return;
            if (x >= bitmap.Width || y >= bitmap.Height) return;
            if (bitmap.GetPixel(x, y) != originColor) return;
            bitmap.SetPixel(x, y, colorToFill);
            q.Enqueue(new Point(x, y));
        }
    }
}
