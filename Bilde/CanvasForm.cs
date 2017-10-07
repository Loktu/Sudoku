using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Bilde
{
   public partial class canvasForm : Form
   {
      string fileName;
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
         }
      }

   }
}