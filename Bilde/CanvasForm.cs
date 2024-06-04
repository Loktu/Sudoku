using System;
using System.IO;
using System.Windows.Forms;

namespace Tallbilde
{
   public partial class canvasForm : Form
   {
      string fileName;
      public canvasForm()
      {
         InitializeComponent();
      }

      private void OnResize(object sender, EventArgs e)
      {
         Invalidate(true);
      }

      private void OnAbout(object sender, EventArgs e)
      {
         var aboutBox = new AboutBox();
         aboutBox.Show();
      }

      private void stepToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Step();
         brettControl.Invalidate();
      }

      private void loadMenu_Click(object sender, EventArgs e)
      {
         var openFileDialog = new OpenFileDialog();
         if (string.IsNullOrEmpty(fileName))
         {
            openFileDialog.InitialDirectory = Application.UserAppDataPath + "\\" + Application.ProductName + "\\";
         }
         else
         {
            openFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
         }
         openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";

         if (openFileDialog.ShowDialog() == DialogResult.OK)
         {
            fileName = openFileDialog.FileName;
            brettControl.Read(fileName);
            this.Text = "Bilde: " + fileName;
         }
      }

      private void skrivFilMenu_Click(object sender, EventArgs e)
      {
         if (!string.IsNullOrEmpty(fileName))
         {
            brettControl.Save(fileName);
         }
         else
         {
            skrivSomMenu_Click(sender, e);
         }

      }

      private void skrivSomMenu_Click(object sender, EventArgs e)
      {
         var saveFileDialog = new SaveFileDialog();
         if (string.IsNullOrEmpty(fileName))
         {
            saveFileDialog.InitialDirectory = Application.UserAppDataPath + "\\" + Application.ProductName + "\\";
         }
         else
         {
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(fileName);
         }
         saveFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
         saveFileDialog.FileName = fileName;

         if (saveFileDialog.ShowDialog() == DialogResult.OK)
         {
            fileName = saveFileDialog.FileName;
            brettControl.Save(saveFileDialog.FileName);
            this.Text = "Bilde: " + fileName;
         }
      }

      private void Clear_3x3_Click(object sender, EventArgs e)
      {
         brettControl.Clear(15, 15);
         Invalidate();
      }

      private void Clear_3x4_Click(object sender, EventArgs e)
      {
         brettControl.Clear(20, 15);
         Invalidate();

      }

      private void Clear_4x3_Click(object sender, EventArgs e)
      {
         brettControl.Clear(15, 20);
         Invalidate();

      }

      private void Clear_4x4_Click(object sender, EventArgs e)
      {

         brettControl.Clear(20, 20);
         Invalidate();
      }

      private void Clear_5x7_Click(object sender, EventArgs e)
      {
         brettControl.Clear(35, 25);
         Invalidate();
      }

      private void restartToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Restart();
      }

      private void OnTellevennlig(object sender, EventArgs e)
      {
         brettControl.Tellevennlig = !brettControl.Tellevennlig;
         Invalidate();
      }

      private void setFasitToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.brett.SetFasit();
      }

      private void checkToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.brett.CheckFasit();
         brettControl.Invalidate();
      }

      private void tellToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Tell();
         brettControl.Invalidate();
      }

      private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Pause();
      }

      private void visHistorieToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.brett.history.VisResultater();
      }

      private void brettControl_KeyDown(object sender, KeyEventArgs e)
      {
         if (e.KeyCode == Keys.S)
         { 
            brettControl.Step();
         }
      }
   }
}