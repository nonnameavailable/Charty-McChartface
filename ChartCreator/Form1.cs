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
using ChartCreator.Properties;

namespace ChartCreator
{
    public partial class Form1 : Form
    {
        private Charter charter;
        private Bitmap mainImage;
        private bool renderModeScroll;
        private double dispImgRatio;

        public Form1()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 800;
            this.dispImgRatio = 1;
            charter = new Charter();
            charter.OriginalImage = new Bitmap(Properties.Resources.masterpiece);
            mainImage = charter.OriginalImage;

            renderModeScroll = false;
            mainPictureBox.Dock = DockStyle.Fill;
            updatePictureBox();

            UpdateColors();
    
            this.ResizeEnd += Form1_ResizeEnd;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
            sfd.FileOk += Sfd_FileOk;
            mainPictureBox.MouseClick += mainPictureBox_MouseClick;
            mainPictureBox.ContextMenuStrip = pictureCMS;
            ditherCB.Click += DitherCB_Click;
            negativeGridCB.Click += NegativeGridCB_Click;
            numbersCB.Click += NumbersCB_Click;

            stitchChooserComboBox.SelectedItem = "Stockinette";

            ycsHolder1.AddColorBtnClicked += (sender, args) => UpdateColors();
            ycsHolder1.RemoveColorBtnClicked += (sender, args) => UpdateColors();
            loadMapBTN.Click += LoadMapBTN_Click;
            showMapBTN.Click += ShowMapBTN_Click;
        }

        private void ShowMapBTN_Click(object sender, EventArgs e)
        {
            mainImage = charter.Map;
            updatePictureBox();
        }

