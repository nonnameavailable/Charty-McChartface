using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace ChartCreator
{
    public partial class Form1 : Form
    {
        private Charter charter;
        private Bitmap mainImage;

        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 800;
            charter = new Charter();
            charter.OriginalImage = new Bitmap(Properties.Resources.masterpiece);
            mainImage = charter.OriginalImage;

            this.ResizeEnd += Form1_ResizeEnd;
            colorsFLP.Controls.Add(new yarnColorSelector(charter.OriginalImage.GetPixel(0, 0)));
            updatePictureBox();
        }

        private void updatePictureBox()
        {
            double ratio = (double)mainImage.Width / (double)mainPictureBox.Width;
            if ((double)mainImage.Height / ratio > mainPictureBox.Height)
            {
                ratio = (double)mainImage.Height / (double)mainPictureBox.Height;
            }
            Bitmap mimg = new Bitmap((int)(mainImage.Width / ratio), (int)(mainImage.Height / ratio));
            Graphics g = Graphics.FromImage(mimg);
            g.Clear(Color.Black);
            g.DrawImage(mainImage, 0, 0, (int)(mainImage.Width / ratio), (int)(mainImage.Height / ratio));
            mainPictureBox.Image = mimg;
            g.Dispose();
        }

        private List<Color> yarnColors()
        {
            List<Color> result = new List<Color>();

            foreach (yarnColorSelector ycs in colorsFLP.Controls)
            {
                result.Add(ycs.Color);
            }

            return result;
        }

        private List<Color> replacementColors()
        {
            List<Color> result = new List<Color>();

            foreach (yarnColorSelector ycs in colorsFLP.Controls)
            {
                result.Add(ycs.ReplacementColor);
            }

            return result;
        }

        #region button event handlers
        private void addColorButton_Click(object sender, EventArgs e)
        {
            colorsFLP.Controls.Add(new yarnColorSelector(Color.White));
        }

        private void removeColorButton_Click(object sender, EventArgs e)
        {
            if (colorsFLP.Controls.Count > 1)
            {
                colorsFLP.Controls.Remove(colorsFLP.Controls[colorsFLP.Controls.Count - 1]);
            }
        }

        private void showChartButton_Click(object sender, EventArgs e)
        {
            mainImage = charter.Chart;
            updatePictureBox();
        }

        private void showImageButton_Click(object sender, EventArgs e)
        {
            mainImage = charter.OriginalImage;
            updatePictureBox();
        }
        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                charter.OriginalImage = new Bitmap(ofd.FileName);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("You did not select an image file");
                return;
            }
                
            mainImage = charter.OriginalImage;
            updatePictureBox();
        }

        private void createChartButton_Click(object sender, EventArgs e)
        {
            charter.YarnColors = yarnColors();
            charter.ReplacementYarnColors = replacementColors();
            if (DitherChart)
            {
                charter.createChartArrayDithered(HGauge, VGauge, VCount);
            } else
            {
                charter.createChartArray(HGauge, VGauge, VCount);
            }
            charter.generateChartFromArray(HCount, VCount, StitchWidth, StitchHeight, LineThickness);
            mainImage = charter.Chart;
            updatePictureBox();
            showChartButton.Enabled = true;
            saveChartButton.Enabled = true;
        }
        private void createStockChartButton_Click(object sender, EventArgs e)
        {
            charter.YarnColors = yarnColors();
            charter.ReplacementYarnColors = replacementColors();
            if (DitherChart)
            {
                charter.createChartArrayDithered(HGauge, VGauge, VCount);
            }
            else
            {
                charter.createChartArray(HGauge, VGauge, VCount);
            }
            charter.generateStockinetteChartFromArray(HCount, VCount, StitchWidth, StitchHeight, LineThickness);
            mainImage = charter.StockinetteChart;
            updatePictureBox();
            showStockButton.Enabled = true;
            saveStockChartButton.Enabled = true;
        }
        private void showStockButton_Click(object sender, EventArgs e)
        {
            mainImage = charter.StockinetteChart;
            updatePictureBox();
        }
        private void saveChartButton_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            charter.Chart.Save(sfd.FileName, ImageFormat.Png);
            mainStatusLabel.Text = "chart saved under: " + sfd.FileName;
        }

        private void saveStockChartButton_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            charter.StockinetteChart.Save(sfd.FileName, ImageFormat.Png);
            mainStatusLabel.Text = "stock. chart saved under: " + sfd.FileName;
        }
        #endregion

        #region other event handlers
        private void mainPictureBox_Click(object sender, EventArgs e)
        {
            if (clickColorCB.Checked)
            {
                try
                {
                    Color c = ((Bitmap)(mainPictureBox.Image)).GetPixel(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                    colorsFLP.Controls.Add(new yarnColorSelector(c));
                }
                catch (ArgumentOutOfRangeException) { }
            } else
            {
                //TODOOOOOOODDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD
            }
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            mainPictureBox.Invalidate();
            updatePictureBox();
        }
        #endregion

        #region properties
        public double VGauge { get => (double)vGaugeNUD.Value; set => vGaugeNUD.Value = (decimal)value; }
        public double HGauge { get => (double)hGaugeNUD.Value; set => hGaugeNUD.Value = (decimal)value; }
        public int VCount { get => (int)rowCountNUD.Value; set => rowCountNUD.Value = (decimal)value; }
        public double LineThickness { get => (double)lineThicknessNUD.Value; set => lineThicknessNUD.Value = (decimal)value; }
        public double StitchWidth { get => (double)stitchWidthNUD.Value; set => stitchWidthNUD.Value = (decimal)value; }
        public bool NegativeGrid { get => negativeGridCB.Checked; set => negativeGridCB.Checked = value; }
        public bool DitherChart { get => ditherCB.Checked; set => ditherCB.Checked = value; }
        public bool ClickColor { get => clickColorCB.Checked; set => clickColorCB.Checked = value; }
        public double StitchHeight { get => StitchWidth * HGauge / VGauge; }
        public int HCount { get => (int)((double)charter.OriginalImage.Width / (double)charter.OriginalImage.Height * VCount * HGauge / VGauge); }
        #endregion
    }
}
