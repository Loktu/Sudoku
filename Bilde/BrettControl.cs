using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Bilde
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
      public bool Tellevennlig { get; set; } = false;

      int currentRow = -1;
      int currentCol = -1;

      int mouseRow = -1;
      int mouseCol = -1;

      public BrettControl()
      {
         InitializeComponent();
         brett = new Brett(15, 10);
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
      }

      private void OnPaint(object sender, PaintEventArgs e)
      {
         Rectangle r = ClientRectangle;
         Graphics g = e.Graphics;
         Pen brettPen = new Pen(brettColor, 1);
         Pen thickPen = new Pen(brettColor, 3);

         Brush brush = Brushes.LightGray;

         int sizeX = r.Width;
         int sizeY = r.Height;

         int nl = brett.nLines;
         int nc = brett.nColumns;

         int ngk = Math.Max(brett.GruppeBredde(), 6);
         int ngl = Math.Max(brett.GruppeHoyde(), 6);

         int numberOfPositionsL = nl + ngl;
         int numberOfPositionsK = nc + ngk;

         int sizel = sizeY / numberOfPositionsL;
         int sizek = sizeX / numberOfPositionsK;

         size = Math.Min(sizel, sizek);

         xMin = 0;
         yMin = 0;

         xMax = xMin + numberOfPositionsK * size;
         yMax = yMin + numberOfPositionsL * size;

         x0 = xMin + ngk * size;
         y0 = yMin + ngl * size;

         if (mouseRow > -1 && mouseRow < nl)
         {
            g.FillRectangle(brush, xMin, y0 + size * mouseRow, ngk * size, size);
         }
         if (mouseCol > -1 && mouseCol < nc)
         {
            g.FillRectangle(brush, x0 + size * mouseCol, yMin, size, ngl * size);
         }

         if (currentRow > -1 && currentRow < nl)
         {
            g.FillRectangle(brush, xMin, y0 + size * currentRow, ngk * size, size);
         }
         if (currentCol > -1 && currentCol < nc)
         {
            g.FillRectangle(brush, x0 + size * currentCol, yMin, size, ngl * size);
         }

         int sum = 0;
         for (int row = 0; row < nl; ++row)
         {
            int y = y0 + size * row;
            for (int col = 0; col < nc; ++col)
            {
               int x1 = x0 + size * col;
               DrawValue(g, x1, y, size, brett[row, col]);
            }
            int x = x0 - size * brett.grupperPrLinje[row].Count;
            foreach (var gruppe in brett.grupperPrLinje[row])
            {
               DrawString(g, x, y, size, gruppe.ToString());
               x += size;
               sum += gruppe;
            }
         }
         for (int col = 0; col < nc; ++col)
         {
            int x = x0 + size * col;
            int y = y0 - size * brett.grupperPrKolonne[col].Count;
            foreach (var gruppe in brett.grupperPrKolonne[col])
            {
               DrawString(g, x, y, size, gruppe.ToString());
               y += size;
               sum -= gruppe;
            }
         }

         DrawString(g, x0 - size*2, y0 - size, size, sum.ToString());

         if (brett.HarFasit())
         {
            // Rød skrift så lenge den er under rekorden, grønn når timeren stopper, ellers svart
            Brush timebrush = (brett.SoFar <= brett.Record) ? Brushes.Red : timer.Enabled ? Brushes.Black: Brushes.Orange;
            DrawString(g, 0, 0, size, "0: " + brett.SoFar.ToString(), timebrush);

            int ir = 1;
            int n = brett.Results.Count;

            for (int i=n; i > 0; --i)
            {
               var tid = brett.Results[i - 1];
               timebrush = (tid.Value <= brett.Record) ? Brushes.Red : Brushes.Black;

               DrawString(g, 0, size * ir, size, i.ToString() + ": " + tid.Value.ToString(), timebrush);
               ir++;
               if (ir > 5) break;
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
         for (int row = 0; row < nl; row += 5)
         {
            int y = y0 + size * row;
            g.DrawLine(thickPen, xMin, y, xMax, y);
         }
         g.DrawLine(thickPen, xMin, yMax, xMax, yMax);

         g.DrawLine(thickPen, xMin, yMin, xMin, yMax);
         for (int col = 0; col < nc; col += 5)
         {
            int x = x0 + size * col;
            g.DrawLine(thickPen, x, yMin, x, yMax);
         }
         g.DrawLine(thickPen, xMax, yMin, xMax, yMax);
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
         if (Tellevennlig)
         {
            g.FillRectangle(brush, x + 1, y + 1, size - 2, size - 2);
            g.DrawRectangle(pen, x, y, size, size);
         }
         else
         {
            g.FillRectangle(brush, x, y, size, size);
         }
      }

      public void DrawString(Graphics g, int x0, int y0, int size, string number)
      {
         DrawString(g, x0, y0, size, number, Brushes.Black);
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

         currentRow = -1;
         currentCol = -1;

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
         else if (x > 0 && x < xMax)
         {
            currentCol = j;
         }
         else if (y > 0 && y < yMax)
         {
            currentRow = i;
         }

         Invalidate();
      }

      private void BrettControl_KeyPress(object sender, KeyPressEventArgs e)
      {
         if (e.KeyChar == '\r')
         {
            if (currentRow > -1)
            {
               ++currentRow;
               if (currentRow >= brett.grupperPrLinje.Count)
               {
                  currentRow = -1;
                  currentCol = 0;
               }
            }
            else if (currentCol > -1)
            {
               ++currentCol;
               if (currentCol >= brett.grupperPrKolonne.Count)
               {
                  currentCol = -1;
                  currentRow = 0;
               }
            }
         }
         if (currentRow > -1 && currentRow < brett.grupperPrLinje.Count)
         {
            brett.grupperPrLinje[currentRow].Add(e.KeyChar);
         }
         if (currentCol > -1 && currentCol < brett.grupperPrKolonne.Count)
         {
            brett.grupperPrKolonne[currentCol].Add(e.KeyChar);
         }
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

      public void Tell()
      {
         brett.Tell();
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
            Invalidate();
         }
      }
   }
}
