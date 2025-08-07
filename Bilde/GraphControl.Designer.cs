namespace Bilde
{
   partial class GraphControl
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
         System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
         System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
         this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
         this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.lessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.yaxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.xaxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.xaxisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuDele = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuGange = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuPluss = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripMenuMinus = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
         this.contextMenuStrip.SuspendLayout();
         this.SuspendLayout();
         // 
         // chart
         // 
         chartArea1.AxisX.Interval = 1D;
         chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
         chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Months;
         chartArea1.AxisX.ScrollBar.ButtonColor = System.Drawing.Color.LightSteelBlue;
         chartArea1.AxisX.ScrollBar.IsPositionedInside = false;
         chartArea1.AxisY.ScrollBar.ButtonColor = System.Drawing.Color.LightSteelBlue;
         chartArea1.AxisY.ScrollBar.IsPositionedInside = false;
         chartArea1.Name = "ChartArea";
         this.chart.ChartAreas.Add(chartArea1);
         this.chart.ContextMenuStrip = this.contextMenuStrip;
         this.chart.Dock = System.Windows.Forms.DockStyle.Fill;
         legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
         legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Row;
         legend1.Name = "Legend1";
         this.chart.Legends.Add(legend1);
         this.chart.Location = new System.Drawing.Point(0, 0);
         this.chart.Name = "chart";
         this.chart.Size = new System.Drawing.Size(847, 412);
         this.chart.TabIndex = 1;
         this.chart.Text = "chart";
         this.chart.Click += new System.EventHandler(this.chart_Click);
         this.chart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chart_KeyPress);
         // 
         // contextMenuStrip
         // 
         this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
         this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreToolStripMenuItem,
            this.lessToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.xaxisToolStripMenuItem1});
         this.contextMenuStrip.Name = "contextMenuStrip";
         this.contextMenuStrip.Size = new System.Drawing.Size(128, 92);
         // 
         // moreToolStripMenuItem
         // 
         this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
         this.moreToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.moreToolStripMenuItem.Text = "More";
         this.moreToolStripMenuItem.Click += new System.EventHandler(this.MoreToolStripMenuItem_Click);
         // 
         // lessToolStripMenuItem
         // 
         this.lessToolStripMenuItem.Name = "lessToolStripMenuItem";
         this.lessToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.lessToolStripMenuItem.Text = "Less";
         this.lessToolStripMenuItem.Click += new System.EventHandler(this.LessToolStripMenuItem_Click);
         // 
         // propertiesToolStripMenuItem
         // 
         this.propertiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chartToolStripMenuItem,
            this.yaxisToolStripMenuItem,
            this.xaxisToolStripMenuItem});
         this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
         this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
         this.propertiesToolStripMenuItem.Text = "Properties";
         // 
         // chartToolStripMenuItem
         // 
         this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
         this.chartToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.chartToolStripMenuItem.Text = "Chart";
         this.chartToolStripMenuItem.Click += new System.EventHandler(this.ChartToolStripMenuItem_Click);
         // 
         // yaxisToolStripMenuItem
         // 
         this.yaxisToolStripMenuItem.Name = "yaxisToolStripMenuItem";
         this.yaxisToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.yaxisToolStripMenuItem.Text = "Yaxis";
         this.yaxisToolStripMenuItem.Click += new System.EventHandler(this.YaxisToolStripMenuItem_Click);
         // 
         // xaxisToolStripMenuItem
         // 
         this.xaxisToolStripMenuItem.Name = "xaxisToolStripMenuItem";
         this.xaxisToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
         this.xaxisToolStripMenuItem.Text = "Xaxis";
         this.xaxisToolStripMenuItem.Click += new System.EventHandler(this.XaxisToolStripMenuItem_Click);
         // 
         // xaxisToolStripMenuItem1
         // 
         this.xaxisToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuDele,
            this.toolStripMenuGange,
            this.toolStripMenuPluss,
            this.toolStripMenuMinus});
         this.xaxisToolStripMenuItem1.Name = "xaxisToolStripMenuItem1";
         this.xaxisToolStripMenuItem1.Size = new System.Drawing.Size(127, 22);
         this.xaxisToolStripMenuItem1.Text = "x-axis";
         // 
         // toolStripMenuDele
         // 
         this.toolStripMenuDele.Name = "toolStripMenuDele";
         this.toolStripMenuDele.Size = new System.Drawing.Size(82, 22);
         this.toolStripMenuDele.Text = "/";
         this.toolStripMenuDele.Click += new System.EventHandler(this.toolStripMenuDele_Click);
         // 
         // toolStripMenuGange
         // 
         this.toolStripMenuGange.Name = "toolStripMenuGange";
         this.toolStripMenuGange.Size = new System.Drawing.Size(82, 22);
         this.toolStripMenuGange.Text = "*";
         this.toolStripMenuGange.Click += new System.EventHandler(this.toolStripMenuGange_Click);
         // 
         // toolStripMenuPluss
         // 
         this.toolStripMenuPluss.Name = "toolStripMenuPluss";
         this.toolStripMenuPluss.Size = new System.Drawing.Size(82, 22);
         this.toolStripMenuPluss.Text = "+";
         this.toolStripMenuPluss.Click += new System.EventHandler(this.toolStripMenuPluss_Click);
         // 
         // toolStripMenuMinus
         // 
         this.toolStripMenuMinus.Name = "toolStripMenuMinus";
         this.toolStripMenuMinus.Size = new System.Drawing.Size(82, 22);
         this.toolStripMenuMinus.Text = "-";
         this.toolStripMenuMinus.Click += new System.EventHandler(this.toolStripMenuMinus_Click);
         // 
         // GraphControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.chart);
         this.Name = "GraphControl";
         this.Size = new System.Drawing.Size(847, 412);
         ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
         this.contextMenuStrip.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
      private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem lessToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem yaxisToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem xaxisToolStripMenuItem;
      public System.Windows.Forms.DataVisualization.Charting.Chart chart;
      private System.Windows.Forms.ToolStripMenuItem xaxisToolStripMenuItem1;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuDele;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuGange;
      private System.Windows.Forms.ToolStripMenuItem toolStripMenuPluss;
      public System.Windows.Forms.ToolStripMenuItem toolStripMenuMinus;
   }
}
