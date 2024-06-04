namespace Bilde
{
   partial class HistoryForm
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
         this.bottomLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
         this.okButton = new System.Windows.Forms.Button();
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Dato = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Object = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.tableLayoutPanel1.SuspendLayout();
         this.bottomLayoutPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // tableLayoutPanel1
         // 
         this.tableLayoutPanel1.ColumnCount = 1;
         this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.Controls.Add(this.bottomLayoutPanel, 0, 1);
         this.tableLayoutPanel1.Controls.Add(this.dataGridView, 0, 0);
         this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
         this.tableLayoutPanel1.Name = "tableLayoutPanel1";
         this.tableLayoutPanel1.RowCount = 2;
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
         this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
         this.tableLayoutPanel1.Size = new System.Drawing.Size(297, 363);
         this.tableLayoutPanel1.TabIndex = 0;
         // 
         // bottomLayoutPanel
         // 
         this.bottomLayoutPanel.AutoSize = true;
         this.bottomLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.bottomLayoutPanel.Controls.Add(this.okButton);
         this.bottomLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this.bottomLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
         this.bottomLayoutPanel.Location = new System.Drawing.Point(3, 331);
         this.bottomLayoutPanel.Name = "bottomLayoutPanel";
         this.bottomLayoutPanel.Size = new System.Drawing.Size(291, 29);
         this.bottomLayoutPanel.TabIndex = 0;
         // 
         // okButton
         // 
         this.okButton.Location = new System.Drawing.Point(213, 3);
         this.okButton.Name = "okButton";
         this.okButton.Size = new System.Drawing.Size(75, 23);
         this.okButton.TabIndex = 0;
         this.okButton.Text = "Ok";
         this.okButton.UseVisualStyleBackColor = true;
         this.okButton.Click += new System.EventHandler(this.OkButton_Click);
         // 
         // dataGridView
         // 
         this.dataGridView.AllowUserToAddRows = false;
         this.dataGridView.AllowUserToOrderColumns = true;
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nr,
            this.Dato,
            this.Tid,
            this.Object});
         this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
         this.dataGridView.Location = new System.Drawing.Point(3, 3);
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.ReadOnly = true;
         this.dataGridView.Size = new System.Drawing.Size(291, 322);
         this.dataGridView.TabIndex = 1;
         // 
         // Nr
         // 
         this.Nr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.Nr.HeaderText = "Nr";
         this.Nr.Name = "Nr";
         this.Nr.ReadOnly = true;
         this.Nr.Width = 43;
         // 
         // Dato
         // 
         this.Dato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.Dato.HeaderText = "Dato";
         this.Dato.Name = "Dato";
         this.Dato.ReadOnly = true;
         this.Dato.Width = 55;
         // 
         // Tid
         // 
         this.Tid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         this.Tid.HeaderText = "Tid";
         this.Tid.Name = "Tid";
         this.Tid.ReadOnly = true;
         this.Tid.Width = 47;
         // 
         // Object
         // 
         this.Object.HeaderText = "Object";
         this.Object.Name = "Object";
         this.Object.ReadOnly = true;
         this.Object.Visible = false;
         // 
         // HistoryForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(297, 363);
         this.Controls.Add(this.tableLayoutPanel1);
         this.Name = "HistoryForm";
         this.Text = "HistoryForm";
         this.tableLayoutPanel1.ResumeLayout(false);
         this.tableLayoutPanel1.PerformLayout();
         this.bottomLayoutPanel.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      private System.Windows.Forms.FlowLayoutPanel bottomLayoutPanel;
      private System.Windows.Forms.Button okButton;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
      private System.Windows.Forms.DataGridViewTextBoxColumn Dato;
      private System.Windows.Forms.DataGridViewTextBoxColumn Tid;
      private System.Windows.Forms.DataGridViewTextBoxColumn Object;
   }
}