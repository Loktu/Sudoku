using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Bilde
{
   public partial class GraphControl : UserControl
   {
      public GraphControl()
      {
         InitializeComponent();
      }

      private void MoreToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var axis = this.chart.ChartAreas[0].AxisY;
         var value = axis.Interval;
         if (value == 0.0)
            value = 20000;
         axis.Interval = value * 0.5;
      }

      private void LessToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var axis = this.chart.ChartAreas[0].AxisY;
         var value = axis.Interval;
         if (value == 0.0)
            value = 20000;
         axis.Interval = value * 2.0;
      }

      private void ChartToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var propertyForm = new PropertyForm() { SelectedObject = this.chart };
         propertyForm.ShowDialog(this);
      }

      private void YaxisToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var propertyForm = new PropertyForm() { SelectedObject = this.chart.ChartAreas[0].AxisY };
         propertyForm.PropertyGrid.Validated += PropertyGrid_Validated;
         propertyForm.ShowDialog(this);
      }

      private void PropertyGrid_Validated(object sender, EventArgs e)
      {
         SynkroniserYaksene();
      }

      private void XaxisToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var propertyForm = new PropertyForm() { SelectedObject = this.chart.ChartAreas[0].AxisX };
         propertyForm.ShowDialog(this);
      }

      public void SynkroniserYaksene()
      {
         SkalerYaksen();

         var yaxis1 = chart.ChartAreas[0].AxisY;
         var yaxis2 = chart.ChartAreas[0].AxisY2;

         // Juster høyre y-akse
         yaxis2.Minimum = yaxis1.Minimum;
         yaxis2.Maximum = yaxis1.Maximum;
         yaxis2.Interval = yaxis1.Interval;
         yaxis2.Enabled = AxisEnabled.True;
      }

      public void SkalerYaksen()
      {
         // Find min and max values
         var min = double.MaxValue;
         var max = double.MinValue;
         foreach (var serie in chart.Series)
         {
            foreach (var point in serie.Points)
            {
               foreach (var yvalue in point.YValues)
               {
                  if (yvalue > max) max = yvalue;
                  if (yvalue < min) min = yvalue;
               }
            }
         }
         SkalerYaksen(min, max);
      }

      public void SkalerYaksen(double min, double max)
      {
         // Calculate interval:
         double interval = CalculateInterval(min, max);

         var yaxis1 = chart.ChartAreas[0].AxisY;

         yaxis1.Interval = interval;

         if (yaxis1.Interval != 0.0)
         {
            yaxis1.Maximum = Math.Ceiling(max / interval) * interval;
            yaxis1.Minimum = Math.Floor(min / interval) * interval;
         }

         chart.ChartAreas[0].RecalculateAxesScale();
      }

      readonly double[] ibase = { 1.0, 1.0, 1.0, 1.0, 5.0, 5.0, 5.0, 10.0, 10.0, 10.0, 10.0 };

      private double CalculateInterval(double min, double max)
      {
         double diff = max - min;
         if (diff < 10E-6)
            diff = 1.0;

         double log10 = Math.Log10(diff);
         int pow = (int)log10;
         double m = Math.Pow(10, pow);
         int rest = Convert.ToInt32((log10 - pow) * 10);
         double interval = ibase[Math.Abs(rest)] * Math.Pow(10, pow - 1);
         return interval;
      }

      private void toolStripMenuDele_Click(object sender, EventArgs e)
      {
         ChartDele();
      }

      private void toolStripMenuGange_Click(object sender, EventArgs e)
      {
         ChartGange();
      }

      private void toolStripMenuPluss_Click(object sender, EventArgs e)
      {
         ChartPluss();
      }

      private void toolStripMenuMinus_Click(object sender, EventArgs e)
      {
         ChartMinus();
      }

      private void chart_KeyPress(object sender, KeyPressEventArgs e)
      {
         switch (e.KeyChar)
         {
            case '/' :
               ChartDele();
               break;
            case '*' :
               ChartGange();
               break;
            case '+' :
               ChartPluss();
               break;
            case '-' :
               ChartMinus();
               break;
         }
      }

      private void ChartDele()
      {
         var axis = this.chart.ChartAreas[0].AxisX;
         var value1 = axis.Minimum;
         var value2 = axis.Maximum;
         axis.Maximum -= (value2 - value1) * 0.5;
      }

      private void ChartGange()
      {
         var axis = this.chart.ChartAreas[0].AxisX;
         var value1 = axis.Minimum;
         var value2 = axis.Maximum;
         axis.Maximum += (value2 - value1);
      }

      private void ChartPluss()
      {
         var axis = this.chart.ChartAreas[0].AxisX;
         var value1 = axis.Minimum;
         var value2 = axis.Maximum;
         axis.Minimum += (value2 - value1) * 0.5;
         axis.Maximum += (value2 - value1) * 0.5;
      }

      private void ChartMinus()
      {
         var axis = this.chart.ChartAreas[0].AxisX;
         var value1 = axis.Minimum;
         var value2 = axis.Maximum;
         axis.Minimum -= (value2 - value1) * 0.5;
         axis.Maximum -= (value2 - value1) * 0.5;
      }

      private void chart_Click(object sender, EventArgs e)
      {

      }
   }
}
