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
      int x0 = 0;
      int y0 = 0;
      int xMin = 10;
      int yMin = 10;
      int xMax = 300;
      int yMax = 300;

      Timer timer = new Timer();
      public bool Auto { get; set; }
      public bool Hint { get; set; }

      public BrettControl()
      {
         Auto = false;
         Hint = true;

         InitializeComponent();
         brett = new Brett(15,10);
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
         Invalidate();
      }

      public void Clear(int n, int m)
      {
         brett.Clear(n,m);
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

         int nl = brett.nLines;
         int nc = brett.nColumns;

         int ngk = brett.GruppeBredde();
         int ngl = brett.GruppeHoyde();

         int numberOfPositionsL = nl + ngl;
         int numberOfPositionsK = nc + ngk;

         int sizel = sizeY / numberOfPositionsL;
         int sizek = sizeX / numberOfPositionsK;

         size = Math.Min(sizel, sizek);

         xMin = 0; //sizeX - (sizek * numberOfPositionsK) / 2;
         yMin = 0; //sizeY - (sizel * numberOfPositionsL) / 2;

         xMax = xMin + numberOfPositionsK * size;
         yMax = yMin + numberOfPositionsL * size;

         x0 = xMin + ngk * size;
         y0 = yMin + ngl * size;

         for (int row = 0; row < nl; ++row)
         {
            int y = y0 + size * row;
            for (int col = 0; col < nc; ++col)
            {
               int x1 = x0 + size * col;
               DrawValue(g, x1, y, size, brett[row, col]);
            }
            int x = xMin;
            foreach (var gruppe in brett.grupperPrLinje[row])
            {
               DrawString(g, x, y, size, gruppe.ToString());
               x += size;
            }
         }
         for (int col = 0; col < nc; ++col)
         {
            int x = x0 + size * col;
            int y = yMin;
            foreach (var gruppe in brett.grupperPrKolonne[col])
            {
               DrawString(g, x, y, size, gruppe.ToString());
               y += size;
            }
         }

         for (int row = 0; row <= nl; ++row)
         {
            int y = y0 + size * row;
            g.DrawLine(brettPen, xMin, y, xMax, y);
         }
         for (int col = 0; col <= nc; ++col)
         {
            int x = x0 + size * col;
            g.DrawLine(brettPen, x, yMin, x, yMax);
         }

         g.DrawLine(thickPen, xMin, yMin, xMax, yMin);
         for (int row = 0; row < nl; row+=5)
         {
            int y = y0 + size * row;
            g.DrawLine(thickPen, xMin, y, xMax, y);
         }
         g.DrawLine(thickPen, xMin, yMax, xMax, yMax);

         g.DrawLine(thickPen, xMin, yMin, xMin, yMax);
         for (int col = 0; col < nc; col+=5)
         {
            int x = x0 + size * col;
            g.DrawLine(thickPen, x, yMin, x, yMax);
         }
         g.DrawLine(thickPen, xMax, yMin, xMax, yMax);
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

      public void DrawString(Graphics g, int x0, int y0, int size, string number)
      {
         int x = x0 + 1;
         int y = y0 + 1;
         float fontsize = size / 2;
         if (fontsize > 3)
         {
            Font font = new Font(this.Font.Name, fontsize);
            Brush brush = Brushes.Black;
            g.DrawString(number, font, brush, x, y);
         }
      }

      private void OnMouseClick(object sender, MouseEventArgs e)
      {
         timer.Stop();
         timer.Interval = 100;

         int x = (e.X - x0);
         int y = (e.Y - y0);

         if (x > 0 && y >= 0)
         {
            int j = x / size;
            int i = y / size;

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
         }
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

      private void BrettControl_KeyPress(object sender, KeyPressEventArgs e)
      {
         timer.Stop();
         timer.Interval = 100;

         int x = (mouseX - x0);
         int y = (mouseY - y0);

         if (x < 0)
         {
            if (y > 0)
            {
               int i = (mouseY - y0) / size;
               if (i < brett.grupperPrLinje.Count)
               {
                  brett.grupperPrLinje[i].Add(e.KeyChar);
               }
            }
         }
         else if (y < 0)
         {
            int j = (mouseX - x0) / size;
            if (j < brett.grupperPrKolonne.Count)
            {
               brett.grupperPrKolonne[j].Add(e.KeyChar);
            }
         }
         Invalidate();
         timer.Start();
      }
      public void Restart()
      {
         brett.Restart();
         Invalidate();
      }

      public void Step()
      {
         brett.Step();
         Invalidate();
      }


   }
}
