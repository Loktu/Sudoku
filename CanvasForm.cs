using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class canvasForm : Form
    {
        public canvasForm()
        {
            InitializeComponent();

            brettControl.Auto = this.autoSettingsToolStripMenuItem.Checked;
            brettControl.Auto1 = this.auto1ToolStripMenuItem.Checked;
            brettControl.Auto2 = this.auto2ToolStripMenuItem.Checked;
            brettControl.Auto3 = this.auto3ToolStripMenuItem.Checked;
        }

       private void OnResize(object sender, EventArgs e)
       {
            Invalidate(true);
       }

        private void OnDiagonal(object sender, EventArgs e)
        {
            brettControl.Diagonal();
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

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //brettControl.Load(fd.FileName);
            }
        }

        private void skrivFilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fd = new SaveFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                //brettControl.Save(fd.FileName);
            }
        }

        private void auto1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Auto1 = this.auto1ToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

        private void auto2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Auto2 = this.auto2ToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

        private void auto3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Auto3 = this.auto3ToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

        private void irregulærToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var endreForm = new EndreForm(brettControl.brett);
            if (endreForm.ShowDialog() == DialogResult.OK)
            {
                brettControl.brett = endreForm.endreControl.brett;
                brettControl.Clear();
            }
            brettControl.Invalidate();
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Clear();
        }

        private void stepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            brettControl.Step = this.stepToolStripMenuItem.Checked;
            brettControl.Invalidate();
        }

    }
}