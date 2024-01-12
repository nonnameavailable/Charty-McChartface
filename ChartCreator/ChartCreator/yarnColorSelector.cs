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
    public partial class yarnColorSelector : UserControl
    {
        public yarnColorSelector(Color c)
        {
            InitializeComponent();
            selectColorButton.BackColor = c;
            replacementColorButton.BackColor = c;
            yarnColorDialog.Color = c;
            paintCB.Click += PaintCB_Click;
        }

        private void PaintCB_Click(object sender, EventArgs e)
        {
            if (IsPainting)
            {
                foreach(yarnColorSelector yc in this.Parent.Controls)
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
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            yarnColorDialog.ShowDialog();
            selectColorButton.BackColor = yarnColorDialog.Color;
        }
        public string YarnLabel { get => yarnColorTB.Text; set => yarnColorTB.Text = value; }

        public Color Color { get => selectColorButton.BackColor; set => selectColorButton.BackColor = value; }
        public Color ReplacementColor { get => replacementColorButton.BackColor; set => replacementColorButton.BackColor = value; }
        public bool IsPainting { get => paintCB.Checked; set => paintCB.Checked = value; }

        private void replacementColorButton_Click(object sender, EventArgs e)
        {
            yarnColorDialog.ShowDialog();
            replacementColorButton.BackColor = yarnColorDialog.Color;
        }

    }
}
