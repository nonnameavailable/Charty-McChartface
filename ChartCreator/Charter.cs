using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;

namespace ChartCreator
{
	public class Charter
	{
		private Bitmap originalImage;
		private List<Bitmap> history;
		private List<Color> yarnColors;
		private List<Color> replacementYarnColors;
		private Bitmap chart;
		private Bitmap stockinetteChart;
		private Bitmap stockinetteStitchImg;
		public Charter()
		{
			history = new List<Bitmap>();
			YarnColors = new List<Color>();
			stockinetteStitchImg = new Bitmap(ChartCreator.Properties.Resources.stitch_stockinette);
		}

		public void generateChartFromArray(float hGauge, float vGauge, int vCount, float sqWidth, float meshThickness)
		{
			int[][] cArr = chartArray(hGauge, vGauge, vCount);
			float whRatio = vGauge / hGauge;
			float sqHeight = sqWidth / whRatio;
			int hCount = (int)((float)originalImage.Width / (float)originalImage.Height * vCount / whRatio);
			float chartWidth = sqWidth * hCount;
			float chartHeight = sqHeight * vCount;

			chart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics g = Graphics.FromImage(chart);

			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);

					g.FillRectangle(new SolidBrush(replacementYarnColors[cArr[j][i]]), cx, cy, sqWidth, sqHeight);
					if (meshThickness > 0) { g.DrawRectangle(new Pen(Color.Black, meshThickness), cx, cy, sqWidth, sqHeight); }
				}
			}
			chart.Save(Environment.CurrentDirectory + "\\chart.png", ImageFormat.Png);
			g.Dispose();
		}

		public void generateStockinetteChartFromArray(float hGauge, float vGauge, int vCount, float sqWidth, float meshThickness)
		{
			int[][] cArr = chartArray(hGauge, vGauge, vCount);
			float whRatio = vGauge / hGauge;
			float sqHeight = sqWidth / whRatio;
			int hCount = (int)((float)originalImage.Width / (float)originalImage.Height * vCount / whRatio);
			float chartWidth = sqWidth * hCount;
			float chartHeight = sqHeight * vCount;

			stockinetteChart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics scg = Graphics.FromImage(stockinetteChart);
			List<Bitmap> yarnColorStitches = ycsList((int)sqWidth, (int)sqHeight);

			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);

					scg.DrawImage(yarnColorStitches[cArr[j][i]], cx, cy);
				}
			}
			stockinetteChart.Save(Environment.CurrentDirectory + "\\stitched.png", ImageFormat.Png);
			scg.Dispose();
		}
		private Bitmap coloredStitchImg(int width, int height, Color c)
        {
			Bitmap stitchCopy = (Bitmap)stockinetteStitchImg.Clone();
			Bitmap result = new Bitmap(width, (int)(height * 2.16));
			Graphics g = Graphics.FromImage(result);
			for(int j = 0; j < stockinetteStitchImg.Height; j++)
            {
				for(int i = 0; i < stockinetteStitchImg.Width; i++)
                {
					if(stockinetteStitchImg.GetPixel(i, j).ToArgb() == Color.White.ToArgb())
                    {
						stitchCopy.SetPixel(i, j, c);
                    }
                }
            }
			g.DrawImage(stitchCopy, 0, 0, result.Width, result.Height);
			g.Dispose();
			stitchCopy.Dispose();
			return result;
        }

		private int[][] chartArray(float hGauge, float vGauge, int vCount)
		{
			float whRatio = vGauge / hGauge;
			int hCount = (int)((float)originalImage.Width / (float)originalImage.Height * vCount / whRatio);
			int[][] result = new int[vCount][];
			for (int j = 0; j < vCount; j++)
			{
				int[] r = new int[hCount];
				for (int i = 0; i < hCount; i++)
				{
					int x = (int)((float)(i + 0.5) / hCount * originalImage.Width);
					int y = (int)((float)(j + 0.5) / vCount * originalImage.Height);
					r[i] =  closestYarnColorIndex(originalImage.GetPixel(x, y));
				}
				result[j] = r;
			}
			return result;
		}

		private int closestYarnColorIndex(Color tc)
		{
			int result = 0;
			int dif = 765;
			foreach (Color yc in YarnColors)
			{
				int cdif = Math.Abs(yc.R - tc.R) + Math.Abs(yc.G - tc.G) + Math.Abs(yc.B - tc.B);
				if (cdif < dif)
				{
					dif = cdif;
					result = yarnColors.IndexOf(yc);
				}
			}
			return result;
		}

		private Color closestYarnColorHue(Color tc)
		{
			float sImportance = 0.99f;
			float bImportance = 0.99f;
			Color result = YarnColors[0];
			int dif = (int)(1080 + 0.5 * 360 + 0.5*360);
			foreach (Color yc in YarnColors)
			{
				int cdif = (int)(Math.Abs(yc.GetHue() - tc.GetHue()) + Math.Abs(yc.GetSaturation() * 360f * sImportance - tc.GetSaturation() * 360f * sImportance) + Math.Abs(yc.GetBrightness() * 360f * bImportance - tc.GetBrightness() * 360f * bImportance));
				if (cdif < dif)
				{
					dif = cdif;
					result = yc;
				}
			}
			return result;
		}

		private List<Bitmap> ycsList(int width, int height)
        {
			List<Bitmap> result = new List<Bitmap>();
			foreach(Color c in replacementYarnColors)
            {
				result.Add(coloredStitchImg(width, height, c));
            }
			return result;
        }

		public Bitmap OriginalImage { get => originalImage; set => originalImage = value; }
        public Bitmap Chart { get => chart; }
		public Bitmap StockinetteChart { get => stockinetteChart; }
        public List<Color> YarnColors { get => yarnColors; set => yarnColors = value; }
        public List<Color> ReplacementYarnColors { get => replacementYarnColors; set => replacementYarnColors = value; }
    }
}
