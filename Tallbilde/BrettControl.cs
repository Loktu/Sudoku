using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Tallbilde
{
   public partial class BrettControl : UserControl
   {
      private string fileName;
      public Brett brett;
      private readonly Color brettColor = Color.Black;

      int size = 10;
      int x0 = 0;
      int y0 = 0;
      int xMin = 10;
      int yMin = 10;
      int xMax = 300;
      int yMax = 300;
      readonly Timer timer = new Timer();

      int currentRow = 0;
      int currentCol = 0;

      int mouseRow = -1;
      int mouseCol = -1;

      public BrettControl()
      {
         InitializeComponent();
         brett = new Brett(15, 15);
         timer.Tick += new EventHandler(Timer_Tick);
         timer.Interval = 1000;
      }

      void Timer_Tick(object sender, EventArgs e)
      {
         timer.Stop();
         TimeSpan interval = new TimeSpan(0, 0, 0, 0, timer.Interval);
         brett.SoFar += interval;
         timer.Start();
         Invalidate();
      }

      public void Clear(int n, int m)
      {
         timer.Stop();
         brett.SoFar = TimeSpan.Zero;
         fileName = null;
         brett.Clear(n, m);
         Invalidate();
         currentRow = 0;
         currentCol = 0;
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

         int sizel = sizeY / nl;
         int sizek = sizeX / nc;

         size = Math.Min(sizel, sizek);

         xMin = 0;
         yMin = 0;

         xMax = xMin + nc * size;
         yMax = yMin + nl * size;

         x0 = xMin;
         y0 = yMin;

         for (int row = 0; row < nl; ++row)
         {
            int y = y0 + size * row;
            for (int col = 0; col < nc; ++col)
            {
               int x1 = x0 + size * col;
               DrawValue(g, x1, y, size, brett[row, col]);
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
         g.DrawLine(thickPen, xMin, yMax, xMax, yMax);
         g.DrawLine(thickPen, xMin, yMin, xMin, yMax);
         g.DrawLine(thickPen, xMax, yMin, xMax, yMax);

         Brush brush;
         foreach (var item in brett.tallListe.talliste)
         {
            if (brett[item.row, item.col].Verdi == Verdi.Sort)
            {
               brush = Brushes.White;
            }
            else
            {
               brush = Brushes.Black;
            }
            int x = x0 + size * item.col;
            int y = y0 + size * item.row;
            DrawString(g, x, y, size, item.tall.ToString(), brush);
         }
         int xc = x0 + size * currentCol;
         int yc = y0 + size * currentRow;
         g.DrawRectangle(thickPen, xc, yc, size, size);
      }

      internal void Pause()
      {
         timer.Enabled = false;
      }

      public void DrawValue(Graphics g, int x, int y, int size, Plass plass)
      {
         Brush brush = Brushes.Gray;
         Pen pen = Pens.Black;
         if (plass.Verdi == Verdi.Sort)
         {
            brush = Brushes.Black;
            pen = Pens.White;
         }
         if (plass.Verdi == Verdi.Hvit)
         {
            brush = Brushes.White;
         }
         g.FillRectangle(brush, x, y, size, size);
      }
      
      public void DrawString(Graphics g, int x0, int y0, int size, string number, Brush brush)
      {
         int x = x0 + 1;
         int y = y0 + 1;
         float fontsize = size / 2;
         if (fontsize > 3)
         {
            Font font = new Font(this.Font.Name, fontsize);
            g.DrawString(number, font, brush, x, y);
         }
      }

      private void OnMouseClick(object sender, MouseEventArgs e)
      {
         if (!timer.Enabled)
            timer.Enabled = true;
         int x = (e.X - x0);
         int y = (e.Y - y0);

         int j = x / size;
         int i = y / size;

         currentRow = i;
         currentCol = j;

         if (x > 0 && y >= 0)
         {
            Plass plass = brett[i, j];
            if (plass == null) return;

            if (e.Button == MouseButtons.Left)
            {
               plass.SetVerdi(Verdi.Sort);
            }
            else if (e.Button == MouseButtons.Right)
            {
               plass.SetVerdi(Verdi.Hvit);
            }
            SjekkRekord();
         }

         Invalidate();
      }

      private void BrettControl_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == ' ' || e.KeyChar == '+')
         {
            brett.ClearValue(currentRow, currentCol);
         }
         else if (e.KeyChar >= '0' && e.KeyChar <= '9')
         {
            brett.AddValue(e.KeyChar - 48, currentRow, currentCol);
         }
         ++currentCol;
         if (currentCol >= brett.nColumns)
         {
            currentCol = 0;
            ++currentRow;
            if (currentRow >= brett.nLines)
               currentRow=0;
         }
         Step();
         Invalidate();
      }

      public void Save(string fileName)
      {
         using (var streamWriter = new StreamWriter(fileName))
         {
            try
            {
               brett.ForberedXml();
               XmlSerializer serializer = new XmlSerializer(typeof(Brett));
               serializer.Serialize(streamWriter, brett);
               this.fileName = fileName;
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
               brett.EtterXml();
               this.fileName = fileName;
               Invalidate();
               if (!brett.Ferdig())
                  timer.Start();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
         }
      }

      public void Restart()
      {
         brett.Restart();
         Invalidate();

         if (brett.HarFasit())
            timer.Start();
      }

      public void Step()
      {
         if (brett.Ferdig())
            return;

         if (!timer.Enabled)
            timer.Enabled = true;

         brett.Step();
         brett.SoFar += new TimeSpan(0, 0, 0, 0, timer.Interval);
         SjekkRekord();
         Invalidate();
      }

      private void SjekkRekord()
      {
         if (timer.Enabled)
         {
            if (brett.Ferdig())
            {
               timer.Stop();
               brett.SetRecord();
               if (!string.IsNullOrEmpty(fileName))
               {
                  Save(fileName);
               }
            }
         }
      }

      private void OnMouseMove(object sender, MouseEventArgs e)
      {
         int x = (e.X - x0);
         int y = (e.Y - y0);
         int j = x / size;
         int i = y / size;
         if (i != mouseRow || j != mouseCol)
         {
            mouseRow = i;
            mouseCol = j;
            currentRow = i;
            currentCol = j;
            Invalidate();
         }
      }
   }
}
