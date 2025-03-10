using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartCreator
{
    public partial class YCSHolder: UserControl
    {
        public int ColorCount { get => YCSList.Count; }
        public bool ClickColor { get => clickColorCB.Checked; set => clickColorCB.Checked = value; }
        private YarnColorSelector _mappingCS;
        public List<YarnColorSelector> YCSList;
        public event EventHandler AddColorBtnClicked, RemoveColorBtnClicked;
        private bool Mapping { get => _mappingCS != null; }
        public YCSHolder()
        {
            InitializeComponent();
            addColorButton.Click += AddColorButton_Click;
            removeColorButton.Click += RemoveColorButton_Click;
            backBTN.Click += BackBTN_Click;
            YCSList = new List<YarnColorSelector>();
        }

        private void BackBTN_Click(object sender, EventArgs e)
        {
            if (!Mapping) return;
            _mappingCS.MappedColors.Clear();
            for(int i = colorsFLP.Controls.Count - 1; i >= 0; i--)
            {
                YarnColorSelector ycs = (YarnColorSelector)colorsFLP.Controls[i];
                _mappingCS.MappedColors.Add(ycs.Color);
                ycs.Dispose();
            }
            colorsFLP.Controls.Clear();
            foreach(YarnColorSelector ycs in YCSList)
            {
                colorsFLP.Controls.Add(ycs);
            }
            _mappingCS = null;
        }
        
        private void AddColorButton_Click(object sender, EventArgs e)
        {
            YarnColorSelector ycs = new YarnColorSelector(Color.White);
            ycs.MapBtnClicked += Ycs_MapBtnClicked;
            colorsFLP.Controls.Add(ycs);
            if(!Mapping) YCSList.Add(ycs);
            AddColorBtnClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Ycs_MapBtnClicked(object sender, EventArgs e)
        {
            colorsFLP.Controls.Clear();
            YarnColorSelector ycs = (YarnColorSelector)sender;
            foreach(Color c in ycs.MappedColors)
            {
                colorsFLP.Controls.Add(new YarnColorSelector(c));
            }
            _mappingCS = ycs;
        }

        private void RemoveColorButton_Click(object sender, EventArgs e)
        {
            if (colorsFLP.Controls.Count > 0)
            {
                YarnColorSelector ycs = YCSList[YCSList.Count - 1];
                colorsFLP.Controls.Remove(ycs);
                if(!Mapping)YCSList.Remove(ycs);
                ycs.Dispose();
                RemoveColorBtnClicked?.Invoke(this, EventArgs.Empty);
            }
        }
        public void AddColor(Color color)
        {
            YarnColorSelector ycs = new YarnColorSelector(color);
            ycs.MapBtnClicked += Ycs_MapBtnClicked;
            colorsFLP.Controls.Add(ycs);
            if(!Mapping) YCSList.Add(ycs);
        }
        public List<Color> ReplacementColors()
        {
            List<Color> result = new List<Color>();
            foreach(YarnColorSelector ycs in YCSList)
            {
                result.Add(ycs.ReplacementColor);
            }
            return result;
        }
        public List<Color> YarnColors()
        {
            List<Color> result = new List<Color>();
            foreach(YarnColorSelector ycs in YCSList)
            {
                result.Add(ycs.Color);
            }
            return result;
        }
        public void RemoveAllColors()
        {
            for(int i = 0; i < YCSList.Count; i++)
            {
                YCSList[i].Dispose();
            }
            YCSList.Clear();
            colorsFLP.Controls.Clear();
        }
    }
}