        private void LoadMapBTN_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                charter.Map = new Bitmap(ofd.FileName);
                showMapBTN.Enabled = true;
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("You did not select an image file");
                return;
            }
        }

        private void Sfd_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog sv = (sender as SaveFileDialog);
            if (Path.GetExtension(sv.FileName).ToLower() != ".png")
            {
                e.Cancel = true;
                MessageBox.Show("Please don't use extensions in your file name or use .png");
                return;
            }
        }

        private void updatePictureBox()
        {
            if (renderModeScroll)
            {
                mainPictureBox.Image = mainImage;
                int[] dims = { (int)(mainImage.Width * dispImgRatio), (int)(mainImage.Height * dispImgRatio) };
                Bitmap mimg = new Bitmap(dims[0], dims[1]);
                Graphics g = Graphics.FromImage(mimg);
                g.Clear(Color.Black);
                g.DrawImage(mainImage, 0, 0, dims[0], dims[1]);
                mainPictureBox.Image = mimg;
                g.Dispose();
            }
            else
            {
                int[] dims = DispImgDims;
                Bitmap mimg = new Bitmap(dims[0], dims[1]);
                Graphics g = Graphics.FromImage(mimg);
                g.Clear(Color.Black);
                g.DrawImage(mainImage, 0, 0, dims[0], dims[1]);
                mainPictureBox.Image = mimg;
                g.Dispose();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Oemplus || keyData == Keys.Add)
            {
                dispImgRatio *= 1.05;
                updatePictureBox();
                return true;
            } else if(keyData == Keys.OemMinus || keyData == Keys.Subtract)
            {
                dispImgRatio /= 1.05;
                updatePictureBox();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public bool createChart(bool newArray)
        {
            if (ycsHolder1.ColorCount == 0)
            {
                MessageBox.Show("Switch to the colors tab and add some colors first.");
                return false;
            }

            charter.YarnColors = ycsHolder1.YarnColors();
            charter.ReplacementYarnColors = ycsHolder1.ReplacementColors();
            charter.NegativeGrid = negativeGridCB.Checked;
            if (newArray)
            {
                if (DitherChart)
                {
                    //charter.createChartArrayDitheredSerpent(HGauge, VGauge, VCount, MatchMode);
                    charter.CreateDitheredChartWithMap(HGauge, VGauge, VCount, MatchMode, ycsHolder1);
                }
                else
                {
                    //charter.createChartArray(HGauge, VGauge, VCount, MatchMode);
                    charter.CreateDitheredChartWithMap(HGauge, VGauge, VCount, MatchMode, ycsHolder1);
                }
            }
            List<Color> colorList = new List<Color>();
            foreach(YarnColorSelector ycs in ycsHolder1.YCSList)
            {
                foreach(Color c in ycs.MappedReplacementColors)
                {
                    colorList.Add(c);
                }
            }
            if(!charter.generateChartFromArray(StitchWidth, StitchHeight, LineThickness, DrawNumbers, colorList, charter.MapChartArray))
            //if (!charter.generateChartFromArray(StitchWidth, StitchHeight, LineThickness, DrawNumbers, ycsHolder1.YarnColors(), charter.ChartArray))
            {
                return false;
            }
            mainImage = charter.Chart;
            updatePictureBox();
            showChartButton.Enabled = true;
            saveChartButton.Enabled = true;
            createStitchChartButton.Enabled = true;
            return true;
        }

        #region button event handlers

        private void UpdateColors()
        {
            charter.YarnColors = ycsHolder1.YarnColors();
            charter.ReplacementYarnColors = ycsHolder1.ReplacementColors();
            createStitchChartButton.Enabled = false;
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
            ycsHolder1.RemoveAllColors();
            mainImage = charter.OriginalImage;
            updatePictureBox();
        }

        private void createChartButton_Click(object sender, EventArgs e)
        {
            if (!createChart(true))
            {
                return;
            }
            mainStatusLabel.Text = "Chart created. " + "width: " + HCount + " stitches; height: " + VCount + " stitches";
        }
        private void saveChartButton_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            charter.Chart.Save(sfd.FileName, ImageFormat.Png);
            mainStatusLabel.Text = "chart saved under: " + sfd.FileName;
            sfd.FileName = Path.GetFileName(sfd.FileName);
        }

        private void saveStockChartButton_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            charter.StitchChart.Save(sfd.FileName, ImageFormat.Png);
            mainStatusLabel.Text = "stock. chart saved under: " + sfd.FileName;
            sfd.FileName = Path.GetFileName(sfd.FileName);
        }
        private void createStitchChartButton_Click(object sender, EventArgs e)
        {
            if (ycsHolder1.ColorCount == 0)
            {
                MessageBox.Show("Switch to the colors tab and add some colors first.");
                return;
            }
            charter.YarnColors = ycsHolder1.YarnColors();
            charter.ReplacementYarnColors = ycsHolder1.ReplacementColors();
            switch (SelectedStitch)
            {
                case "Stockinette":
                    charter.generateStitchedChart(StitchWidth, StitchHeight, Resources.background_stitch_tunisian, Resources.stitch_stockinette_lerp, 1, 2);
                    break;

                case "Tunisian crochet":
                    charter.generateStitchedChart(StitchWidth, StitchHeight, Resources.background_stitch_tunisian, Resources.stitch_tunisian, 1.1, 1.4);
                    break;
                default:
                    charter.generateStitchedChart(StitchWidth, StitchHeight, Resources.background_stitch_tunisian, Resources.stitch_stockinette_lerp, 1, 2);
                    break;

            }
            mainImage = charter.StitchChart;
            updatePictureBox();
            showStitchChartButton.Enabled = true;
            saveStitchedChartButton.Enabled = true;
            mainStatusLabel.Text = "Chart created. " + "width: " + HCount + " stitches; height: " + VCount + " stitches";
        }
        private void showStitchChartButton_Click(object sender, EventArgs e)
        {
            mainImage = charter.StitchChart;
            updatePictureBox();
        }
        #endregion

        #region other event handlers
        private void mainPictureBox_MouseClick(object sender, EventArgs e)
        {
            if (ycsHolder1.ClickColor)
            {
                try
                {
                    Color c = ((Bitmap)(mainPictureBox.Image)).GetPixel(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
                    ycsHolder1.AddColor(c);
                }
                catch (ArgumentOutOfRangeException) { }
            } else
            {
                if (ycsHolder1.ColorCount == 0)
                {
                    MessageBox.Show("Switch to the colors tab and add some colors first.");
                    return;
                }
                double x = ((MouseEventArgs)e).X;
                double y = ((MouseEventArgs)e).Y;

                int chartX = (int)(x / DispImgDims[0] * HCount);
                int chartY = (int)(y / DispImgDims[1] * VCount);
                Color paintC;
                try
                {
                    paintC = charter.YarnColors[0];
                } catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Please create the chart first :)");
                    return;
                }

                foreach (YarnColorSelector ycs in ycsHolder1.YCSList)
                {
                    if (ycs.IsPainting)
                    {
                        paintC = ycs.Color;
                        break;
                    }
                }
                charter.YarnColors = ycsHolder1.YarnColors();
                charter.ReplacementYarnColors = ycsHolder1.ReplacementColors();
                int paintColorIndex = charter.YarnColors.IndexOf(paintC);
                charter.setGrid(chartX, chartY, paintColorIndex);
                charter.generateChartFromArray(StitchWidth, StitchHeight, LineThickness, DrawNumbers, ycsHolder1.YarnColors(), charter.ChartArray);
                mainImage = charter.Chart;
                updatePictureBox();
            }
        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            updatePictureBox();
        }

        private void RenderFitMI_Click(object sender, EventArgs e)
        {
            renderModeScroll = false;
            mainPictureBox.Dock = DockStyle.Fill;
            updatePictureBox();
        }

        private void renderScrollMI_Click(object sender, EventArgs e)
        {
            renderModeScroll = true;
            mainPictureBox.Dock = DockStyle.None;
            updatePictureBox();
        }
        private void NumbersCB_Click(object sender, EventArgs e)
        {
            if (!createChart(false))
            {
                DrawNumbers = false;
            }
        }

        private void NegativeGridCB_Click(object sender, EventArgs e)
        {
            if (!createChart(false))
            {
                NegativeGrid = false;
            }
        }

        private void DitherCB_Click(object sender, EventArgs e)
        {
            if (!createChart(true))
            {
                DitherChart = false;
            }
        }
        private void hGaugeNUD_ValueChanged(object sender, EventArgs e)
        {
            createStitchChartButton.Enabled = false;
            saveStitchedChartButton.Enabled = false;
        }

        private void vGaugeNUD_ValueChanged(object sender, EventArgs e)
        {
            createStitchChartButton.Enabled = false;
            saveStitchedChartButton.Enabled = false;
        }

        private void rowCountNUD_ValueChanged(object sender, EventArgs e)
        {
            createStitchChartButton.Enabled = false;
            saveStitchedChartButton.Enabled = false;
        }

        void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                charter.OriginalImage = new Bitmap(files[0]);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("This is not an image file");
                return;
            }
            ycsHolder1.RemoveAllColors();
            mainImage = charter.OriginalImage;
            updatePictureBox();
        }
        #endregion

        #region properties
        public double VGauge { get => (double)vGaugeNUD.Value; set => vGaugeNUD.Value = (decimal)value; }
        public double HGauge { get => (double)hGaugeNUD.Value; set => hGaugeNUD.Value = (decimal)value; }
        public int VCount { get => (int)rowCountNUD.Value; set => rowCountNUD.Value = (decimal)value; }
        public double LineThickness { get => (double)lineThicknessNUD.Value; set => lineThicknessNUD.Value = (decimal)value; }
        public double StitchWidth { get => (double)stitchWidthNUD.Value; set => stitchWidthNUD.Value = (decimal)value; }
        public int DistanceThreshold { get => (int)distThresholdNUD.Value; set => distThresholdNUD.Value = value; }
        public int CountThreshold { get => (int)countThresholdNUD.Value; set => countThresholdNUD.Value = value; }
        public bool NegativeGrid { get => negativeGridCB.Checked; set => negativeGridCB.Checked = value; }
        public bool DitherChart { get => ditherCB.Checked; set => ditherCB.Checked = value; }
        public bool ClickColor { get => ycsHolder1.ClickColor; set => ycsHolder1.ClickColor = value; }
        public bool DrawNumbers { get => numbersCB.Checked; set => numbersCB.Checked = value; }
        public string SelectedStitch { get => stitchChooserComboBox.SelectedItem.ToString(); }
        public double StitchHeight { get => StitchWidth * HGauge / VGauge; }
        public int HCount { get => (int)((double)charter.OriginalImage.Width / (double)charter.OriginalImage.Height * VCount * HGauge / VGauge); }
        public int[] DispImgDims
        { 
            get
            {
                double ratio = (double)mainImage.Width / (double)mainPictureBox.Width;
                if ((double)mainImage.Height / ratio > mainPictureBox.Height)
                {
                    ratio = (double)mainImage.Height / (double)mainPictureBox.Height;
                }
                int w = (int)(mainImage.Width / ratio);
                int h = (int)(mainImage.Height / ratio);
                int[] result = new int[2];
                result[0] = w;
                result[1] = h;
                return result;
            }        
        }
        public int MatchMode
        {
            get
            {
                if (LabMatchModeRB.Checked)
                {
                    return Charter.colorMatchLab;
                }
                else if (LinearMatchModeRB.Checked)
                {
                    return Charter.colorMatchLinear;
                }
                else
                {
                    return Charter.colorMatchCubic;
                }
            }
        }
        #endregion

        private void stitchWidthNUD_ValueChanged(object sender, EventArgs e)
        {
            createChart(false);
        }

        private void autoCorrectButton_Click(object sender, EventArgs e)
        {
            try
            {
                charter.autoCorrect(DistanceThreshold, CountThreshold);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Create the chart first");
                return;
            }
            createChart(false);
        }
    }
}
