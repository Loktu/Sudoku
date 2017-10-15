using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Soduku
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
