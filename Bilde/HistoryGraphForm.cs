using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bilde
{
   public partial class HistoryGraphForm : Form
   {
      List<KeyValuePair<DateTime, TimeSpan>> history;
      public HistoryGraphForm(List<KeyValuePair<DateTime, TimeSpan>> results)
      {
         history = new List<KeyValuePair<DateTime, TimeSpan>>();

         foreach (var item in results)
         {
            history.Add(item);
         }
         history.Sort((x, y) => x.Key.CompareTo(y.Key));
         InitializeComponent();
      }

      private void graphControl_VisibleChanged(object sender, EventArgs e)
      {
         Redraw();
      }

      private void Redraw()
      {
         graphControl.chart.Series.Clear();

         var serie0 = new Series("Historie")
         {
            ChartType = SeriesChartType.Line,
            Color = Color.Green,
            BorderWidth = 2
         };

         // Add data points to the series
         foreach (var kvp in history)
         {
            // Convert TimeSpan to total seconds for Y value
            double totalSeconds = kvp.Value.TotalSeconds;
            double y = kvp.Value.TotalMinutes;
            serie0.Points.AddXY(kvp.Key, y);
         }
         serie0.ToolTip = "#SERIESNAME\n#VALX{dd.MMM}\n#VAL{N}";
         graphControl.chart.Series.Add(serie0);

         graphControl.SynkroniserYaksene();

      }
   }
}
