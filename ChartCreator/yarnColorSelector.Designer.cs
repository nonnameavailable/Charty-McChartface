
namespace ChartCreator
{
    partial class yarnColorSelector
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yarnColorSelector));
            this.selectColorButton = new System.Windows.Forms.Button();
            this.yarnColorTB = new System.Windows.Forms.TextBox();
            this.yarnColorDialog = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.replacementColorButton = new System.Windows.Forms.Button();
            this.paintCB = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // selectColorButton
            // 
            this.selectColorButton.Location = new System.Drawing.Point(2, 2);
            this.selectColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectColorButton.Name = "selectColorButton";
            this.selectColorButton.Size = new System.Drawing.Size(31, 21);
            this.selectColorButton.TabIndex = 0;
            this.toolTip1.SetToolTip(this.selectColorButton, "Primary color.\r\nLeave this unchanged if picked from image.");
            this.selectColorButton.UseVisualStyleBackColor = true;
            this.selectColorButton.Click += new System.EventHandler(this.selectColorButton_Click);
            // 
            // yarnColorTB
            // 
            this.yarnColorTB.Location = new System.Drawing.Point(38, 2);
            this.yarnColorTB.Name = "yarnColorTB";
            this.yarnColorTB.Size = new System.Drawing.Size(73, 20);
            this.yarnColorTB.TabIndex = 1;
            this.yarnColorTB.Text = "yarn name";
            this.toolTip1.SetToolTip(this.yarnColorTB, "The name of this yarn color");
            // 
            // yarnColorDialog
            // 
            this.yarnColorDialog.Color = System.Drawing.Color.White;
            // 
            // replacementColorButton
            // 
            this.replacementColorButton.Location = new System.Drawing.Point(2, 27);
            this.replacementColorButton.Margin = new System.Windows.Forms.Padding(2);
            this.replacementColorButton.Name = "replacementColorButton";
            this.replacementColorButton.Size = new System.Drawing.Size(31, 21);
            this.replacementColorButton.TabIndex = 2;
            this.toolTip1.SetToolTip(this.replacementColorButton, resources.GetString("replacementColorButton.ToolTip"));
            this.replacementColorButton.UseVisualStyleBackColor = true;
            this.replacementColorButton.Click += new System.EventHandler(this.replacementColorButton_Click);
            // 
            // paintCB
            // 
            this.paintCB.AutoSize = true;
            this.paintCB.Location = new System.Drawing.Point(38, 30);
            this.paintCB.Name = "paintCB";
            this.paintCB.Size = new System.Drawing.Size(49, 17);
            this.paintCB.TabIndex = 3;
            this.paintCB.Text = "paint";
            this.toolTip1.SetToolTip(this.paintCB, "When checked, this color will be used to paint.\r\n\r\nClick color checkbox needs to " +
        "be unchecked for this to work!");
            this.paintCB.UseVisualStyleBackColor = true;
            // 
            // yarnColorSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paintCB);
            this.Controls.Add(this.replacementColorButton);
            this.Controls.Add(this.yarnColorTB);
            this.Controls.Add(this.selectColorButton);
            this.Name = "yarnColorSelector";
            this.Size = new System.Drawing.Size(116, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.TextBox yarnColorTB;
        private System.Windows.Forms.ColorDialog yarnColorDialog;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button replacementColorButton;
        private System.Windows.Forms.CheckBox paintCB;
    }
}
