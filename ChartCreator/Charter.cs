using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

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
		private int[][] chartArray;
		public Charter()
		{
			history = new List<Bitmap>();
			YarnColors = new List<Color>();
			stockinetteStitchImg = new Bitmap(ChartCreator.Properties.Resources.stitch_stockinette_lerp);
		}

		public void generateChartFromArray(double hGauge, double vGauge, int vCount, double sqWidth, double meshThickness)
		{
			double whRatio = vGauge / hGauge;
			double sqHeight = sqWidth / whRatio;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;

			chart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics g = Graphics.FromImage(chart);

			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					g.FillRectangle(new SolidBrush(replacementYarnColors[chartArray[j][i]]), cx, cy, (float)sqWidth, (float)sqHeight);
					if (meshThickness > 0) { g.DrawRectangle(new Pen(IP.negativeColor(replacementYarnColors[chartArray[j][i]]), (int)meshThickness), cx, cy, (int)sqWidth, (int)sqHeight); }


				}
			}
			chart.Save(Environment.CurrentDirectory + "\\chart.png", ImageFormat.Png);
			g.Dispose();
		}

		public void generateStockinetteChartFromArray(double hGauge, double vGauge, int vCount, double sqWidth, double meshThickness)
		{
			double whRatio = vGauge / hGauge;
			double sqHeight = sqWidth / whRatio;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;

			stockinetteChart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics scg = Graphics.FromImage(stockinetteChart);
			List<Bitmap> yarnColorStitches = ycsList((int)sqWidth, (int)sqHeight);

			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);

					scg.DrawImage(yarnColorStitches[chartArray[j][i]], cx, cy);
				}
			}
			stockinetteChart.Save(Environment.CurrentDirectory + "\\stitched.png", ImageFormat.Png);
			scg.Dispose();
		}

		private Bitmap coloredStitchImgLerp(int width, int height, Color c)
		{
			Bitmap result = new Bitmap(width, (int)(height * 2));
			Graphics g = Graphics.FromImage(result);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(stockinetteStitchImg, 0, 0, result.Width, result.Height);
			for (int j = 0; j < result.Height; j++)
			{
				for (int i = 0; i < result.Width; i++)
				{
					if (result.GetPixel(i, j).A > 0)
					{
						result.SetPixel(i, j, IP.lerpColor(c, Color.Black, (255 - result.GetPixel(i, j).R) / 255f));
					}
				}
			}
			g.Dispose();
			return result;
		}

		public void createChartArray(double hGauge, double vGauge, int vCount)
		{
			double whRatio = vGauge / hGauge;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			chartArray = new int[vCount][];
			for (int j = 0; j < vCount; j++)
			{
				int[] r = new int[hCount];
				for (int i = 0; i < hCount; i++)
				{
					int x = (int)((double)(i + 0.5) / hCount * originalImage.Width);
					int y = (int)((double)(j + 0.5) / vCount * originalImage.Height);
					r[i] =  closestYarnColorIndex(originalImage.GetPixel(x, y));
				}
				chartArray[j] = r;
			}
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

		private List<Bitmap> ycsList(int width, int height)
        {
			List<Bitmap> result = new List<Bitmap>();
			foreach(Color c in replacementYarnColors)
            {
				result.Add(coloredStitchImgLerp(width, height, c));
            }
			return result;
        }
        #region properties
        public Bitmap OriginalImage { get => originalImage; set => originalImage = value; }
        public Bitmap Chart { get => chart; }
		public Bitmap StockinetteChart { get => stockinetteChart; }
        public List<Color> YarnColors { get => yarnColors; set => yarnColors = value; }
        public List<Color> ReplacementYarnColors { get => replacementYarnColors; set => replacementYarnColors = value; }
		#endregion

		#region unused
		private Bitmap coloredStitchImgDithered(int width, int height, Color c)
		{
			Bitmap stitchCopy = (Bitmap)stockinetteStitchImg.Clone();
			Bitmap result = new Bitmap(width, (int)(height * 2.16));
			Graphics g = Graphics.FromImage(result);
			for (int j = 0; j < stockinetteStitchImg.Height; j++)
			{
				for (int i = 0; i < stockinetteStitchImg.Width; i++)
				{
					if (stockinetteStitchImg.GetPixel(i, j).ToArgb() == Color.White.ToArgb())
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
		#endregion
	}
}
