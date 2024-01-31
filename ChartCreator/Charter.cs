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
using ChartCreator.Properties;

namespace ChartCreator
{
	public class Charter
	{
		private Bitmap originalImage;
		private List<Color> yarnColors;
		private List<Color> replacementYarnColors;
		private Bitmap chart;
		private Bitmap stitchChart;
		private int[][] chartArray;
		private bool negativeGrid;
		public Charter()
		{
			NegativeGrid = false;
			chart = new Bitmap(50, 50);
			stitchChart = new Bitmap(50, 50);
		}

		public bool generateChartFromArray(double sqWidth, double sqHeight, double meshThickness, bool drawNumbers)
		{
			chart.Dispose();
			int hCount = chartArray[0].Length;
			int vCount = chartArray.Length;
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;
            try
            {
				chart = new Bitmap((int)chartWidth, (int)chartHeight);
			}
            catch (ArgumentException)
            {
				MessageBox.Show("Your chart is probably too large :) Lower either stitch resolution or row count");
				return false;
            }
			
			Graphics g = Graphics.FromImage(chart);

			for (int j = 0; j < vCount; j++)
			{
				int csCounter = 0;
				int prevColIndex = chartArray[j][0];
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					Color stitchColor = Color.Black;
                    try
                    {
						stitchColor = replacementYarnColors[chartArray[j][i]];
					}
                    catch (ArgumentOutOfRangeException)
                    {
						MessageBox.Show(replacementYarnColors.Count.ToString() + " x " + chartArray[j][i].ToString());
					}
					g.FillRectangle(new SolidBrush(stitchColor), cx, cy, (float)sqWidth, (float)sqHeight);
					if (meshThickness > 0)
					{
						Color gridColor = Color.Black;
						if (NegativeGrid) gridColor = IP.contrastColor(stitchColor);
						g.DrawRectangle(new Pen(gridColor, (int)meshThickness), cx, cy, (int)sqWidth, (int)sqHeight);
					}

                    if (drawNumbers)
                    {
						int curColIndex = chartArray[j][i];
						if (curColIndex != prevColIndex || i == hCount - 1)
						{
							float sx = (float)(cx - sqWidth * 1.1);
							float sy = cy - (float)(sqHeight * 0.06);
							Color textColor = replacementYarnColors[chartArray[j][i - 1]];
							if (i == hCount - 1)
                            {
								sx = cx;
								csCounter++;
								textColor = stitchColor;
							}
							g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
							String numberToDraw = csCounter.ToString();
							Font drawFont = IP.fontToFitRect(numberToDraw, sqWidth, sqHeight, "Arial");
							SolidBrush drawBrush = new SolidBrush(IP.contrastColor(textColor));
							g.DrawString(numberToDraw, drawFont, drawBrush, sx, sy);
							csCounter = 1;
						}
						else
						{
							csCounter++;
						}
						prevColIndex = curColIndex;
					}
					
				}
			}
			g.Dispose();
			return true;
		}

