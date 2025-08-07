namespace Bilde
{
   partial class HistoryGraphForm
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
         this.graphControl = new Bilde.GraphControl();
         this.SuspendLayout();
         // 
         // graphControl
         // 
         this.graphControl.Dock = System.Windows.Forms.DockStyle.Fill;
         this.graphControl.Location = new System.Drawing.Point(0, 0);
         this.graphControl.Name = "graphControl";
         this.graphControl.Size = new System.Drawing.Size(1079, 563);
         this.graphControl.TabIndex = 0;
         this.graphControl.VisibleChanged += new System.EventHandler(this.graphControl_VisibleChanged);
         // 
         // HistoryGraphForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1079, 563);
         this.Controls.Add(this.graphControl);
         this.Name = "HistoryGraphForm";
         this.Text = "HistoryGraphForm";
         this.ResumeLayout(false);

      }

      #endregion

      private GraphControl graphControl;
   }
}