namespace Tallbilde
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
         this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.clearMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.visHistorieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.setFasitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.checkFasitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.stepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.brettControl = new Tallbilde.BrettControl();
         this.x15ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.x20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.x25ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.x35ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.menuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip
         // 
         this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
         this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
         this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.clearMenuItem,
            this.setupMenuItem,
            this.visHistorieToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.pauseToolStripMenuItem,
            this.stepToolStripMenuItem});
         this.menuStrip.Location = new System.Drawing.Point(0, 0);
         this.menuStrip.Name = "menuStrip";
         this.menuStrip.Size = new System.Drawing.Size(848, 35);
         this.menuStrip.TabIndex = 0;
         this.menuStrip.Text = "menuStrip1";
         // 
         // fileToolStripMenuItem
         // 
         this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.skrivFilToolStripMenuItem,
            this.skrivSomToolStripMenuItem,
            this.restartToolStripMenuItem});
         this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
         this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
         this.fileToolStripMenuItem.Text = "File";
         // 
         // loadToolStripMenuItem1
         // 
         this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
         this.loadToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
         this.loadToolStripMenuItem1.Text = "Les fil";
         this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadMenu_Click);
         // 
         // skrivFilToolStripMenuItem
         // 
         this.skrivFilToolStripMenuItem.Name = "skrivFilToolStripMenuItem";
         this.skrivFilToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.skrivFilToolStripMenuItem.Text = "Skriv fil";
         this.skrivFilToolStripMenuItem.Click += new System.EventHandler(this.skrivFilMenu_Click);
         // 
         // skrivSomToolStripMenuItem
         // 
         this.skrivSomToolStripMenuItem.Name = "skrivSomToolStripMenuItem";
         this.skrivSomToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.skrivSomToolStripMenuItem.Text = "Skriv som";
         this.skrivSomToolStripMenuItem.Click += new System.EventHandler(this.skrivSomMenu_Click);
         // 
         // restartToolStripMenuItem
         // 
         this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
         this.restartToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.restartToolStripMenuItem.Text = "Restart";
         this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
         // 
         // clearMenuItem
         // 
         this.clearMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x15ToolStripMenuItem,
            this.x20ToolStripMenuItem,
            this.x25ToolStripMenuItem,
            this.x35ToolStripMenuItem});
         this.clearMenuItem.Name = "clearMenuItem";
         this.clearMenuItem.Size = new System.Drawing.Size(67, 29);
         this.clearMenuItem.Text = "Clear";
         // 
         // setupMenuItem
         // 
         this.setupMenuItem.Name = "setupMenuItem";
         this.setupMenuItem.Size = new System.Drawing.Size(16, 29);
         // 
         // visHistorieToolStripMenuItem
         // 
         this.visHistorieToolStripMenuItem.Name = "visHistorieToolStripMenuItem";
         this.visHistorieToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
         this.visHistorieToolStripMenuItem.Text = "Vis historie";
         this.visHistorieToolStripMenuItem.Click += new System.EventHandler(this.visHistorieToolStripMenuItem_Click);
         // 
         // optionsToolStripMenuItem
         // 
         this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setFasitToolStripMenuItem,
            this.checkFasitToolStripMenuItem});
         this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
         this.optionsToolStripMenuItem.Size = new System.Drawing.Size(92, 29);
         this.optionsToolStripMenuItem.Text = "Options";
         // 
         // setFasitToolStripMenuItem
         // 
         this.setFasitToolStripMenuItem.Name = "setFasitToolStripMenuItem";
         this.setFasitToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
         this.setFasitToolStripMenuItem.Text = "Set fasit";
         this.setFasitToolStripMenuItem.Click += new System.EventHandler(this.setFasitToolStripMenuItem_Click);
         // 
         // checkFasitToolStripMenuItem
         // 
         this.checkFasitToolStripMenuItem.Name = "checkFasitToolStripMenuItem";
         this.checkFasitToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
         this.checkFasitToolStripMenuItem.Text = "Sjekk fasit";
         this.checkFasitToolStripMenuItem.Click += new System.EventHandler(this.checkToolStripMenuItem_Click);
         // 
         // aboutToolStripMenuItem
         // 
         this.aboutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
         this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
         this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 29);
         this.aboutToolStripMenuItem.Text = "About";
         this.aboutToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         this.aboutToolStripMenuItem.Click += new System.EventHandler(this.OnAbout);
         // 
         // pauseToolStripMenuItem
         // 
         this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
         this.pauseToolStripMenuItem.Size = new System.Drawing.Size(73, 29);
         this.pauseToolStripMenuItem.Text = "Pause";
         this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
         // 
         // stepToolStripMenuItem
         // 
         this.stepToolStripMenuItem.CheckOnClick = true;
         this.stepToolStripMenuItem.Name = "stepToolStripMenuItem";
         this.stepToolStripMenuItem.Size = new System.Drawing.Size(63, 29);
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
         this.brettControl.BackColor = System.Drawing.Color.White;
         this.brettControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.brettControl.Location = new System.Drawing.Point(0, 35);
         this.brettControl.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
         this.brettControl.Name = "brettControl";
         this.brettControl.Size = new System.Drawing.Size(848, 817);
         this.brettControl.TabIndex = 2;
         // 
         // x15ToolStripMenuItem
         // 
         this.x15ToolStripMenuItem.Name = "x15ToolStripMenuItem";
         this.x15ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.x15ToolStripMenuItem.Text = "15x15";
         this.x15ToolStripMenuItem.Click += new System.EventHandler(this.Clear_15x15ToolStripMenuItem_Click);
         // 
         // x20ToolStripMenuItem
         // 
         this.x20ToolStripMenuItem.Name = "x20ToolStripMenuItem";
         this.x20ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.x20ToolStripMenuItem.Text = "20x20";
         this.x20ToolStripMenuItem.Click += new System.EventHandler(this.Clear_20x20ToolStripMenuItem_Click);
         // 
         // x25ToolStripMenuItem
         // 
         this.x25ToolStripMenuItem.Name = "x25ToolStripMenuItem";
         this.x25ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.x25ToolStripMenuItem.Text = "20x30";
         this.x25ToolStripMenuItem.Click += new System.EventHandler(this.Clear_20x30ToolStripMenuItem_Click);
         // 
         // x35ToolStripMenuItem
         // 
         this.x35ToolStripMenuItem.Name = "x35ToolStripMenuItem";
         this.x35ToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
         this.x35ToolStripMenuItem.Text = "25x35";
         this.x35ToolStripMenuItem.Click += new System.EventHandler(this.Clear_25x35ToolStripMenuItem_Click);
         // 
         // canvasForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(848, 852);
         this.Controls.Add(this.brettControl);
         this.Controls.Add(this.menuStrip);
         this.MainMenuStrip = this.menuStrip;
         this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.Name = "canvasForm";
         this.Text = "Bilde";
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
        private System.Windows.Forms.ToolStripMenuItem stepToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem skrivFilToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem skrivSomToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem setFasitToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem checkFasitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem visHistorieToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem x15ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem x20ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem x25ToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem x35ToolStripMenuItem;
   }
}
