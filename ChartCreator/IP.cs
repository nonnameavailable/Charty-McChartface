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

		public static double clamp(double value, double min, double max)
		{
			return (value < min) ? min : (value > max) ? max : value;
		}

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
		
		public static void ditheredImage(Bitmap source)
		{
			double ri = 7 / 16d;
			double rd = 1 / 16d;
			double d = 5 / 16d;
			double ld = 3 / 16d;
			double[,] errRow = new double[source.Width, 3];
			double[] right = new double[3];
			Bitmap result = new Bitmap(source.Width, source.Height);
			List<Color> palette = new List<Color>();
			palette.Add(Color.FromArgb(0, 0, 0));
			palette.Add(Color.FromArgb(255, 255, 255));
			for (int j = 0; j < source.Height; j++)
			{
				double[,] newErrRow = new double[source.Width, 3];
				bool forward = j % 2 == 0;
				for (int i = (forward ? 0 : source.Width - 1); forward ? i < source.Width : i >= 0; i += (forward ? 1 : -1))
				{
					int x = (int)((double)(i) / source.Width * source.Width);
					int y = (int)((double)(j) / source.Height * source.Height);
					Color c = source.GetPixel(x, y);
					double dR = clamp(c.R / 255d + right[0] + errRow[i, 0], 0, 1); //CLAMPING SHIFTED HERE
					double dG = clamp(c.G / 255d + right[1] + errRow[i, 1], 0, 1); //AND HERE
					double dB = clamp(c.B / 255d + right[2] + errRow[i, 2], 0, 1); //AND HERE
					Color curCol = Color.FromArgb((int)(dR * 255), (int)(dG * 255), (int)(dB * 255)); // THIS IS WHERE THE MISTAKE WAS
					Color closestPalCol = closestPaletteColor(palette, curCol);
					result.SetPixel(i, j, closestPalCol);

					double qR = closestPalCol.R / 255d;
					double qG = closestPalCol.G / 255d;
					double qB = closestPalCol.B / 255d;

					double rDif = dR - qR;
					double gDif = dG - qG;
					double bDif = dB - qB;

					if (i < source.Width - 1)
					{
						right[0] = rDif * ri;
						right[1] = gDif * ri;
						right[2] = bDif * ri;

						newErrRow[i + 1, 0] += rDif * rd;
						newErrRow[i + 1, 1] += gDif * rd;
						newErrRow[i + 1, 2] += bDif * rd;
					}
					if (i > 0)
					{
						newErrRow[i - 1, 0] += rDif * ld;
						newErrRow[i - 1, 1] += gDif * ld;
						newErrRow[i - 1, 2] += bDif * ld;
					}

					newErrRow[i, 0] += rDif * d;
					newErrRow[i, 1] += gDif * d;
					newErrRow[i, 2] += bDif * d;
				}
				errRow = newErrRow;
			}
			result.Save(@"C:\Users\Ondřej Baier\source\repos\dithertest.png", ImageFormat.Png);
		}

		public static Color closestPaletteColor(List<Color> palette, Color c)
		{
			Color result = palette[0];
			int dif = 765;
			foreach (Color pc in palette)
			{
				int cdif = Math.Abs(pc.R - c.R) + Math.Abs(pc.G - c.G) + Math.Abs(pc.B - c.B);
				if (cdif < dif)
				{
					dif = cdif;
					result = pc;
				}
			}
			return result;
		}
	}
}
