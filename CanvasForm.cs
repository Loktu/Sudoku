using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Sudoku
{
   public partial class canvasForm : Form
   {
      Process proc;
      public canvasForm()
      {
         InitializeComponent();

         brettControl.Auto = this.autoSettingsToolStripMenuItem.Checked;
         brettControl.Auto1 = this.auto1ToolStripMenuItem.Checked;
         brettControl.Auto2 = this.auto2ToolStripMenuItem.Checked;
         brettControl.Auto3 = this.auto3ToolStripMenuItem.Checked;

         // get this running process
         proc = Process.GetCurrentProcess();
         //get all other (possible) running instances
         Process[] processes = Process.GetProcessesByName(proc.ProcessName);
         brettControl.ServerKanal = processes.Length;
         this.Text = proc.ProcessName + " - " + brettControl.ServerKanal;
         brettControl.StartServer();
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

      private void LoadToolStripMenuItem1_Click(object sender, EventArgs e)
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

      private void irregul�rToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.brett.Clear();
         var endreForm = new EndreForm(brettControl.brett);
         if (endreForm.ShowDialog() == DialogResult.OK)
         {
            brettControl.brett = endreForm.endreControl.brett;
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

      private void connectionsToolStripMenuItem_Click(object sender, EventArgs e)
      {
         var connectForm = new ConnectForm(brettControl.ServerKanal, brettControl.connections);
         if (connectForm.ShowDialog() == DialogResult.OK)
         {
            brettControl.ServerKanal = connectForm.GetServerKanal();
            brettControl.connections = connectForm.GetConnections();
            this.Text = proc.ProcessName + " - " + brettControl.ServerKanal;
            brettControl.StartClients();
            brettControl.Connect();
         }
      }

      private void sendToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Connect();
         brettControl.Send();
      }
   }
}