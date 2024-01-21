using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace ChartCreator
{
    class IP
    {
        public static Color negativeColor(Color c)
        {
            return(Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
        }

        public static Color lerpColor(Color c1, Color c2, double amount)
        {
            int newR = (int)(c1.R + (c2.R - c1.R) * amount);
            int newG = (int)(c1.G + (c2.G - c1.G) * amount);
            int newB = (int)(c1.B + (c2.B - c1.B) * amount);
            return Color.FromArgb(newR, newG, newB);
        }

        public static int clamp(int value, int min, int max)
        {
            return (value < min) ? min : (value > max) ? max : value;
        }

        public static Color contrastColor(Color c)
        {
            if(c.R + c.G + c.B > 382)
            {
                return Color.Black;
            }
            {
                return Color.White;
            }
        }

        public static Font fontToFitRect(string str, double sqWidth, double sqHeight, string fontName)
        {
            float resultSize = (float)(sqHeight);
            Font result = new Font(fontName, resultSize);
            SizeF strSize = TextRenderer.MeasureText(str, result);
            while (strSize.Height > sqHeight * 1.2)
            {
                resultSize *= 0.95F;
                result = new Font(fontName, resultSize);
                strSize = TextRenderer.MeasureText(str, result);
            }
            while (strSize.Width > sqWidth * 1.2)
            {
                resultSize *= 0.95F;
                result = new Font(fontName, resultSize);
                strSize = TextRenderer.MeasureText(str, result);
            }
            return result;
        }
    }
}
