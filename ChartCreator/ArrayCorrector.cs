using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartCreator
{
	class ArrayCorrector
	{

		public static int[][] correctedArray(int distThreshold, int countThreshold, int[][] arr)
		{
			int[][] newArray = IP.arrCopy(arr);
			//dictionary initialized here now, instance is passed into the dupeCount function and cleared after use
			Dictionary<int, int> colorCounts = new Dictionary<int, int>();
			for (int j = 0; j < arr.Length; j++)
			{
				for (int i = 0; i < arr[0].Length; i++)
				{
					int[] dcfac = dupeCountForAutoCorrect(i, j, distThreshold, countThreshold, arr, colorCounts);
					colorCounts.Clear();
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

		private static int[] dupeCountForAutoCorrect(int x, int y, int distThreshold, int countThreshold, int[][] arr, Dictionary<int, int> colorCounts)
		{
			int testedIndex = arr[y][x];
			int[] result = new int[2];

			for (int j = y - distThreshold; j <= y + distThreshold; j++)
			{
				for (int i = x - distThreshold; i <= x + distThreshold; i++)
				{
					//the conditions were changed to never throw exceptions, try catch removed
					if (!(i == x && j == y) && i > 0 && j > 0 && i < arr[0].Length && j < arr.Length)
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
				}
			}
			//returns the index with highest count. I don't understand this at all, ripped from Stack Overflow
			result[1] = colorCounts.Aggregate((xx, yy) => xx.Value > yy.Value ? xx : yy).Key;
			return result;
		}

		public static void testArr()
		{
			int maxIndex = 5;

			int arrWidth = 5000;
			int arrHeight = 6000;

			int distThreshold = 10;
			int countThreshold = 3;

			int[][] originalArray = new int[arrHeight][];
			Random rnd = new Random();
			for (int j = 0; j < arrHeight; j++)
			{
				int[] r = new int[arrWidth];
				for (int i = 0; i < arrWidth; i++)
				{
					int rndn = rnd.Next(maxIndex + 1); ;
					r[i] = rndn;
				}
				originalArray[j] = r;
			}
			DateTime nao = DateTime.Now;
			int[][] newArr = correctedArray(distThreshold, countThreshold, originalArray);
			Console.WriteLine((DateTime.Now - nao).TotalSeconds.ToString() + "seconds");

			//string origArrString = arrToString(originalArray);
			//string newArrString = arrToString(newArr);
			//Console.Write(origArrString + System.Environment.NewLine + newArrString);
		}

	}


}
