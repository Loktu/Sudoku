using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
   public partial class EndreControl : UserControl
   {
      public Brett brett;
      private Color brettColor = Color.Black;

      public EndreForm owner;

      int size = 10;
      int xMin = 0;
      int yMin = 0;
      int xMax = 300;
      int yMax = 300;

      public EndreControl()
      {
         InitializeComponent();
         brett = new Brett();
         foreach (Brett.Plass plass in brett.brett)
         {
            plass.k = 9;
         }
      }

      private void OnPaint(object sender, PaintEventArgs e)
      {
         Rectangle r = ClientRectangle;
         Graphics g = e.Graphics;
         Pen brettPen = new Pen(brettColor, 1);
         Pen thickPen = new Pen(brettColor, 3);

         int sizeX = r.Width;
         int sizeY = r.Height - 5;

         xMin = 1;
         yMin = 1;

         if (sizeX > sizeY)
            xMin = (sizeX - sizeY) / 2;
         else if (sizeY > sizeX)
            yMin = (sizeY - sizeX) / 2;


         size = Math.Min(sizeX / 9, sizeY / 9);

         xMax = xMin + 9 * size;
         yMax = yMin + 9 * size;

         for (int row = 0; row <= 9; ++row)
         {
            int y = yMin + size * row;
            g.DrawLine(brettPen, xMin, y, xMax, y);
         }
         for (int col = 0; col <= 9; ++col)
         {
            int x = xMin + size * col;
            g.DrawLine(brettPen, x, yMin, x, yMax);
         }

         for (int row = 0; row <= 9; row += 9)
         {
            int y = yMin + size * row;
            g.DrawLine(thickPen, xMin, y, xMax, y);
         }
         for (int col = 0; col <= 9; col += 9)
         {
            int x = xMin + size * col;
            g.DrawLine(thickPen, x, yMin, x, yMax);
         }

         for (int row = 0; row < 9; ++row)
         {
            int y = yMin + size * row;
            for (int col = 0; col < 9; ++col)
            {
               int x = xMin + size * col;
               DrawValue(g, x, y, size, brett[col, row]);

               if (row < 8)
               {
                  if (brett[col, row].k != brett[col, row + 1].k)
                  {
                     int x1 = xMin + size * col;
                     int x2 = xMin + size * (col + 1);
                     int y0 = yMin + size * (row + 1);
                     g.DrawLine(thickPen, x1, y0, x2, y0);
                  }
               }

               if (col < 8)
               {
                  if (brett[col, row].k != brett[col + 1, row].k)
                  {
                     int x0 = xMin + size * (col + 1);
                     int y1 = yMin + size * (row);
                     int y2 = yMin + size * (row + 1);
                     g.DrawLine(thickPen, x0, y1, x0, y2);
                  }
               }

            }
         }

      }

      public void DrawValue(Graphics g, int x0, int y0, int size, Brett.Plass plass)
      {
         int x = x0 + size / 4;
         int y = y0 + size / 5;
         float fontsize = size / 2;
         if (fontsize > 3)
         {
            Font font = new Font(this.Font.Name, fontsize);
            Brush brush = Brushes.Black;
            g.DrawString(plass.k.ToString(), font, brush, x, y);
         }
      }

      private void BrettControl_KeyDown(object sender, KeyEventArgs e)
      {
         int value = e.KeyValue - 48;
         if (value < 0 || value > 9) value = e.KeyValue - 96;  //numpad
         if (value < 0 || value > 9) return;

         int x0 = (mouseX - xMin);
         int y0 = (mouseY - yMin);

         int i = x0 / size;
         int j = y0 / size;

         Brett.Plass plass = brett[i, j];
         if (plass == null) return;

         plass.k = value;

         owner.buttonOK.Enabled = SjekkKombinasjoner();
         Invalidate();

      }

      int mouseX = 0;
      int mouseY = 0;

      private void BrettControl_MouseMove(object sender, MouseEventArgs e)
      {
         mouseX = e.X;
         mouseY = e.Y;
      }

      public void SetKombinasjoner()
      {
         Brett.Kombinasjon kombinasjon;
         for (int k = 0; k < 9; ++k)
         {
            kombinasjon = brett.kombinasjoner[k + 18];
            foreach (Brett.Plass plass in brett.brett)
            {
               kombinasjon.Plasser.Remove(plass);
               plass.kombinasjoner.Remove(kombinasjon);
            }
         }

         for (int k = 0; k < 9; ++k)
         {
            kombinasjon = brett.kombinasjoner[k + 18];
            foreach (Brett.Plass plass in brett.brett)
            {
               if (plass.k == k + 1)
               {
                  kombinasjon.Add(plass);
                  plass.kombinasjoner.Add(kombinasjon);
               }
            }
         }
      }

      public bool SjekkKombinasjoner()
      {
         int[] n = new int[9];
         for (int k = 0; k < 9; ++k)
         {
            n[k] = 0;
         }
         foreach (Brett.Plass plass in brett.brett)
         {
            if (plass.k > 0)
            {
               n[plass.k - 1]++;
            }
         }
         for (int k = 0; k < 9; ++k)
         {
            if (n[k] != 9) return false;
         }
         return true;
      }
   }
}
