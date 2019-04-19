using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PaintApp
{
    public class GDI
    {
        public IntPtr CreateSolidBRUSH(uint color)
        {
            return CreateSolidBrush(color);
        }

        public bool ExtFloodFILL(IntPtr hdcSourse, int x, int y, uint сolorRefColor, uint nFillType)
        {
            return ExtFloodFill(hdcSourse, x, y, сolorRefColor, nFillType);
        }

        public IntPtr SelectOBJECT(IntPtr hDCSourse, IntPtr hBitmap)
        {
            return SelectObject(hDCSourse, hBitmap);
        }

        public IntPtr CreateCOMPATIBLEDC(IntPtr hdcSourse)
        {
            return CreateCompatibleDC(hdcSourse);
        }

        public bool DeleteOBJECT(IntPtr hObject)
        {
            return DeleteObject(hObject);
        }


        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport("gdi32", CharSet = CharSet.Auto)]
        private static extern bool ExtFloodFill(IntPtr hDC, int x, int y, uint сolorRefColor, uint nFillType);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
    }

    public class MapFill
    {
        public MapFill()
        {
        }
        /// <summary>
        /// Заливка области
        /// </summary>
        /// <param name="g">Графикс отображаемого объекта (например, панели)</param>
        /// <param name="pos">Точка, в которой начинается заливка</param>    
        /// <param name="colorFill">Цвет заливки</param>
        /// <param name="img">Битмап, который отображается на нашем объекте</param>
        public void Fill(Graphics g, Point pos, Color colorFill, ref Bitmap img)
        {
            GDI d = new GDI();

            // Цвет в точке, с которой начинается заливка


            Color colorBegin = img.GetPixel(pos.X, pos.Y);

            // DC панели
            IntPtr panelDC = g.GetHdc();

            // DC в памяти, совместимый с панелью
            IntPtr memDC = d.CreateCOMPATIBLEDC(panelDC);

            // Создаем и подсовываем свою кисть
            IntPtr hBrush = d.CreateSolidBRUSH((uint)ColorTranslator.ToWin32(colorFill));
            IntPtr hOldBr = d.SelectOBJECT(memDC, hBrush);

            // Подсовываем свой битмап
            IntPtr hBMP = img.GetHbitmap();
            IntPtr hOldBmp = d.SelectOBJECT(memDC, hBMP);

            // Заливаем (заливается благодаря совместимости с панелью, в противном случае 
            // заливки на битмапе не произойдет)
            d.ExtFloodFILL(memDC, pos.X, pos.Y, (uint)ColorTranslator.ToWin32(colorBegin), 1);

            // Записываем полученный залитый битмап в наш битмап
            img.Dispose();
            img = Bitmap.FromHbitmap(hBMP);

            // Возвращаем на место предыдущие кисть и битмап
            d.SelectOBJECT(memDC, hOldBr);
            d.SelectOBJECT(memDC, hOldBmp);

            // Освобождаем использованные ресурсы
            d.DeleteOBJECT(hBMP);
            d.DeleteOBJECT(hBrush);
            d.DeleteOBJECT(memDC);
            g.ReleaseHdc(panelDC);
        }
    }
}
