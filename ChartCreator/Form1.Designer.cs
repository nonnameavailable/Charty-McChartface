
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
            this.saveStockChartButton = new System.Windows.Forms.Button();
            this.saveChartButton = new System.Windows.Forms.Button();
            this.showStockButton = new System.Windows.Forms.Button();
            this.createStockChartButton = new System.Windows.Forms.Button();
            this.showImageButton = new System.Windows.Forms.Button();
            this.showChartButton = new System.Windows.Forms.Button();
            this.createChartButton = new System.Windows.Forms.Button();
            this.LoadImageButton = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.clickColorCB = new System.Windows.Forms.CheckBox();
            this.colorsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.removeColorButton = new System.Windows.Forms.Button();
            this.addColorButton = new System.Windows.Forms.Button();
            this.chartSettingsGB = new System.Windows.Forms.GroupBox();
            this.numbersCB = new System.Windows.Forms.CheckBox();
            this.negativeGridCB = new System.Windows.Forms.CheckBox();
            this.stitchWidthNUD = new System.Windows.Forms.NumericUpDown();
            this.lineThicknessNUD = new System.Windows.Forms.NumericUpDown();
            this.rowCountNUD = new System.Windows.Forms.NumericUpDown();
            this.vGaugeNUD = new System.Windows.Forms.NumericUpDown();
            this.hGaugeNUD = new System.Windows.Forms.NumericUpDown();
            this.ditherCB = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.mainStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.mainPictureBox = new System.Windows.Forms.PictureBox();
            this.gaugeTT = new System.Windows.Forms.ToolTip(this.components);
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.pictureCMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renderModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.renderFitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.renderScrollMI = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.chartSettingsGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stitchWidthNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCountNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGaugeNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGaugeNUD)).BeginInit();
            this.mainStatusStrip.SuspendLayout();
            this.picturePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).BeginInit();
            this.pictureCMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartSettingsGB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.mainStatusStrip, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.picturePanel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 413);
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
            this.tabControl1.Size = new System.Drawing.Size(144, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.saveStockChartButton);
            this.tabPage1.Controls.Add(this.saveChartButton);
            this.tabPage1.Controls.Add(this.showStockButton);
            this.tabPage1.Controls.Add(this.createStockChartButton);
            this.tabPage1.Controls.Add(this.showImageButton);
            this.tabPage1.Controls.Add(this.showChartButton);
            this.tabPage1.Controls.Add(this.createChartButton);
            this.tabPage1.Controls.Add(this.LoadImageButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(136, 356);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // saveStockChartButton
            // 
            this.saveStockChartButton.Enabled = false;
            this.saveStockChartButton.Location = new System.Drawing.Point(6, 304);
            this.saveStockChartButton.Name = "saveStockChartButton";
            this.saveStockChartButton.Size = new System.Drawing.Size(124, 30);
            this.saveStockChartButton.TabIndex = 7;
            this.saveStockChartButton.Text = "save stock. chart";
            this.gaugeTT.SetToolTip(this.saveStockChartButton, "Save the stockinette chart to a file\r\n\r\nPlease do not include extension in file n" +
        "ame!!\r\nFile will be saved as .png automatically");
            this.saveStockChartButton.UseVisualStyleBackColor = true;
            this.saveStockChartButton.Click += new System.EventHandler(this.saveStockChartButton_Click);
            // 
            // saveChartButton
            // 
            this.saveChartButton.Enabled = false;
            this.saveChartButton.Location = new System.Drawing.Point(6, 268);
            this.saveChartButton.Name = "saveChartButton";
            this.saveChartButton.Size = new System.Drawing.Size(124, 30);
            this.saveChartButton.TabIndex = 6;
            this.saveChartButton.Text = "save chart";
            this.gaugeTT.SetToolTip(this.saveChartButton, "Save the regular chart to a file\r\n\r\nPlease do not include extension in file name!" +
        "!\r\nFile will be saved as .png automatically");
            this.saveChartButton.UseVisualStyleBackColor = true;
            this.saveChartButton.Click += new System.EventHandler(this.saveChartButton_Click);
            // 
            // showStockButton
            // 
            this.showStockButton.Enabled = false;
            this.showStockButton.Location = new System.Drawing.Point(6, 214);
            this.showStockButton.Name = "showStockButton";
            this.showStockButton.Size = new System.Drawing.Size(124, 30);
            this.showStockButton.TabIndex = 5;
            this.showStockButton.Text = "show stock. chart";
            this.gaugeTT.SetToolTip(this.showStockButton, "If you have created a stockinette chart, this button will display a preview");
            this.showStockButton.UseVisualStyleBackColor = true;
            this.showStockButton.Click += new System.EventHandler(this.showStockButton_Click);
            // 
            // createStockChartButton
            // 
            this.createStockChartButton.Location = new System.Drawing.Point(6, 78);
            this.createStockChartButton.Name = "createStockChartButton";
            this.createStockChartButton.Size = new System.Drawing.Size(124, 30);
            this.createStockChartButton.TabIndex = 2;
            this.createStockChartButton.Text = "create stock. chart";
            this.gaugeTT.SetToolTip(this.createStockChartButton, "Create and display a stockinette preview chart");
            this.createStockChartButton.UseVisualStyleBackColor = true;
            this.createStockChartButton.Click += new System.EventHandler(this.createStockChartButton_Click);
            // 
            // showImageButton
            // 
            this.showImageButton.Location = new System.Drawing.Point(6, 142);
            this.showImageButton.Name = "showImageButton";
            this.showImageButton.Size = new System.Drawing.Size(124, 30);
            this.showImageButton.TabIndex = 3;
            this.showImageButton.Text = "show image";
            this.gaugeTT.SetToolTip(this.showImageButton, "Display the original image");
            this.showImageButton.UseVisualStyleBackColor = true;
            this.showImageButton.Click += new System.EventHandler(this.showImageButton_Click);
            // 
            // showChartButton
            // 
            this.showChartButton.Enabled = false;
            this.showChartButton.Location = new System.Drawing.Point(6, 178);
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
            this.gaugeTT.SetToolTip(this.createChartButton, "Create and display a regular chart\r\n\r\nMake sure to switch to the \"colors\" tab fir" +
        "st\r\nand pick your colors");
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
            this.gaugeTT.SetToolTip(this.LoadImageButton, "Load your image");
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
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(136, 356);
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
            this.clickColorCB.Margin = new System.Windows.Forms.Padding(2);
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
            this.colorsFLP.Size = new System.Drawing.Size(122, 291);
            this.colorsFLP.TabIndex = 2;
            // 
            // removeColorButton
            // 
            this.removeColorButton.Location = new System.Drawing.Point(69, 7);
            this.removeColorButton.Name = "removeColorButton";
            this.removeColorButton.Size = new System.Drawing.Size(60, 23);
            this.removeColorButton.TabIndex = 1;
            this.removeColorButton.Text = "remove";
            this.gaugeTT.SetToolTip(this.removeColorButton, "Removes the last color from your palette");
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
            this.gaugeTT.SetToolTip(this.addColorButton, "Adds new color to your palette\r\n\r\nYou can also left click anywhere in the image\r\n" +
        "to pick color from the image");
            this.addColorButton.UseVisualStyleBackColor = true;
            this.addColorButton.Click += new System.EventHandler(this.addColorButton_Click);
            // 
            // chartSettingsGB
            // 
            this.chartSettingsGB.Controls.Add(this.numbersCB);
            this.chartSettingsGB.Controls.Add(this.negativeGridCB);
            this.chartSettingsGB.Controls.Add(this.stitchWidthNUD);
            this.chartSettingsGB.Controls.Add(this.lineThicknessNUD);
            this.chartSettingsGB.Controls.Add(this.rowCountNUD);
            this.chartSettingsGB.Controls.Add(this.vGaugeNUD);
            this.chartSettingsGB.Controls.Add(this.hGaugeNUD);
            this.chartSettingsGB.Controls.Add(this.ditherCB);
            this.chartSettingsGB.Controls.Add(this.label5);
            this.chartSettingsGB.Controls.Add(this.label4);
            this.chartSettingsGB.Controls.Add(this.label3);
            this.chartSettingsGB.Controls.Add(this.label1);
            this.chartSettingsGB.Controls.Add(this.label2);
            this.chartSettingsGB.Location = new System.Drawing.Point(153, 271);
            this.chartSettingsGB.Name = "chartSettingsGB";
            this.chartSettingsGB.Size = new System.Drawing.Size(411, 114);
            this.chartSettingsGB.TabIndex = 4;
            this.chartSettingsGB.TabStop = false;
            this.chartSettingsGB.Text = "chart settings";
            // 
            // numbersCB
            // 
            this.numbersCB.AutoSize = true;
            this.numbersCB.Location = new System.Drawing.Point(269, 68);
            this.numbersCB.Name = "numbersCB";
            this.numbersCB.Size = new System.Drawing.Size(92, 17);
            this.numbersCB.TabIndex = 16;
            this.numbersCB.Text = "draw numbers";
            this.gaugeTT.SetToolTip(this.numbersCB, "When checked, chart will include number of stitches\r\nfor every color segment in a" +
        " row so you don\'t have to count");
            this.numbersCB.UseVisualStyleBackColor = true;
            // 
            // negativeGridCB
            // 
            this.negativeGridCB.AutoSize = true;
            this.negativeGridCB.Location = new System.Drawing.Point(269, 44);
            this.negativeGridCB.Name = "negativeGridCB";
            this.negativeGridCB.Size = new System.Drawing.Size(98, 17);
            this.negativeGridCB.TabIndex = 15;
            this.negativeGridCB.Text = "contrasting grid";
            this.gaugeTT.SetToolTip(this.negativeGridCB, "If checked, grid will be drawn in a contrasting color\r\n\r\nYou can use this if your" +
        " yarns are very dark\r\nand the grid is not visible");
            this.negativeGridCB.UseVisualStyleBackColor = true;
            // 
            // stitchWidthNUD
            // 
            this.stitchWidthNUD.Location = new System.Drawing.Point(200, 44);
            this.stitchWidthNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.stitchWidthNUD.Name = "stitchWidthNUD";
            this.stitchWidthNUD.Size = new System.Drawing.Size(51, 20);
            this.stitchWidthNUD.TabIndex = 14;
            this.gaugeTT.SetToolTip(this.stitchWidthNUD, "Width of a single stitch in pixels\r\n\r\nThis mostly affects the quality of the stoc" +
        "kinette preview.\r\nYou can leave this be");
            this.stitchWidthNUD.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // lineThicknessNUD
            // 
            this.lineThicknessNUD.Location = new System.Drawing.Point(201, 18);
            this.lineThicknessNUD.Name = "lineThicknessNUD";
            this.lineThicknessNUD.Size = new System.Drawing.Size(51, 20);
            this.lineThicknessNUD.TabIndex = 13;
            this.gaugeTT.SetToolTip(this.lineThicknessNUD, "Thickness of the grid");
            this.lineThicknessNUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // rowCountNUD
            // 
            this.rowCountNUD.Location = new System.Drawing.Point(69, 70);
            this.rowCountNUD.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.rowCountNUD.Name = "rowCountNUD";
            this.rowCountNUD.Size = new System.Drawing.Size(51, 20);
            this.rowCountNUD.TabIndex = 12;
            this.gaugeTT.SetToolTip(this.rowCountNUD, "How many rows do you want your chart to have?");
            this.rowCountNUD.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // vGaugeNUD
            // 
            this.vGaugeNUD.Location = new System.Drawing.Point(69, 44);
            this.vGaugeNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.vGaugeNUD.Name = "vGaugeNUD";
            this.vGaugeNUD.Size = new System.Drawing.Size(51, 20);
            this.vGaugeNUD.TabIndex = 11;
            this.gaugeTT.SetToolTip(this.vGaugeNUD, "how many rows are there in your square swatch?");
            this.vGaugeNUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // hGaugeNUD
            // 
            this.hGaugeNUD.Location = new System.Drawing.Point(69, 18);
            this.hGaugeNUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.hGaugeNUD.Name = "hGaugeNUD";
            this.hGaugeNUD.Size = new System.Drawing.Size(51, 20);
            this.hGaugeNUD.TabIndex = 10;
            this.gaugeTT.SetToolTip(this.hGaugeNUD, "How many stitches (horizontally) are there in your square swatch?");
            this.hGaugeNUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // ditherCB
            // 
            this.ditherCB.AutoSize = true;
            this.ditherCB.Location = new System.Drawing.Point(269, 18);
            this.ditherCB.Margin = new System.Windows.Forms.Padding(2);
            this.ditherCB.Name = "ditherCB";
            this.ditherCB.Size = new System.Drawing.Size(79, 17);
            this.ditherCB.TabIndex = 9;
            this.ditherCB.Text = "dither chart";
            this.gaugeTT.SetToolTip(this.ditherCB, "If checked, chart will be dithered.\r\n\r\nOnly makes sense to use this if your origi" +
        "nal image is a photo\r\nor something with smooth color transitions.");
            this.ditherCB.UseVisualStyleBackColor = true;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "row count";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "h. gauge";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "v. gauge";
            // 
            // mainStatusStrip
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.mainStatusStrip, 2);
            this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainStatusLabel});
            this.mainStatusStrip.Location = new System.Drawing.Point(0, 391);
            this.mainStatusStrip.Name = "mainStatusStrip";
            this.mainStatusStrip.Size = new System.Drawing.Size(567, 22);
            this.mainStatusStrip.TabIndex = 5;
            // 
            // mainStatusLabel
            // 
            this.mainStatusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mainStatusLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mainStatusLabel.Name = "mainStatusLabel";
            this.mainStatusLabel.Size = new System.Drawing.Size(72, 17);
            this.mainStatusLabel.Text = "Hello there";
            this.mainStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picturePanel
            // 
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Controls.Add(this.mainPictureBox);
            this.picturePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePanel.Location = new System.Drawing.Point(153, 3);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(411, 262);
            this.picturePanel.TabIndex = 6;
            // 
            // mainPictureBox
            // 
            this.mainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mainPictureBox.Name = "mainPictureBox";
            this.mainPictureBox.Size = new System.Drawing.Size(411, 262);
            this.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.mainPictureBox.TabIndex = 0;
            this.mainPictureBox.TabStop = false;
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
            // sfd
            // 
            this.sfd.DefaultExt = "png";
            this.sfd.FileName = "normalchart";
            this.sfd.Filter = "PNG Image Files (*.png)|*.png";
            this.sfd.RestoreDirectory = true;
            // 
            // pictureCMS
            // 
            this.pictureCMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderModeMI});
            this.pictureCMS.Name = "pictureCMS";
            this.pictureCMS.Size = new System.Drawing.Size(143, 26);
            // 
            // renderModeMI
            // 
            this.renderModeMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renderFitMI,
            this.renderScrollMI});
            this.renderModeMI.Name = "renderModeMI";
            this.renderModeMI.Size = new System.Drawing.Size(142, 22);
            this.renderModeMI.Text = "render mode";
            // 
            // renderFitMI
            // 
            this.renderFitMI.Name = "renderFitMI";
            this.renderFitMI.Size = new System.Drawing.Size(102, 22);
            this.renderFitMI.Text = "fit";
            this.renderFitMI.Click += new System.EventHandler(this.RenderFitMI_Click);
            // 
            // renderScrollMI
            // 
            this.renderScrollMI.Name = "renderScrollMI";
            this.renderScrollMI.Size = new System.Drawing.Size(102, 22);
            this.renderScrollMI.Text = "scroll";
            this.renderScrollMI.Click += new System.EventHandler(this.renderScrollMI_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 413);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Chart Designer";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.chartSettingsGB.ResumeLayout(false);
            this.chartSettingsGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stitchWidthNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lineThicknessNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowCountNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGaugeNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGaugeNUD)).EndInit();
            this.mainStatusStrip.ResumeLayout(false);
            this.mainStatusStrip.PerformLayout();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainPictureBox)).EndInit();
            this.pictureCMS.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button LoadImageButton;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox chartSettingsGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button showStockButton;
        private System.Windows.Forms.Button createStockChartButton;
        private System.Windows.Forms.CheckBox ditherCB;
        private System.Windows.Forms.NumericUpDown stitchWidthNUD;
        private System.Windows.Forms.NumericUpDown lineThicknessNUD;
        private System.Windows.Forms.NumericUpDown rowCountNUD;
        private System.Windows.Forms.NumericUpDown vGaugeNUD;
        private System.Windows.Forms.NumericUpDown hGaugeNUD;
        private System.Windows.Forms.CheckBox negativeGridCB;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button saveStockChartButton;
        private System.Windows.Forms.Button saveChartButton;
        private System.Windows.Forms.StatusStrip mainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel mainStatusLabel;
        private System.Windows.Forms.CheckBox numbersCB;
        private System.Windows.Forms.Panel picturePanel;
        private System.Windows.Forms.PictureBox mainPictureBox;
        private System.Windows.Forms.ContextMenuStrip pictureCMS;
        private System.Windows.Forms.ToolStripMenuItem renderModeMI;
        private System.Windows.Forms.ToolStripMenuItem renderFitMI;
        private System.Windows.Forms.ToolStripMenuItem renderScrollMI;
    }
}

