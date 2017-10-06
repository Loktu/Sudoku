using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bilde
{
    public partial class canvasForm : Form
    {
        public canvasForm()
        {
            InitializeComponent();

            brettControl.Auto = this.autoSettingsToolStripMenuItem.Checked;
        }

       private void OnResize(object sender, EventArgs e)
       {
            Invalidate(true);
       }
        private void OnAuto(object sender, EventArgs e)
        {
            brettControl.Auto = this.autoSettingsToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

        private void OnHint(object sender, EventArgs e)
        {
            brettControl.SnuHint();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox();
            aboutBox.Show();
        }
        private void clear14ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Clear(14);
            Invalidate();
        }
        private void clear10ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Clear(10);
            Invalidate();
        }


        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Step = this.stepToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

    }
}