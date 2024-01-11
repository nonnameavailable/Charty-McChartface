
namespace ChartCreator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.showImageButton = new System.Windows.Forms.Button();
            this.showChartButton = new System.Windows.Forms.Button();
            this.createChartButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clickColorCB = new System.Windows.Forms.CheckBox();
            this.colorsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.removeColorButton = new System.Windows.Forms.Button();
            this.addColorButton = new System.Windows.Forms.Button();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.chartSettingsGB = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lineThicknessTB = new System.Windows.Forms.TextBox();
            this.rowCountTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hGaugeTB = new System.Windows.Forms.TextBox();
            this.vGaugeTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gaugeTT = new System.Windows.Forms.ToolTip(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.stitchHeightTB = new System.Windows.Forms.TextBox();
            this.createStockChartButton = new System.Windows.Forms.Button();
            this.showStockButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.chartSettingsGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.mainPictureBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartSettingsGB, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 413);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tableLayoutPanel1.SetRowSpan(this.tabControl1, 2);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(144, 407);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.showStockButton);
            this.tabPage1.Controls.Add(this.createStockChartButton);
            this.tabPage1.Controls.Add(this.showImageButton);
            this.tabPage1.Controls.Add(this.showChartButton);
            this.tabPage1.Controls.Add(this.createChartButton);
            this.tabPage1.Controls.Add(this.LoadImageButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(136, 381);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // showImageButton
            // 
            this.showImageButton.Location = new System.Drawing.Point(6, 154);
            this.showImageButton.Name = "showImageButton";
            this.showImageButton.Size = new System.Drawing.Size(124, 30);
            this.showImageButton.TabIndex = 3;
            this.showImageButton.Text = "show image";
            this.gaugeTT.SetToolTip(this.showImageButton, "Will display the original image");
            this.showImageButton.UseVisualStyleBackColor = true;
            this.showImageButton.Click += new System.EventHandler(this.showImageButton_Click);
            // 
            // showChartButton
            // 
            this.showChartButton.Enabled = false;
            this.showChartButton.Location = new System.Drawing.Point(6, 190);
            this.showChartButton.Name = "showChartButton";
            this.showChartButton.Size = new System.Drawing.Size(124, 30);
            this.showChartButton.TabIndex = 4;
            this.showChartButton.Text = "show chart";
            this.gaugeTT.SetToolTip(this.showChartButton, "If you have created a chart, this button will display a preview");
            this.showChartButton.UseVisualStyleBackColor = true;
            this.showChartButton.Click += new System.EventHandler(this.showChartButton_Click);
            // 
            // createChartButton
            // 
            this.createChartButton.Location = new System.Drawing.Point(6, 42);
            this.createChartButton.Name = "createChartButton";
            this.createChartButton.Size = new System.Drawing.Size(124, 30);
            this.createChartButton.TabIndex = 1;
            this.createChartButton.Text = "create chart";
            this.createChartButton.UseVisualStyleBackColor = true;
            this.createChartButton.Click += new System.EventHandler(this.createChartButton_Click);
            // 
            // LoadImageButton
            // 
            this.LoadImageButton.Location = new System.Drawing.Point(6, 6);
            this.LoadImageButton.Name = "LoadImageButton";
            this.LoadImageButton.Size = new System.Drawing.Size(124, 30);
            this.LoadImageButton.TabIndex = 0;
            this.LoadImageButton.Text = "Load Image";
            this.LoadImageButton.UseVisualStyleBackColor = true;
            this.LoadImageButton.Click += new System.EventHandler(this.LoadImageButton_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.clickColorCB);
            this.tabPage2.Controls.Add(this.colorsFLP);
            this.tabPage2.Controls.Add(this.removeColorButton);
            this.tabPage2.Controls.Add(this.addColorButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(136, 381);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "colors";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // clickColorCB
            // 
            this.clickColorCB.AutoSize = true;
            this.clickColorCB.Checked = true;
            this.clickColorCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clickColorCB.Location = new System.Drawing.Point(10, 37);
            this.clickColorCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clickColorCB.Name = "clickColorCB";
            this.clickColorCB.Size = new System.Drawing.Size(74, 17);
            this.clickColorCB.TabIndex = 3;
            this.clickColorCB.Text = "click color";
            this.gaugeTT.SetToolTip(this.clickColorCB, "When checked, you can click anywhere on the image\r\nto add color to your pallette " +
        "(do this for every color of yarn you intend to use)");
            this.clickColorCB.UseVisualStyleBackColor = true;
            // 
            // colorsFLP
            // 
            this.colorsFLP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.colorsFLP.AutoScroll = true;
            this.colorsFLP.BackColor = System.Drawing.Color.Transparent;
            this.colorsFLP.Location = new System.Drawing.Point(7, 58);
            this.colorsFLP.Name = "colorsFLP";
            this.colorsFLP.Size = new System.Drawing.Size(122, 317);
            this.colorsFLP.TabIndex = 2;
            // 
            // removeColorButton
            // 
            this.removeColorButton.Location = new System.Drawing.Point(69, 7);
            this.removeColorButton.Name = "removeColorButton";
            this.removeColorButton.Size = new System.Drawing.Size(60, 23);
            this.removeColorButton.TabIndex = 1;
            this.removeColorButton.Text = "remove";
            this.gaugeTT.SetToolTip(this.removeColorButton, "Removes the last color from your pallette");
            this.removeColorButton.UseVisualStyleBackColor = true;
            this.removeColorButton.Click += new System.EventHandler(this.removeColorButton_Click);
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(6, 7);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(57, 23);
            this.addColorButton.TabIndex = 0;
            this.addColorButton.Text = "add";
            this.gaugeTT.SetToolTip(this.addColorButton, "Adds new color to your pallette");
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(153, 3);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(403, 287);
            this.mainPictureBox.TabIndex = 1;
            this.mainPictureBox.TabStop = false;
            this.mainPictureBox.Click += new System.EventHandler(this.mainPictureBox_Click);
            // 
            // chartSettingsGB
            // 
            this.chartSettingsGB.Controls.Add(this.stitchHeightTB);
            this.chartSettingsGB.Controls.Add(this.label5);
            this.chartSettingsGB.Controls.Add(this.label4);
            this.chartSettingsGB.Controls.Add(this.lineThicknessTB);
            this.chartSettingsGB.Controls.Add(this.rowCountTB);
            this.chartSettingsGB.Controls.Add(this.label3);
            this.chartSettingsGB.Controls.Add(this.hGaugeTB);
            this.chartSettingsGB.Controls.Add(this.vGaugeTB);
            this.chartSettingsGB.Controls.Add(this.label1);
            this.chartSettingsGB.Controls.Add(this.label2);
            this.chartSettingsGB.Location = new System.Drawing.Point(153, 296);
            this.chartSettingsGB.Name = "chartSettingsGB";
            this.chartSettingsGB.Size = new System.Drawing.Size(403, 114);
            this.chartSettingsGB.TabIndex = 4;
            this.chartSettingsGB.TabStop = false;
            this.chartSettingsGB.Text = "chart settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "line thickness";
            // 
            // lineThicknessTB
            // 
            this.lineThicknessTB.Location = new System.Drawing.Point(200, 19);
            this.lineThicknessTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lineThicknessTB.Name = "lineThicknessTB";
            this.lineThicknessTB.Size = new System.Drawing.Size(28, 20);
            this.lineThicknessTB.TabIndex = 6;
            this.lineThicknessTB.Text = "1";
            this.gaugeTT.SetToolTip(this.lineThicknessTB, "Thickness of the black grid");
            // 
            // rowCountTB
            // 
            this.rowCountTB.Location = new System.Drawing.Point(84, 71);
            this.rowCountTB.Name = "rowCountTB";
            this.rowCountTB.Size = new System.Drawing.Size(30, 20);
            this.rowCountTB.TabIndex = 5;
            this.rowCountTB.Text = "80";
            this.gaugeTT.SetToolTip(this.rowCountTB, "How many rows do you want your chart to have?");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "row count";
            // 
            // hGaugeTB
            // 
            this.hGaugeTB.Location = new System.Drawing.Point(84, 19);
            this.hGaugeTB.Name = "hGaugeTB";
            this.hGaugeTB.Size = new System.Drawing.Size(30, 20);
            this.hGaugeTB.TabIndex = 1;
            this.hGaugeTB.Text = "10";
            this.gaugeTT.SetToolTip(this.hGaugeTB, "How many stitches (horizontally) are there in your square swatch?");
            // 
            // vGaugeTB
            // 
            this.vGaugeTB.Location = new System.Drawing.Point(84, 45);
            this.vGaugeTB.Name = "vGaugeTB";
            this.vGaugeTB.Size = new System.Drawing.Size(30, 20);
            this.vGaugeTB.TabIndex = 3;
            this.vGaugeTB.Text = "15";
            this.gaugeTT.SetToolTip(this.vGaugeTB, "How many rows are there in your square swatch?");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "horizontal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "vertical";
            // 
            // gaugeTT
            // 
            this.gaugeTT.AutoPopDelay = 5500;
            this.gaugeTT.InitialDelay = 100;
            this.gaugeTT.ReshowDelay = 110;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(142, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "stitch res.";
            // 
            // stitchHeightTB
            // 
            this.stitchHeightTB.Location = new System.Drawing.Point(200, 44);
            this.stitchHeightTB.Name = "stitchHeightTB";
            this.stitchHeightTB.Size = new System.Drawing.Size(28, 20);
            this.stitchHeightTB.TabIndex = 8;
            this.stitchHeightTB.Text = "40";
            this.gaugeTT.SetToolTip(this.stitchHeightTB, "Vertical resolution of a single stitch.\r\n\r\nThis number x row count = final vertic" +
        "al resolution of your chart image\r\n\r\nIf you have many hundreds of rows, it\'s pro" +
        "bably best to lower this number");
            // 
            // createStockChartButton
            // 
            this.createStockChartButton.Location = new System.Drawing.Point(6, 78);
            this.createStockChartButton.Name = "createStockChartButton";
            this.createStockChartButton.Size = new System.Drawing.Size(124, 30);
            this.createStockChartButton.TabIndex = 2;
            this.createStockChartButton.Text = "create stock. chart";
            this.createStockChartButton.UseVisualStyleBackColor = true;
            this.createStockChartButton.Click += new System.EventHandler(this.createStockChartButton_Click);
            // 
            // showStockButton
            // 
            this.showStockButton.Enabled = false;
            this.showStockButton.Location = new System.Drawing.Point(6, 226);
            this.showStockButton.Name = "showStockButton";
            this.showStockButton.Size = new System.Drawing.Size(124, 30);
            this.showStockButton.TabIndex = 5;
            this.showStockButton.Text = "show stock. chart";
            this.gaugeTT.SetToolTip(this.showStockButton, "If you have created a chart, this button will display a preview");
            this.showStockButton.UseVisualStyleBackColor = true;
            this.showStockButton.Click += new System.EventHandler(this.showStockButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 413);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Chart Designer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.chartSettingsGB.ResumeLayout(false);
            this.chartSettingsGB.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.GroupBox chartSettingsGB;
        private System.Windows.Forms.TextBox hGaugeTB;
        private System.Windows.Forms.TextBox vGaugeTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox rowCountTB;
        private System.Windows.Forms.ToolTip gaugeTT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button createChartButton;
        private System.Windows.Forms.Button removeColorButton;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.FlowLayoutPanel colorsFLP;
        private yarnColorSelector yarnColorSelector1;
        private System.Windows.Forms.CheckBox clickColorCB;
        private System.Windows.Forms.Button showImageButton;
        private System.Windows.Forms.Button showChartButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox lineThicknessTB;
        private System.Windows.Forms.TextBox stitchHeightTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button showStockButton;
        private System.Windows.Forms.Button createStockChartButton;
    }
}

