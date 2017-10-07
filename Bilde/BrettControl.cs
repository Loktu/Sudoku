using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace Bilde
{
   public partial class BrettControl : UserControl
   {
      public Brett brett;
      private Color brettColor = Color.Black;
      private Color safeColor = Color.Red;
      private Color tryColor = Color.Blue;

      int size = 10;
      int xMin = 0;
      int yMin = 0;
      int xMax = 300;
      int yMax = 300;

      Timer timer = new Timer();
      public bool Auto { get; set; }
      public bool Step { get; set; }
      public bool Hint { get; set; }

      public BrettControl()
      {
         Auto = false;
         Step = false;
         Hint = true;

         InitializeComponent();
         brett = new Brett(14);
         timer.Tick += new EventHandler(timer_Tick);
         timer.Interval = 10;
      }

      void timer_Tick(object sender, EventArgs e)
      {
         timer.Stop();
         timer.Interval = Math.Max(2, (int)(timer.Interval - 1));
         if (Auto)
         {
            if (brett.Step())
            {
               timer.Start();
            }
         }
         else if (Step)
         {
            brett.Step();
         }
         Invalidate();
      }

      public void Clear(int n)
      {
         brett.Clear(n);
         Invalidate();
      }
      public void SnuHint()
      {
         Hint = !Hint;
         Invalidate();
      }

      private void OnPaint(object sender, PaintEventArgs e)
      {
         Rectangle r = ClientRectangle;
         Graphics g = e.Graphics;
         Pen brettPen = new Pen(brettColor, 1);
         Pen thickPen = new Pen(brettColor, 3);

         int sizeX = r.Width;
         int sizeY = r.Height;

         int N = brett.size;

         xMin = 1;
         yMin = 1;

         if (sizeX > sizeY)
            xMin = (sizeX - sizeY) / 2;
         else if (sizeY > sizeX)
            yMin = (sizeY - sizeX) / 2;


         size = Math.Min(sizeX / N, sizeY / N);

         xMax = xMin + N * size;
         yMax = yMin + N * size;

         for (int row = 0; row < N; ++row)
         {
            int y = yMin + size * row;
            for (int col = 0; col < N; ++col)
            {
               int x = xMin + size * col;
               DrawValue(g, x, y, size, brett[col, row]);
            }
         }

         for (int row = 0; row <= N; ++row)
         {
            int y = yMin + size * row;
            g.DrawLine(brettPen, xMin, y, xMax, y);
         }
         for (int col = 0; col <= N; ++col)
         {
            int x = xMin + size * col;
            g.DrawLine(brettPen, x, yMin, x, yMax);
         }
         for (int row = 0; row <= N; row += N)
         {
            int y = yMin + size * row;
            g.DrawLine(thickPen, xMin, y, xMax, y);
         }
         for (int col = 0; col <= N; col += N)
         {
            int x = xMin + size * col;
            g.DrawLine(thickPen, x, yMin, x, yMax);
         }

      }

      public void DrawValue(Graphics g, int x, int y, int size, Brett.Plass plass)
      {
         Brush brush = Brushes.LightGray;
         if (plass.verdi < 0)
            brush = Brushes.Black;
         if (plass.verdi > 0)
            brush = Brushes.White;
         g.FillRectangle(brush, x, y, size, size);
      }

      private void OnMouseClick(object sender, MouseEventArgs e)
      {
         timer.Stop();
         timer.Interval = 100;

         int x0 = (e.X - xMin);
         int y0 = (e.Y - yMin);

         int i = x0 / size;
         int j = y0 / size;

         Brett.Plass plass = brett[i, j];
         if (plass == null) return;

         if (e.Button == MouseButtons.Left)
         {
            plass.SetVerdi(-1);
         }
         else if (e.Button == MouseButtons.Right)
         {
            plass.SetVerdi(1);
         }
         Invalidate();
         timer.Start();
      }

      private void BrettControl_KeyDown(object sender, KeyEventArgs e)
      {
         timer.Stop();
         timer.Interval = 100;

         int x0 = (mouseX - xMin);
         int y0 = (mouseY - yMin);

         int i = x0 / size;
         int j = y0 / size;

         if (i < 0) return;
         if (j < 0) return;
         if (i >= brett.size) return;
         if (j >= brett.size) return;

         var k = e.KeyData;
         if (k.ToString().ToUpper() == "X")
            brett[i, j].SetVerdi(-1);
         if (k.ToString().ToUpper() == "O")
            brett[i, j].SetVerdi(1);
         Invalidate();
         timer.Start();
      }

      int mouseX = 0;
      int mouseY = 0;

      private void BrettControl_MouseMove(object sender, MouseEventArgs e)
      {
         mouseX = e.X;
         mouseY = e.Y;
      }

      public void Save(string fileName)
      {
         using (var streamWriter = new StreamWriter(fileName))
         {
            try
            {
               brett.ListeFromArray();
               XmlSerializer serializer = new XmlSerializer(typeof(Brett));
               serializer.Serialize(streamWriter, brett);
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: Could not write file to disk. Original error: " + ex.Message);
            }
            streamWriter.Close();
         }
      }


      public void Read(string fileName)
      {
         using (var reader = new StreamReader(fileName))
         {
            try
            {
               XmlSerializer serializer = new XmlSerializer(typeof(Brett));
               brett = (Brett)serializer.Deserialize(reader);
               brett.ArrayFromListe();
               Invalidate();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
         }
      }

   }
}
