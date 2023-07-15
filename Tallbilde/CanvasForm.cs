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

      private void restartToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Restart();
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

      private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Pause();
      }

      private void visHistorieToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.brett.history.VisResultater();
      }

      private void Clear_15x15ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Clear(15, 15);
         Invalidate();
      }
      private void Clear_20x20ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Clear(20, 20);
         Invalidate();
      }
      private void Clear_20x30ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Clear(30, 20);
         Invalidate();
      }
      private void Clear_25x35ToolStripMenuItem_Click(object sender, EventArgs e)
      {
         brettControl.Clear(35, 25);
         Invalidate();
      }

   }
}