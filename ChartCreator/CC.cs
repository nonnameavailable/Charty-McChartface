using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ChartCreator
{
    static class CC
    {
        private const double lumX = 95.047;
        private const double lumY = 100;
        private const double lumZ = 108.883;
        //private const double lumX = 96.4212;
        //private const double lumY = 100;
        //private const double lumZ = 82.5188;
        public static double colorDistanceXYZ(Color c1, Color c2)
		{
			double[] c1XYZ = CIEXYZfromRGB(c1);
			double[] c2XYZ = CIEXYZfromRGB(c2);
			return Math.Sqrt(Math.Pow(c1XYZ[0] - c2XYZ[0], 2) + Math.Pow(c1XYZ[1] - c2XYZ[1], 2) + Math.Pow(c1XYZ[2] - c2XYZ[2], 2));
		}

		public static double[] CIEXYZfromRGB(Color c)
		{
			double[] result = new double[3];
			double lr = linearFromRGB(c.R / 255d) * 100d;
			double lg = linearFromRGB(c.G / 255d) * 100d;
			double lb = linearFromRGB(c.B / 255d) * 100d;
			result[0] = lr * 0.412453 + lg * 0.357580 + lb * 0.180423;
			result[1] = lr * 0.212671 + lg * 0.715160 + lb * 0.072169;
			result[2] = lr * 0.019334 + lg * 0.119193 + lb * 0.950227;

			return result;
		}

		private static double linearFromRGB(double num)
		{
			if (num <= 0.04045)
			{
				return num / 12.92;
			}
			else
			{
				return Math.Pow((num + 0.055) / 1.055, 2.4);
			}
		}

		private static double LfromXYZ(double[] xyz)
		{
			double plum = 6 / 29d;
			double t = xyz[1] / lumY;
			bool fCond = t > Math.Pow(plum, 3);
			double ft;
			if (fCond)
			{
				ft = Math.Pow(t, 1 / 3d);
			}
			else
			{
				ft = t * Math.Pow(plum, -2) / 3 + 4 / 29d;
			}
			return 116 * ft - 16;
		}

		private static double aFromXYZ(double[] xyz)
		{
			double plum = 6 / 29d;
			double t1 = xyz[0] / lumX;
			bool fCond1 = t1 > Math.Pow(plum, 3);
			double t2 = xyz[1] / lumY;
			bool fCond2 = t2 > Math.Pow(plum, 3);
			double ft1, ft2;
			if (fCond1)
			{
				ft1 = Math.Pow(t1, 1 / 3d);
			}
			else
			{
				ft1 = t1 * Math.Pow(plum, -2) / 3 + 4 / 29d;
			}
			if (fCond2)
			{
				ft2 = Math.Pow(t2, 1 / 3d);
			}
			else
			{
				ft2 = t2 * Math.Pow(plum, -2) / 3 + 4 / 29d;
			}
			return 500 * (ft1 - ft2);
		}

		private static double bFromXYZ(double[] xyz)
		{
			double plum = 6 / 29d;
			double t1 = xyz[1] / lumY;
			bool fCond1 = t1 > Math.Pow(plum, 3);
			double t2 = xyz[2] / lumZ;
			bool fCond2 = t2 > Math.Pow(plum, 3);
			double ft1, ft2;
			if (fCond1)
			{
				ft1 = Math.Pow(t1, 1 / 3d);
			}
			else
			{
				ft1 = t1 * Math.Pow(plum, -2) / 3 + 4 / 29d;
			}
			if (fCond2)
			{
				ft2 = Math.Pow(t2, 1 / 3d);
			}
			else
			{
				ft2 = t2 * Math.Pow(plum, -2) / 3 + 4 / 29d;
			}
			return 200 * (ft1 - ft2);
		}
		public static double[] LabFromRGB(Color c)
        {
			double[] result = new double[3];
			double[] xyz = CIEXYZfromRGB(c);
			result[0] = LfromXYZ(xyz);
			result[1] = aFromXYZ(xyz);
			result[2] = bFromXYZ(xyz);
			return result;
        }

		public static double deltaE(Color c1, Color c2)
        {
			double[] lab1 = LabFromRGB(c1);
			double[] lab2 = LabFromRGB(c2);
			return Math.Sqrt(Math.Pow(lab1[0] - lab2[0], 2) + Math.Pow(lab1[1] - lab2[1], 2) + Math.Pow(lab1[2] - lab2[2], 2));
        }
	}
}
