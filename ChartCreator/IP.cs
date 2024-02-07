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
		public static int[][] correctedArray(int distThreshold, int countThreshold, int[][] arr)
		{
			int[][] newArray = arrCopy(arr);
			for (int j = 0; j < arr.Length; j++)
			{
				for (int i = 0; i < arr[0].Length; i++)
				{
					int[] dcfac = dupeCountForAutoCorrect(i, j, distThreshold, countThreshold, arr);
					int dupeCount = dcfac[0];
					int replacementIndex = dcfac[1];
					if (dupeCount <= countThreshold)
					{
						newArray[j][i] = replacementIndex;
					}
				}
			}
			return newArray;
		}
		private static int[] dupeCountForAutoCorrect(int x, int y, int distThreshold, int countThreshold, int[][] arr)
		{
			int testedIndex = arr[y][x];
			int[] result = new int[2];
			Dictionary<int, int> colorCounts = new Dictionary<int, int>();

			for (int j = y - distThreshold; j <= y + distThreshold; j++)
			{
				for (int i = x - distThreshold; i <= x + distThreshold; i++)
				{
					if (!(i == x && j == y))
					{
						try
						{
							int currentIndex = arr[j][i];
							if (currentIndex == testedIndex) result[0]++;
							if (result[0] > countThreshold) return result;
							if (colorCounts.TryGetValue(currentIndex, out int value))
							{
								value++;
								colorCounts[currentIndex] = value;
							}
							else
							{
								colorCounts.Add(currentIndex, 1);
							}
						}
						catch (IndexOutOfRangeException)
						{
							//do nothing and continue
						}

					}
				}
			}
			//returns the index with highest count. I don't understand this at all, ripped from Stack Overflow
			result[1] = colorCounts.Aggregate((xx, yy) => xx.Value > yy.Value ? xx : yy).Key;
			return result;
		}

		private static void testArr()
        {
			int maxIndex = 5;

			int arrWidth = 5;
			int arrHeight = 5;

			int distThreshold = 1;
			int countThreshold = 0;

			int[][] originalArray = new int[arrHeight][];
			Random rnd = new Random();
			for(int j = 0; j < arrHeight; j++)
            {
				int[] r = new int[arrWidth];
				for(int i = 0; i < arrWidth; i++)
                {
					int rndn = rnd.Next(maxIndex + 1); ;
					r[i] = rndn;
                }
				originalArray[j] = r;
			}
			DateTime nao = DateTime.Now;
			int[][] newArr = correctedArray(distThreshold, countThreshold, originalArray);
			Console.WriteLine((DateTime.Now - nao).TotalSeconds.ToString() + "seconds");

			string origArrString = arrToString(originalArray);
			string newArrString = arrToString(newArr);
			Console.Write(origArrString + System.Environment.NewLine + newArrString);
		}
		public static string arrToString(int[][] arr)
		{
			string result = "";
			for (int j = 0; j < arr.Length; j++)
			{
				result += "[";
				for (int i = 0; i < arr[0].Length; i++)
				{
					int val = arr[j][i];
					result += val + (i == arr[0].Length - 1 ? "]" + System.Environment.NewLine : ", ");
				}
			}
			return result;
		}

		public static int[][] arrCopy(int[][] arr)
		{
			int[][] result = new int[arr.Length][];
			for (int j = 0; j < arr.Length; j++)
			{
				result[j] = new int[arr[0].Length];
				for (int i = 0; i < arr[0].Length; i++)
				{
					result[j][i] = arr[j][i];
				}
			}
			return result;
		}
	}
}
