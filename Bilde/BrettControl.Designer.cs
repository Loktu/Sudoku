using System;

namespace Bilde
{
    partial class BrettControl
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
         this.SuspendLayout();
         // 
         // BrettControl
         // 
         this.AccessibleName = "";
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.DoubleBuffered = true;
         this.Name = "BrettControl";
         this.Size = new System.Drawing.Size(302, 240);
         this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
         this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BrettControl_KeyPress);
         this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
         this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BrettControl_MouseMove);
         this.ResumeLayout(false);

        }
      #endregion
   }
}
