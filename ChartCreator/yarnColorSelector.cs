using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartCreator
{
    public partial class YarnColorSelector : UserControl
    {
        public string YarnLabel { get => yarnColorTB.Text; set => yarnColorTB.Text = value; }
        public Color Color { get => selectColorButton.BackColor; set => selectColorButton.BackColor = value; }
        public Color ReplacementColor { get => replacementColorButton.BackColor; set => replacementColorButton.BackColor = value; }
        public bool IsPainting { get => paintCB.Checked; set => paintCB.Checked = value; }
        public List<YarnColorSelector> MappedYCSels { get; set; }
        public List<Color> MappedColors {
            get
            {
                List<Color> result = new List<Color>();
                foreach(YarnColorSelector ycs in MappedYCSels)
                {
                    result.Add(ycs.Color);
                }
                return result;
            }
        }
        public List<Color> MappedReplacementColors
        {
            get
            {
                List<Color> result = new List<Color>();
                foreach (YarnColorSelector ycs in MappedYCSels)
                {
                    result.Add(ycs.ReplacementColor);
                }
                return result;
            }
        }
        public List<Color> ReplacementColors { get; set; }
        public event EventHandler MapBtnClicked;
        public YarnColorSelector(Color c)
        {
            InitializeComponent();
            selectColorButton.BackColor = c;
            replacementColorButton.BackColor = c;
            yarnColorDialog.Color = c;
            paintCB.Click += PaintCB_Click;
            MappedYCSels = new List<YarnColorSelector>();
            openMappedColorsBTN.Click += (sender, args) => MapBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PaintCB_Click(object sender, EventArgs e)
        {
            if (IsPainting)
            {
                foreach(YarnColorSelector yc in this.Parent.Controls)
                {
                    if (!this.Equals(yc))
                    {
                        yc.IsPainting = false;
                    }
                }
            } else
            {
                IsPainting = true;
            }
            ((Form1)this.FindForm()).ClickColor = false;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            yarnColorDialog.ShowDialog();
            selectColorButton.BackColor = yarnColorDialog.Color;
            //replacementColorButton.BackColor = yarnColorDialog.Color;
        }

        private void replacementColorButton_Click(object sender, EventArgs e)
        {
            yarnColorDialog.ShowDialog();
            replacementColorButton.BackColor = yarnColorDialog.Color;
            ((Form1)this.FindForm()).createChart(false);
        }

    }
}
