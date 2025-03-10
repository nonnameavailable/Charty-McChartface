namespace ChartCreator
{
    partial class YCSHolder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.clickColorCB = new System.Windows.Forms.CheckBox();
            this.removeColorButton = new System.Windows.Forms.Button();
            this.addColorButton = new System.Windows.Forms.Button();
            this.colorsFLP = new System.Windows.Forms.FlowLayoutPanel();
            this.backBTN = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.colorsFLP, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(124, 334);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backBTN);
            this.panel1.Controls.Add(this.clickColorCB);
            this.panel1.Controls.Add(this.removeColorButton);
            this.panel1.Controls.Add(this.addColorButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(118, 54);
            this.panel1.TabIndex = 0;
            // 
            // clickColorCB
            // 
            this.clickColorCB.AutoSize = true;
            this.clickColorCB.Checked = true;
            this.clickColorCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.clickColorCB.Location = new System.Drawing.Point(7, 33);
            this.clickColorCB.Margin = new System.Windows.Forms.Padding(2);
            this.clickColorCB.Name = "clickColorCB";
            this.clickColorCB.Size = new System.Drawing.Size(74, 17);
            this.clickColorCB.TabIndex = 6;
            this.clickColorCB.Text = "click color";
            this.clickColorCB.UseVisualStyleBackColor = true;
            // 
            // removeColorButton
            // 
            this.removeColorButton.Location = new System.Drawing.Point(64, 3);
            this.removeColorButton.Name = "removeColorButton";
            this.removeColorButton.Size = new System.Drawing.Size(52, 23);
            this.removeColorButton.TabIndex = 5;
            this.removeColorButton.Text = "remove";
            this.removeColorButton.UseVisualStyleBackColor = true;
            // 
            // addColorButton
            // 
            this.addColorButton.Location = new System.Drawing.Point(3, 3);
            this.addColorButton.Name = "addColorButton";
            this.addColorButton.Size = new System.Drawing.Size(55, 23);
            this.addColorButton.TabIndex = 4;
            this.addColorButton.Text = "add";
            this.addColorButton.UseVisualStyleBackColor = true;
            // 
            // colorsFLP
            // 
            this.colorsFLP.AutoScroll = true;
            this.colorsFLP.BackColor = System.Drawing.Color.Transparent;
            this.colorsFLP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorsFLP.Location = new System.Drawing.Point(3, 63);
            this.colorsFLP.Name = "colorsFLP";
            this.colorsFLP.Size = new System.Drawing.Size(118, 268);
            this.colorsFLP.TabIndex = 3;
            // 
            // backBTN
            // 
            this.backBTN.Location = new System.Drawing.Point(69, 28);
            this.backBTN.Name = "backBTN";
            this.backBTN.Size = new System.Drawing.Size(47, 23);
            this.backBTN.TabIndex = 7;
            this.backBTN.Text = "back";
            this.backBTN.UseVisualStyleBackColor = true;
            // 
            // YCSHolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "YCSHolder";
            this.Size = new System.Drawing.Size(124, 334);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox clickColorCB;
        private System.Windows.Forms.Button removeColorButton;
        private System.Windows.Forms.Button addColorButton;
        private System.Windows.Forms.FlowLayoutPanel colorsFLP;
        private System.Windows.Forms.Button backBTN;
    }
}
