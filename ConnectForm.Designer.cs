namespace Sudoku
{
   partial class ConnectForm
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
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.Kanal = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Fra = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Til = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.okButton = new System.Windows.Forms.Button();
         this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
         this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
         this.serverKanalLabel = new System.Windows.Forms.Label();
         this.serverKanal = new System.Windows.Forms.TextBox();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         this.tableLayoutPanel1.SuspendLayout();
         this.flowLayoutPanel1.SuspendLayout();
         this.SuspendLayout();
         // 
         // dataGridView
         // 
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Kanal,
            this.Fra,
            this.Til});
         this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView.Location = new System.Drawing.Point(3, 35);
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.Size = new System.Drawing.Size(351, 231);
         this.dataGridView.TabIndex = 0;
         // 
         // Kanal
         // 
         this.Kanal.HeaderText = "Kanal";
         this.Kanal.Name = "Kanal";
         // 
         // Fra
         // 
         this.Fra.HeaderText = "Fra";
         this.Fra.Name = "Fra";
         // 
         // Til
         // 
         this.Til.HeaderText = "Til";
         this.Til.Name = "Til";
         // 
         // okButton
         // 
         this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.okButton.AutoSize = true;
         this.okButton.Location = new System.Drawing.Point(279, 272);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 23);
         this.okButton.TabIndex = 1;
         this.okButton.Text = "Ok";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.OkButton_Click);
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.tableLayoutPanel1.AutoSize = true;
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
         this.tableLayoutPanel1.Controls.Add(this.okButton, 0, 2);
         this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 3);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 3;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(357, 298);
         this.tableLayoutPanel1.TabIndex = 2;
         // 
         // flowLayoutPanel1
         // 
         this.flowLayoutPanel1.AutoSize = true;
         this.flowLayoutPanel1.Controls.Add(this.serverKanalLabel);
         this.flowLayoutPanel1.Controls.Add(this.serverKanal);
         this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
         this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
         this.flowLayoutPanel1.Name = "flowLayoutPanel1";
         this.flowLayoutPanel1.Size = new System.Drawing.Size(351, 26);
         this.flowLayoutPanel1.TabIndex = 2;
         // 
         // serverKanalLabel
         // 
         this.serverKanalLabel.AutoSize = true;
         this.serverKanalLabel.Dock = System.Windows.Forms.DockStyle.Left;
         this.serverKanalLabel.Location = new System.Drawing.Point(3, 0);
         this.serverKanalLabel.Name = "serverKanalLabel";
         this.serverKanalLabel.Size = new System.Drawing.Size(74, 26);
         this.serverKanalLabel.TabIndex = 0;
         this.serverKanalLabel.Text = "Server Kanal: ";
         this.serverKanalLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // serverKanal
         // 
         this.serverKanal.Location = new System.Drawing.Point(83, 3);
         this.serverKanal.Name = "serverKanal";
         this.serverKanal.Size = new System.Drawing.Size(100, 20);
         this.serverKanal.TabIndex = 1;
         // 
         // ConnectForm
         // 
         this.AcceptButton = this.okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(365, 305);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "ConnectForm";
         this.Text = "ConnectForm";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.flowLayoutPanel1.ResumeLayout(false);
         this.flowLayoutPanel1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.DataGridViewTextBoxColumn Kanal;
      private System.Windows.Forms.DataGridViewTextBoxColumn Fra;
      private System.Windows.Forms.DataGridViewTextBoxColumn Til;
      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
      private System.Windows.Forms.Label serverKanalLabel;
      private System.Windows.Forms.TextBox serverKanal;
   }
}