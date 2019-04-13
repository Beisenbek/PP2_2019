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
        Queue<Point> queue = new Queue<Point>();
        Color originColor;
        Bitmap bitmap;
        void Step(int x, int y, Color fillColor)
        {
            if (x < 0 || x >= bitmap.Width) return;
            if (y < 0 || y >= bitmap.Height) return;
            if (bitmap.GetPixel(x, y) != originColor) return;
            bitmap.SetPixel(x, y, fillColor);
            queue.Enqueue(new Point(x, y));
        }
        public void Fill(Bitmap bitmap, Point originPoint, Color fillColor)
        {
            this.bitmap = bitmap;
            originColor = bitmap.GetPixel(originPoint.X, originPoint.Y);
            bitmap.SetPixel(originPoint.X, originPoint.Y, fillColor);
            queue.Enqueue(originPoint);

            while(queue.Count != 0)
            {
                Point curPoint = queue.Dequeue();
                Step(curPoint.X + 1, curPoint.Y, fillColor);
                Step(curPoint.X, curPoint.Y + 1, fillColor);
                Step(curPoint.X - 1, curPoint.Y, fillColor);
                Step(curPoint.X, curPoint.Y - 1, fillColor);
            } 
        }
    }
}
