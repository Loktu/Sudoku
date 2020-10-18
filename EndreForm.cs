using System;
using System.Windows.Forms;

namespace Sudoku
{
   public partial class EndreForm : Form
   {
      public EndreForm(Brett brett)
      {
         InitializeComponent();
         endreControl.brett = brett;
         endreControl.owner = this;
      }

      private void buttonOK_Click(object sender, EventArgs e)
      {
         endreControl.SetKombinasjoner();
         this.DialogResult = DialogResult.OK;
      }
   }
}
