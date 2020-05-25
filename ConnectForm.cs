using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Soduko2013
{
   public partial class ConnectForm : Form
   {
      public ConnectForm(int kanal, List<Tuple<int, int, int>> connections)
      {
         InitializeComponent();
         serverKanal.Text = kanal.ToString();
         dataGridView.Rows.Clear();
         foreach (var item in connections)
         {
            int iRow = dataGridView.Rows.Add();
            DataGridViewRow row = dataGridView.Rows[iRow];
            row.Cells["Kanal"].Value = item.Item1.ToString();
            row.Cells["Fra"].Value = item.Item2.ToString();
            row.Cells["Til"].Value = item.Item3.ToString();
         }
      }

      private void OkButton_Click(object sender, EventArgs e)
      {
         this.DialogResult = DialogResult.OK;
         this.Close();
      }


      public int GetServerKanal()
      {
         if (Int32.TryParse((string)serverKanal.Text, out int kanal))
         {
            return kanal;
         }
         return 0;
      }

      public List<Tuple<int, int, int>> GetConnections()
      {
         List<Tuple<int, int, int>> connections = new List<Tuple<int, int, int>>();
         foreach (DataGridViewRow row in dataGridView.Rows)
         {
            if (
                Int32.TryParse((string)row.Cells["Kanal"].Value, out int kanal) &&
                Int32.TryParse((string)row.Cells["Fra"].Value, out int fra) &&
                Int32.TryParse((string)row.Cells["Til"].Value, out int til)
                )
            {
               connections.Add(Tuple.Create(kanal, fra, til));
            }
         }
         return connections;
      }
   }
}
