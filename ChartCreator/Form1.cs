﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            charter.OriginalImage = new Bitmap(ChartCreator.Properties.Resources.masterpiece);
            mainImage = charter.OriginalImage;

            this.ResizeEnd += Form1_ResizeEnd;
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
            if (colorsFLP.Controls.Count > 0)
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
            charter.OriginalImage = new Bitmap(ofd.FileName);
            updatePictureBox();
        }

        private void createChartButton_Click(object sender, EventArgs e)
        {
            charter.YarnColors = yarnColors();
            charter.ReplacementYarnColors = replacementColors();
            charter.createChartArray(HGauge, VGauge, VCount);
            charter.generateChartFromArray(HCount, VCount, StitchWidth, StitchHeight, LineThickness);
            mainImage = charter.Chart;
            updatePictureBox();
            showChartButton.Enabled = true;
        }
        private void createStockChartButton_Click(object sender, EventArgs e)
        {
            charter.YarnColors = yarnColors();
            charter.ReplacementYarnColors = replacementColors();
            charter.createChartArray(HGauge, VGauge, VCount);
            charter.generateStockinetteChartFromArray(HCount, VCount, StitchWidth, StitchHeight, LineThickness);
            mainImage = charter.StockinetteChart;
            updatePictureBox();
            showStockButton.Enabled = true;
        }
        private void showStockButton_Click(object sender, EventArgs e)
        {
            mainImage = charter.StockinetteChart;
            updatePictureBox();
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

        public double VGauge { get => double.Parse(vGaugeTB.Text); set => vGaugeTB.Text = value.ToString(); }
        public double HGauge { get => double.Parse(hGaugeTB.Text); set => hGaugeTB.Text = value.ToString(); }
        public int VCount { get => int.Parse(rowCountTB.Text); set => rowCountTB.Text = value.ToString(); }
        public double LineThickness { get => double.Parse(lineThicknessTB.Text); set => lineThicknessTB.Text = value.ToString(); }
        public double StitchWidth { get => double.Parse(stitchWidthTB.Text); set => stitchWidthTB.Text = value.ToString(); }
        public bool DitherChart { get => ditherCB.Checked; set => ditherCB.Checked = value; }
        public bool ClickColor { get => clickColorCB.Checked; set => clickColorCB.Checked = value; }
        public double StitchHeight { get => StitchWidth * HGauge / VGauge; }
        public int HCount { get => (int)((double)charter.OriginalImage.Width / (double)charter.OriginalImage.Height * VCount * HGauge / VGauge); }
    }
}
