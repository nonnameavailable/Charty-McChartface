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
		public const int colorMatchLab = 0;
		public const int colorMatchLinear = 1;
		public const int colorMatchCubic = 2;
		private Bitmap originalImage;
		private List<Color> yarnColors;
		private List<Color> replacementYarnColors;
		private Bitmap _chart;
		private Bitmap _stitchChart;
		private int[][] _chartArray;
		private int[][] _mapChartArray;
		private bool negativeGrid;
        #region properties
        public Bitmap OriginalImage { get => originalImage; set => originalImage = value; }
        public Bitmap Chart { get => _chart; }
		public Bitmap StitchChart { get => _stitchChart; }
        public List<Color> YarnColors { get => yarnColors; set => yarnColors = value; }
        public List<Color> ReplacementYarnColors { get => replacementYarnColors; set => replacementYarnColors = value; }
        public bool NegativeGrid { get => negativeGrid; set => negativeGrid = value; }
		public Bitmap Map { get; set; }
		public int[][] ChartArray { get => _chartArray; }
		public int[][] MapChartArray { get => _mapChartArray; }
        #endregion
		public Charter()
		{
			NegativeGrid = false;
			_chart = new Bitmap(50, 50);
			_stitchChart = new Bitmap(50, 50);
		}

		public bool generateChartFromArray(double sqWidth, double sqHeight, double meshThickness, bool drawNumbers, List<Color> colorList, int[][] array)
		{
			int hCount = 0;
			try
            {
				hCount = array[0].Length;
			} catch (NullReferenceException)
            {
				MessageBox.Show("Please create the chart first");
				return false;
            }
			_chart.Dispose();

			int vCount = array.Length;
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;
            try
            {
				_chart = new Bitmap((int)chartWidth, (int)chartHeight);
			}
            catch (ArgumentException)
            {
				MessageBox.Show("Your chart is probably too large :) Lower either stitch resolution or row count");
				return false;
            }
			
			Graphics g = Graphics.FromImage(_chart);

			for (int j = 0; j < vCount; j++)
			{
				int csCounter = 0;
				int prevColIndex = array[j][0];
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					Color stitchColor = Color.Black;
                    try
                    {
						stitchColor = colorList[array[j][i]];
					}
                    catch (ArgumentOutOfRangeException)
                    {
						MessageBox.Show("You most likely added or removed colors." + System.Environment.NewLine + "You must always use the create chart button after doing this");
						return false;
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
						int curColIndex = array[j][i];
						if (curColIndex != prevColIndex || i == hCount - 1)
						{
							float sx = (float)(cx - sqWidth * 1.1);
							float sy = cy - (float)(sqHeight * 0.06);
							Color textColor = colorList[array[j][i - 1]];
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
			_stitchChart.Dispose();
			int hCount = _chartArray[0].Length;
			int vCount = _chartArray.Length;
			double chartWidth = sqWidth * hCount;
			double chartHeight = sqHeight * vCount;

			_stitchChart = new Bitmap((int)chartWidth, (int)chartHeight);
			Graphics scg = Graphics.FromImage(_stitchChart);
			List<Bitmap> yarnColorStitches = ycsList((int)sqWidth, (int)sqHeight, stitch, widthStretch, heightStretch);
			List<Bitmap> yarnColorBackgrouns = ycsList((int)sqWidth, (int)sqHeight, stitchBackground, widthStretch, heightStretch);
			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					scg.DrawImage(yarnColorBackgrouns[_chartArray[j][i]], cx, cy);
				}
			}
			for (int j = 0; j < vCount; j++)
			{
				for (int i = 0; i < hCount; i++)
				{
					int cx = (int)(i * sqWidth);
					int cy = (int)(j * sqHeight);
					scg.DrawImage(yarnColorStitches[_chartArray[j][i]], cx, cy);
				}
			}
			scg.Dispose();
		}

		public void createChartArray(double hGauge, double vGauge, int vCount, int matchMode)
		{
			double whRatio = vGauge / hGauge;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			_chartArray = new int[vCount][];
			for (int j = 0; j < vCount; j++)
			{
				int[] r = new int[hCount];
				for (int i = 0; i < hCount; i++)
				{
					int x = (int)((double)(i + 0.5) / hCount * originalImage.Width);
					int y = (int)((double)(j + 0.5) / vCount * originalImage.Height);
					Color curCol = originalImage.GetPixel(x, y);
					int cci = closestYarnColorIndex(curCol, matchMode);
					r[i] =  cci;
				}
				_chartArray[j] = r;
			}
		}

		public void createChartArrayDitheredSerpent(double hGauge, double vGauge, int vCount, int matchMode)
		{
			double ri = 7 / 16d;
			double rd = 1 / 16d;
			double d = 5 / 16d;
			double ld = 3 / 16d;
			double whRatio = vGauge / hGauge;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			_chartArray = new int[vCount][];
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
					int cci = closestYarnColorIndex(curCol, matchMode);
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
				_chartArray[j] = r;
				errRow = newErrRow;
			}
		}
		public void CreateDitheredChartWithMap(double hGauge, double vGauge, int vCount, int matchMode, YCSHolder ycsh)
		{
			double ri = 7 / 16d;
			double rd = 1 / 16d;
			double d = 5 / 16d;
			double ld = 3 / 16d;
			double whRatio = vGauge / hGauge;
			int hCount = (int)((double)originalImage.Width / (double)originalImage.Height * vCount / whRatio);
			List<int[][]> mappedArrList = new List<int[][]>();
			foreach(YarnColorSelector ycs in ycsh.YCSList)
			{
				int[][] currentArr = new int[vCount][];
				List<Color> currentColors = ycs.MappedColors;
				
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
                        int cci = closestYarnColorIndex(curCol, matchMode, currentColors);
                        r[i] = cci;
                        Color quCol = currentColors[cci];

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
                    currentArr[j] = r;
                    errRow = newErrRow;
                }
				mappedArrList.Add(currentArr);
			}
			int[][] resultArr = new int[vCount][];
			List<int> countCumulationList = new List<int>();
			int cumulation = 0;
			for(int i = 0; i < ycsh.YCSList.Count; i++)
			{
				countCumulationList.Add(cumulation);
				cumulation += ycsh.YCSList[i].MappedColors.Count;
			}
            for(int j = 0; j < vCount; j++)
            {
                int[] r = new int[hCount];
                for(int i = 0; i < hCount; i++)
                {
                    int x = (int)((double)(i) / hCount * originalImage.Width);
                    int y = (int)((double)(j) / vCount * originalImage.Height);
                    Color mapColor = Map.GetPixel(x, y);
                    int closestMainColor = closestYarnColorIndex(mapColor, colorMatchCubic);
					//resultArr[j][i] = mappedArrList[closestMainColor][j][i] + countCumulationList[closestMainColor];
					r[i] = mappedArrList[closestMainColor][j][i] + countCumulationList[closestMainColor];
                }
				resultArr[j] = r;
            }
			_mapChartArray = resultArr;
		}

		private int closestYarnColorIndex(Color tc, int matchMode, List<Color> colorList = null)
        {
            switch(matchMode)
			{
				case colorMatchLinear:
					return closestYarnColorIndexLinear(tc, colorList);
				case colorMatchCubic:
					return closestYarnColorIndexCubic(tc, colorList);
				default:
					return closestYarnColorIndexLab(tc, colorList);
			}
        }

		private int closestYarnColorIndexLab(Color tc, List<Color> colorList = null)
		{
			int result = 0;
			double lDist = 10000;
			if (colorList == null) colorList = yarnColors;
			for (int i = 0; i < yarnColors.Count; i++)
			{
				Color yc = colorList[i];
				double cDist = CC.deltaE(yc, tc);
				if (cDist < lDist)
				{
					lDist = cDist;
					result = i;
				}
			}
			return result;
		}

		private int closestYarnColorIndexLinear(Color tc, List<Color> colorList = null)
		{
			int result = 0;
			int dif = 765;
			if (colorList == null) colorList = yarnColors;
			for (int i = 0; i < colorList.Count; i++)
			{
				Color yc = colorList[i];
				int cdif = Math.Abs(yc.R - tc.R) + Math.Abs(yc.G - tc.G) + Math.Abs(yc.B - tc.B);
				if (cdif < dif)
				{
					dif = cdif;
					result = i;
				}
			}
			return result;
		}
		private int closestYarnColorIndexCubic(Color tc, List<Color> colorList = null)
		{
			int result = 0;
			double lDist = 10000;
			if (colorList == null) colorList = yarnColors;
			for (int i = 0; i < colorList.Count; i++)
			{
				Color yc = colorList[i];
				double rDif = Math.Abs(yc.R - tc.R);
				double gDif = Math.Abs(yc.G - tc.G);
				double bDif = Math.Abs(yc.B - tc.B);
				double cDist = Math.Sqrt(Math.Pow(Math.Sqrt(rDif * rDif + gDif * gDif), 2) + bDif * bDif);
				if (cDist < lDist)
				{
					lDist = cDist;
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
				_chartArray[y][x] = colorIndex;
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

		public void autoCorrect(int distThreshold, int countThreshold)
        {
			_chartArray = ArrayCorrector.correctedArray(distThreshold, countThreshold, _chartArray);
		}

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
