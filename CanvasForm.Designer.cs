namespace Sudoku
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.skrivFilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skrivSomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.normalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.irregulærToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagonalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hintSingelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSingelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auto1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auto2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auto3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brettControl = new Sudoku.BrettControl();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.skrivFilToolStripMenuItem,
            this.skrivSomToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.loadToolStripMenuItem1.Text = "Les fil";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // skrivFilToolStripMenuItem
            // 
            this.skrivFilToolStripMenuItem.Name = "skrivFilToolStripMenuItem";
            this.skrivFilToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.skrivFilToolStripMenuItem.Text = "Skriv fil";
            this.skrivFilToolStripMenuItem.Click += new System.EventHandler(this.skrivFilToolStripMenuItem_Click);
            // 
            // skrivSomToolStripMenuItem
            // 
            this.skrivSomToolStripMenuItem.Name = "skrivSomToolStripMenuItem";
            this.skrivSomToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.skrivSomToolStripMenuItem.Text = "Skriv som";
            // 
            // clearMenuItem
            // 
            this.clearMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.normalToolStripMenuItem,
            this.irregulærToolStripMenuItem});
            this.clearMenuItem.Name = "clearMenuItem";
            this.clearMenuItem.Size = new System.Drawing.Size(46, 20);
            this.clearMenuItem.Text = "Clear";
            // 
            // normalToolStripMenuItem
            // 
            this.normalToolStripMenuItem.Name = "normalToolStripMenuItem";
            this.normalToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.normalToolStripMenuItem.Text = "Normal";
            this.normalToolStripMenuItem.Click += new System.EventHandler(this.normalToolStripMenuItem_Click);
            // 
            // irregulærToolStripMenuItem
            // 
            this.irregulærToolStripMenuItem.Name = "irregulærToolStripMenuItem";
            this.irregulærToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.irregulærToolStripMenuItem.Text = "Irregulær";
            this.irregulærToolStripMenuItem.Click += new System.EventHandler(this.irregulærToolStripMenuItem_Click);
            // 
            // setupMenuItem
            // 
            this.setupMenuItem.Name = "setupMenuItem";
            this.setupMenuItem.Size = new System.Drawing.Size(12, 20);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.diagonalToolStripMenuItem1,
            this.hintSingelToolStripMenuItem,
            this.autoSettingsToolStripMenuItem,
            this.autoSingelToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // diagonalToolStripMenuItem1
            // 
            this.diagonalToolStripMenuItem1.CheckOnClick = true;
            this.diagonalToolStripMenuItem1.Name = "diagonalToolStripMenuItem1";
            this.diagonalToolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.diagonalToolStripMenuItem1.Text = "Diagonal";
            this.diagonalToolStripMenuItem1.Click += new System.EventHandler(this.OnDiagonal);
            // 
            // hintSingelToolStripMenuItem
            // 
            this.hintSingelToolStripMenuItem.Checked = true;
            this.hintSingelToolStripMenuItem.CheckOnClick = true;
            this.hintSingelToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hintSingelToolStripMenuItem.Name = "hintSingelToolStripMenuItem";
            this.hintSingelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.hintSingelToolStripMenuItem.Text = "Hint";
            this.hintSingelToolStripMenuItem.Click += new System.EventHandler(this.OnHint);
            // 
            // autoSettingsToolStripMenuItem
            // 
            this.autoSettingsToolStripMenuItem.CheckOnClick = true;
            this.autoSettingsToolStripMenuItem.Name = "autoSettingsToolStripMenuItem";
            this.autoSettingsToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.autoSettingsToolStripMenuItem.Text = "Auto";
            this.autoSettingsToolStripMenuItem.Click += new System.EventHandler(this.OnAuto);
            // 
            // autoSingelToolStripMenuItem
            // 
            this.autoSingelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auto1ToolStripMenuItem,
            this.auto2ToolStripMenuItem,
            this.auto3ToolStripMenuItem});
            this.autoSingelToolStripMenuItem.Name = "autoSingelToolStripMenuItem";
            this.autoSingelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.autoSingelToolStripMenuItem.Text = "Auto Settings";
            // 
            // auto1ToolStripMenuItem
            // 
            this.auto1ToolStripMenuItem.Checked = true;
            this.auto1ToolStripMenuItem.CheckOnClick = true;
            this.auto1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.auto1ToolStripMenuItem.Name = "auto1ToolStripMenuItem";
            this.auto1ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.auto1ToolStripMenuItem.Text = "Auto1";
            this.auto1ToolStripMenuItem.Click += new System.EventHandler(this.auto1ToolStripMenuItem_Click);
            // 
            // auto2ToolStripMenuItem
            // 
            this.auto2ToolStripMenuItem.Checked = true;
            this.auto2ToolStripMenuItem.CheckOnClick = true;
            this.auto2ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.auto2ToolStripMenuItem.Name = "auto2ToolStripMenuItem";
            this.auto2ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.auto2ToolStripMenuItem.Text = "Auto2";
            this.auto2ToolStripMenuItem.Click += new System.EventHandler(this.auto2ToolStripMenuItem_Click);
            // 
            // auto3ToolStripMenuItem
            // 
            this.auto3ToolStripMenuItem.Checked = true;
            this.auto3ToolStripMenuItem.CheckOnClick = true;
            this.auto3ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.auto3ToolStripMenuItem.Name = "auto3ToolStripMenuItem";
            this.auto3ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.auto3ToolStripMenuItem.Text = "Auto3";
            this.auto3ToolStripMenuItem.Click += new System.EventHandler(this.auto3ToolStripMenuItem_Click);
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
            this.brettControl.Auto1 = true;
            this.brettControl.Auto2 = true;
            this.brettControl.Auto3 = true;
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
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem skrivFilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skrivSomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagonalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem autoSingelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hintSingelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auto1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auto2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auto3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem normalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem irregulærToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;

    }
}

