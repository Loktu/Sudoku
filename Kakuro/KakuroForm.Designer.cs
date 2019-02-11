namespace Kakuro
{
   partial class KakuroForm
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
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.beregn = new System.Windows.Forms.Button();
         this.resultatboks = new System.Windows.Forms.TextBox();
         this.antall = new System.Windows.Forms.NumericUpDown();
         this.nei_boks = new System.Windows.Forms.TextBox();
         this.ja_boks = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
         this.sum = new System.Windows.Forms.NumericUpDown();
         this.tableLayoutPanel1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.antall)).BeginInit();
         this.tableLayoutPanel2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.sum)).BeginInit();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.beregn, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.resultatboks, 0, 2);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Size = new System.Drawing.Size(398, 568);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // beregn
         // 
         this.beregn.Anchor = System.Windows.Forms.AnchorStyles.Top;
         this.beregn.AutoSize = true;
         this.beregn.Location = new System.Drawing.Point(161, 109);
         this.beregn.Name = "beregn";
         this.beregn.Size = new System.Drawing.Size(75, 31);
         this.beregn.TabIndex = 1;
         this.beregn.Text = "Beregn";
         this.beregn.UseVisualStyleBackColor = true;
         this.beregn.Click += new System.EventHandler(this.beregn_Click);
         // 
         // resultatboks
         // 
         this.resultatboks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.resultatboks.Location = new System.Drawing.Point(3, 146);
         this.resultatboks.Multiline = true;
         this.resultatboks.Name = "resultatboks";
         this.resultatboks.Size = new System.Drawing.Size(392, 419);
         this.resultatboks.TabIndex = 2;
         // 
         // antall
         // 
         this.antall.Dock = System.Windows.Forms.DockStyle.Left;
         this.antall.Location = new System.Drawing.Point(145, 3);
         this.antall.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
         this.antall.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this.antall.Name = "antall";
         this.antall.Size = new System.Drawing.Size(120, 22);
         this.antall.TabIndex = 8;
         this.antall.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // nei_boks
         // 
         this.nei_boks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.nei_boks.Location = new System.Drawing.Point(145, 78);
         this.nei_boks.Name = "nei_boks";
         this.nei_boks.Size = new System.Drawing.Size(244, 22);
         this.nei_boks.TabIndex = 7;
         // 
         // ja_boks
         // 
         this.ja_boks.Dock = System.Windows.Forms.DockStyle.Fill;
         this.ja_boks.Location = new System.Drawing.Point(145, 53);
         this.ja_boks.Name = "ja_boks";
         this.ja_boks.Size = new System.Drawing.Size(244, 22);
         this.ja_boks.TabIndex = 6;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label4.Location = new System.Drawing.Point(3, 75);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(136, 25);
         this.label4.TabIndex = 3;
         this.label4.Text = "Skal ikke være med:";
         this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label3.Location = new System.Drawing.Point(3, 50);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(136, 25);
         this.label3.TabIndex = 2;
         this.label3.Text = "Skal være med:";
         this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label2.Location = new System.Drawing.Point(3, 25);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(136, 25);
         this.label2.TabIndex = 1;
         this.label2.Text = "Sum:";
         this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.label1.Location = new System.Drawing.Point(3, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(136, 25);
         this.label1.TabIndex = 0;
         this.label1.Text = "Antall:";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
         // 
         // tableLayoutPanel2
         // 
         this.tableLayoutPanel2.ColumnCount = 2;
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
         this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
         this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
         this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
         this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
         this.tableLayoutPanel2.Controls.Add(this.ja_boks, 1, 2);
         this.tableLayoutPanel2.Controls.Add(this.nei_boks, 1, 3);
         this.tableLayoutPanel2.Controls.Add(this.antall, 1, 0);
         this.tableLayoutPanel2.Controls.Add(this.sum, 1, 1);
         this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
         this.tableLayoutPanel2.Name = "tableLayoutPanel2";
         this.tableLayoutPanel2.RowCount = 4;
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
         this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
         this.tableLayoutPanel2.Size = new System.Drawing.Size(392, 100);
         this.tableLayoutPanel2.TabIndex = 0;
         // 
         // sum
         // 
         this.sum.Dock = System.Windows.Forms.DockStyle.Left;
         this.sum.Location = new System.Drawing.Point(145, 28);
         this.sum.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
         this.sum.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
         this.sum.Name = "sum";
         this.sum.Size = new System.Drawing.Size(120, 22);
         this.sum.TabIndex = 9;
         this.sum.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
         // 
         // KakuroForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(398, 568);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "KakuroForm";
         this.Text = "Kakuro løsninger";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.antall)).EndInit();
         this.tableLayoutPanel2.ResumeLayout(false);
         this.tableLayoutPanel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.sum)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.Button beregn;
      private System.Windows.Forms.TextBox resultatboks;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.TextBox ja_boks;
      private System.Windows.Forms.TextBox nei_boks;
      private System.Windows.Forms.NumericUpDown antall;
      private System.Windows.Forms.NumericUpDown sum;
   }
}

