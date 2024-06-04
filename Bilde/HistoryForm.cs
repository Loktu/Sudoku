using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilde
{
   public partial class HistoryForm : Form
   {
      public HistoryForm(List<KeyValuePair<DateTime, TimeSpan>> results)
      {
         InitializeComponent();

         dataGridView.Rows.Clear();
         int i = 0;
         foreach (var item in results)
         {
            int iRow = dataGridView.Rows.Add();
            DataGridViewRow row = dataGridView.Rows[iRow];
            ++i;
            row.Cells["Object"].Value = item;
            row.Cells["Nr"].Value = i.ToString();
            row.Cells["Dato"].Value = item.Key.ToString();
            row.Cells["Tid"].Value = item.Value.ToString();
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
            results.Add((KeyValuePair < DateTime, TimeSpan > )row.Cells["Object"].Value);
         }
         return results;
      }

   }
}