		public void generateStitchedChart(double sqWidth, double sqHeight, Bitmap stitchBackground, Bitmap stitch, double widthStretch, double heightStretch)
		{
			stitchChart.Dispose();
			int hCount = chartArray[0].Length;
			int vCount = chartArray.Length;
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;

			stitchChart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics scg = Graphics.FromImage(stitchChart);
			List<Bitmap> yarnColorStitches = ycsList((int)sqWidth, (int)sqHeight, stitch, widthStretch, heightStretch);
			List<Bitmap> yarnColorBackgrouns = ycsList((int)sqWidth, (int)sqHeight, stitchBackground, widthStretch, heightStretch);
			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					scg.DrawImage(yarnColorBackgrouns[chartArray[j][i]], cx, cy);
				}
			}
			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					scg.DrawImage(yarnColorStitches[chartArray[j][i]], cx, cy);
				}
			}
			scg.Dispose();
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
					Color curCol = originalImage.GetPixel(x, y);
					int cci = closestYarnColorIndex(curCol);
					r[i] =  cci;
				}
				chartArray[j] = r;
			}
		}

		public void createChartArrayDitheredSerpent(double hGauge, double vGauge, int vCount)
		{
			double ri = 7 / 16d;
			double rd = 1 / 16d;
			double d = 5 / 16d;
			double ld = 3 / 16d;
			double whRatio = vGauge / hGauge;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			chartArray = new int[vCount][];
			double[,] errRow = new double[hCount, 3];
			double[] right = new double[3];
			for (int j = 0; j < vCount; j++)
			{
				int[] r = new int[hCount];
				double[,] newErrRow = new double[hCount, 3];
				bool forward = j % 2 == 0;
				for (int i = (forward ? 0 : hCount - 1); forward ? i < hCount : i >= 0; i += (forward ? 1 : -1))
				{
					int x = (int)((double)(i) / hCount * originalImage.Width);
					int y = (int)((double)(j) / vCount * originalImage.Height);
					Color c = originalImage.GetPixel(x, y);
					double dR = IP.clamp(c.R / 255d + right[0] + errRow[i, 0], 0, 1);
					double dG = IP.clamp(c.G / 255d + right[1] + errRow[i, 1], 0, 1);
					double dB = IP.clamp(c.B / 255d + right[2] + errRow[i, 2], 0, 1);
					Color curCol = Color.FromArgb((int)(dR * 255), (int)(dG * 255), (int)(dB * 255));
					int cci = closestYarnColorIndex(curCol);
					r[i] = cci;
					Color quCol = yarnColors[cci];

					double qR = quCol.R / 255d;
					double qG = quCol.G / 255d;
					double qB = quCol.B / 255d;

					double rDif = dR - qR;
					double gDif = dG - qG;
					double bDif = dB - qB;

					if (i < hCount - 1)
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
				chartArray[j] = r;
				errRow = newErrRow;
			}
		}

		private int closestYarnColorIndex(Color tc)
		{
			int result = 0;
			int dif = 765;
			for(int i = 0; i < yarnColors.Count; i++)
            {
				Color yc = yarnColors[i];
				int cdif = Math.Abs(yc.R - tc.R) + Math.Abs(yc.G - tc.G) + Math.Abs(yc.B - tc.B);
				if (cdif < dif)
				{
					dif = cdif;
					result = i;
				}
			}
			return result;
		}

		private Bitmap coloredStitchImgLerp(int width, int height, Color c, Bitmap stitchImg, double widthMultiplier, double heightMultiplier)
		{
			Bitmap result = new Bitmap((int)(width * widthMultiplier), (int)(height * heightMultiplier));
			Graphics g = Graphics.FromImage(result);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
			g.DrawImage(stitchImg, 0, 0, result.Width, result.Height);
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

		private List<Bitmap> ycsList(int width, int height, Bitmap stitchImg, double widthMultiplier, double heightMultiplier)
        {
			List<Bitmap> result = new List<Bitmap>();
			foreach(Color c in replacementYarnColors)
            {
				result.Add(coloredStitchImgLerp(width, height, c, stitchImg, widthMultiplier, heightMultiplier));
            }
			return result;
        }

		public void setGrid(int x, int y, int colorIndex)
        {
			try
			{
				chartArray[y][x] = colorIndex;
			}
			catch (Exception ex)
			{
				if(ex is ArgumentOutOfRangeException)
                {

                } else if(ex is ArgumentNullException)
                {
					MessageBox.Show("Please create the chart first :)");
					return;
                }
			}
			
        }
        #region properties
        public Bitmap OriginalImage { get => originalImage; set => originalImage = value; }
        public Bitmap Chart { get => chart; }
		public Bitmap StitchChart { get => stitchChart; }
        public List<Color> YarnColors { get => yarnColors; set => yarnColors = value; }
        public List<Color> ReplacementYarnColors { get => replacementYarnColors; set => replacementYarnColors = value; }
        public bool NegativeGrid { get => negativeGrid; set => negativeGrid = value; }
        #endregion

        #region unused
        private Bitmap coloredStitchImgDithered(int width, int height, Color c)
		{

			Bitmap stitchCopy = (Bitmap)Resources.stitch_stockinette.Clone();
			Bitmap result = new Bitmap(width, (int)(height * 2.16));
			Graphics g = Graphics.FromImage(result);
			for (int j = 0; j < stitchCopy.Height; j++)
			{
				for (int i = 0; i < stitchCopy.Width; i++)
				{
					if (stitchCopy.GetPixel(i, j).ToArgb() == Color.White.ToArgb())
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
