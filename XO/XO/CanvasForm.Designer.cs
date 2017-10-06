namespace XO
{
    partial class canvasForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.size10ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hintSingelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brettControl = new XO.BrettControl();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearMenuItem,
            this.setupMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.stepToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(565, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.size10ToolStripMenuItem});
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearMenuItem.Text = "Clear";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.normalToolStripMenuItem.Text = "Size 14";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.clear14ToolStripMenuItem_Click);
            // 
            // size10ToolStripMenuItem
            // 
            this.size10ToolStripMenuItem.Name = "size10ToolStripMenuItem";
            this.size10ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.size10ToolStripMenuItem.Text = "Size 10";
            this.size10ToolStripMenuItem.Click += new System.EventHandler(this.clear10ToolStripMenuItem_Click);
            // 
            // setupMenuItem
            // 
            this.setupMenuItem.Name = "setupMenuItem";
            this.setupMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hintSingelToolStripMenuItem,
            this.autoSettingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // hintSingelToolStripMenuItem
            // 
            this.hintSingelToolStripMenuItem.Checked = true;
            this.hintSingelToolStripMenuItem.CheckOnClick = true;
            this.hintSingelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hintSingelToolStripMenuItem.Name = "hintSingelToolStripMenuItem";
            this.hintSingelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hintSingelToolStripMenuItem.Text = "Hint";
            this.hintSingelToolStripMenuItem.Click += new System.EventHandler(this.OnHint);
            // 
            // autoSettingsToolStripMenuItem
            // 
            this.autoSettingsToolStripMenuItem.CheckOnClick = true;
            this.autoSettingsToolStripMenuItem.Name = "autoSettingsToolStripMenuItem";
            this.autoSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoSettingsToolStripMenuItem.Text = "Auto";
            this.autoSettingsToolStripMenuItem.Click += new System.EventHandler(this.OnAuto);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAbout);
            // 
            // stepToolStripMenuItem
            // 
            this.stepToolStripMenuItem.CheckOnClick = true;
            this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
            this.stepToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.stepToolStripMenuItem.Text = "Step";
            this.stepToolStripMenuItem.Click += new System.EventHandler(this.stepToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // brettControl
            // 
            this.brettControl.AccessibleName = "";
            this.brettControl.Auto = true;
            this.brettControl.BackColor = System.Drawing.Color.White;
            this.brettControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brettControl.Hint = true;
            this.brettControl.Location = new System.Drawing.Point(0, 24);
            this.brettControl.Name = "brettControl";
            this.brettControl.Size = new System.Drawing.Size(565, 530);
            this.brettControl.Step = false;
            this.brettControl.TabIndex = 2;
            // 
            // canvasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 554);
            this.Controls.Add(this.brettControl);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "canvasForm";
            this.Text = "Sudoku";
            this.Resize += new System.EventHandler(this.OnResize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private BrettControl brettControl;
        private System.Windows.Forms.ToolStripMenuItem setupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintSingelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem size10ToolStripMenuItem;
    }
}

