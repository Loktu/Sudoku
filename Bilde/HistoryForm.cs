using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Bilde
{
   public partial class HistoryForm : Form
   {
      public HistoryForm(List<KeyValuePair<DateTime, TimeSpan>> results)
      {
         InitializeComponent();

         dataGridView.Rows.Clear();

         this.dataGridView.Columns["Dato"].DefaultCellStyle.Format = "d";

         int i = 0;
         foreach (var item in results)
         {
            int iRow = dataGridView.Rows.Add();
            DataGridViewRow row = dataGridView.Rows[iRow];
            ++i;
            row.Cells["Nr"].Value = i;
            row.Cells["Dato"].Value = item.Key;
            row.Cells["Tid"].Value = item.Value;
         }
       
      }
      private void OkButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }

      public List<KeyValuePair<DateTime, TimeSpan>> GetResults()
      {
         List<KeyValuePair<DateTime, TimeSpan>> results = new List<KeyValuePair<DateTime, TimeSpan>>();
         foreach (DataGridViewRow row in dataGridView.Rows)
         {
            results.Add(new KeyValuePair<DateTime, TimeSpan>((DateTime)row.Cells["Dato"].Value, (TimeSpan)row.Cells["Tid"].Value));
         }
         return results;
      }

   }
}
