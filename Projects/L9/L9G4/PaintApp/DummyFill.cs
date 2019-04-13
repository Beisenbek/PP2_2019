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
        Bitmap bmp;
        Point originPoint;
        Color originColor;
        Color colorToFill;
        public void Fill(Bitmap bmp, Point originPoint, Color colorToFill)
        {
            this.bmp = bmp;
            this.originPoint = originPoint;
            originColor = bmp.GetPixel(originPoint.X, originPoint.Y);
            this.colorToFill = colorToFill;

            q.Enqueue(originPoint);
            bmp.SetPixel(originPoint.X, originPoint.Y, colorToFill);

            while(q.Count != 0)
            {
                Point curPoint = q.Dequeue();
                Step(curPoint.X + 1, curPoint.Y);
                Step(curPoint.X - 1, curPoint.Y);
                Step(curPoint.X, curPoint.Y + 1);
                Step(curPoint.X, curPoint.Y - 1);
            }
        }

        private void Step(int x, int y)
        {
            if (x < 0 || y < 0) return;
            if (x >= bmp.Width || y >= bmp.Height) return;
            if (bmp.GetPixel(x, y) != originColor) return;
            bmp.SetPixel(x, y, colorToFill);
            q.Enqueue(new Point(x, y));
        }
    }
}
