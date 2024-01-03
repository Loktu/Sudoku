using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TcpConnection;

namespace Sudoku
{
   public partial class BrettControl : UserControl
   {
      public Brett brett;
      private readonly Color brettColor = Color.Black;

      int size = 10;
      int xMin = 0;
      int yMin = 0;
      int xMax = 300;
      int yMax = 300;

      public int serverKanal = 0;
      public List<Tuple<int, int, int>> connections = new List<Tuple<int, int, int>>();

      public TcpClass server;
      public Dictionary<int, Tuple<TcpClass, List<Tuple<int, int>>>> clients;

      readonly Timer timer = new Timer() { Interval = 1};
      public bool Auto { get; set; }
      public bool Step { get; set; }
      public bool Hint { get; set; }

      public bool Auto1 { get; set; }
      public bool Auto2 { get; set; }
      public bool Auto3 { get; set; }


      public BrettControl()
      {
         Auto = false;
         Step = false;
         Hint = true;

         Auto1 = true;
         Auto2 = true;
         Auto3 = true;

         InitializeComponent();
         brett = new Brett();
         timer.Tick += new EventHandler(TimerTick);
      }

      void TimerTick(object sender, EventArgs e)
      {
         timer.Stop();
         if (Auto || Step)
         {
            if (Auto1)
            {
               if (brett.SetFirstEasy())
               {
                  timer.Start();
               }
            }
            if (Auto2)
            {
               if (brett.Reduser())
               {
                  if (!timer.Enabled)
                     timer.Start();
               }
               else if (Auto3)
               {
                  if (brett.ReduserLaaste())
                     if (!timer.Enabled)
                        timer.Start();
               }
            }
            Step = false;
         }
         Invalidate();
      }

      public void Clear()
      {
         brett.InitBrett();
         Invalidate();
      }

      public void Diagonal()
      {
         brett.Diagonal = !brett.Diagonal;
         brett.InitBrett();
         Clear();
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

         xMin = 1;
         yMin = 1;

         if (sizeX > sizeY)
            xMin = (sizeX - sizeY) / 2;
         else if (sizeY > sizeX)
            yMin = (sizeY - sizeX) / 2;


         size = Math.Min(sizeX / 9, sizeY / 9);

         xMax = xMin + 9 * size;
         yMax = yMin + 9 * size;

         if (brett.Diagonal)
         {
            for (int row = 0; row < 9; ++row)
            {
               int y = yMin + size * row;
               int x1 = xMin + size * row;
               g.FillRectangle(Brushes.LightCyan, x1, y, size, size);
               int x2 = xMin + size * (8 - row);
               g.FillRectangle(Brushes.LightCyan, x2, y, size, size);
            }
         }

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

         if ((Auto || Step) && !timer.Enabled)
         {
            if (Auto2)
            {
               if (brett.Reduser())
               {
                  timer.Start();
               }
               else if (Auto3)
               {
                  if (brett.ReduserLaaste())
                     timer.Start();
               }
            }
         }
         else if (Hint)
         {
            brett.FinnLaaste();
         }
         if (!timer.Enabled)
         {
            Send();
         }
      }

      public void DrawValue(Graphics g, int x0, int y0, int size, Brett.Plass plass)
      {
         if (plass.Verdi != 0)
         {
            int x = x0 + size / 4;
            int y = y0 + size / 5;
            float fontsize = size / 2;
            if (fontsize > 3)
            {
               Font font = new Font(this.Font.Name, fontsize);
               Brush brush = Brushes.Black;
               g.DrawString(plass.Verdi.ToString(), font, brush, x, y);
            }
         }
         else
         {
            int part = size / 3;
            float fontsize = part / 1.5f;
            foreach (int n in plass.Mulige)
            {
               int i = n - 1 - ((n - 1) / 3) * 3;
               int j = (n - 1) / 3;

               int x = x0 + part * i;
               int y = y0 + part * j;

               if (fontsize > 3)
               {
                  Font font = new Font(this.Font.Name, fontsize);
                  Brush brush = Brushes.LightGreen;
                  if (plass.Lett(n) == 1)
                  {
                     if (Hint)
                     {
                        brush = Brushes.Red;
                     }
                     if (Auto && !timer.Enabled)
                     {
                        timer.Start();
                     }
                  }
                  else if (plass.Par(n))
                  {
                     if (Hint)
                     {
                        brush = Brushes.Blue;
                     }
                  }
                  else if (plass.Trippel(n))
                  {
                     if (Hint)
                     {
                        brush = Brushes.Brown;
                     }
                  }
                  else if (plass.Laast[n - 1])
                  {
                     brush = Brushes.Yellow;
                  }

                  g.DrawString(n.ToString(), font, brush, x, y);
               }
            }

         }
      }

      private void OnMouseClick(object sender, MouseEventArgs e)
      {
         timer.Stop();

         int x0 = (e.X - xMin);
         int y0 = (e.Y - yMin);

         int i = x0 / size;
         int j = y0 / size;

         int x1 = x0 - i * size;
         int y1 = y0 - j * size;

         int part = size / 3;
         int n = x1 / part + 1 + (y1 / part) * 3;

         Brett.Plass plass = brett[i, j];
         if (plass == null) return;

         if (plass.Verdi != 0)
         {
            if (e.Button == MouseButtons.Right)
            {
               plass.SetVerdi(0);
               brett.Reset();
            }
         }
         else
         {
            if (e.Button == MouseButtons.Left)
            {
               plass.SetVerdi(n);
            }
            else if (e.Button == MouseButtons.Right)
            {
               plass.Snu(n);
            }
         }

         Invalidate();
      }

      private void BrettControl_KeyDown(object sender, KeyEventArgs e)
      {
         timer.Stop();

         int value = e.KeyValue - 48;
         if (value < 0 || value > 9) return;

         int x0 = (mouseX - xMin);
         int y0 = (mouseY - yMin);

         int i = x0 / size;
         int j = y0 / size;

         Brett.Plass plass = brett[i, j];
         if (plass == null) return;

         plass.SetVerdi(value);
         brett.Reset();

         Invalidate();

      }

      int mouseX = 0;
      int mouseY = 0;

      private void BrettControl_MouseMove(object sender, MouseEventArgs e)
      {
         mouseX = e.X;
         mouseY = e.Y;
      }

      internal void StopServer()
      {
         if (server != null)
            server.StopServer();
         server = null;
      }

      internal void StartServer()
      {
         StopServer();

         server = new TcpClass();
         server.Receiving += Receiving;
         server.RunServer("", this.serverKanal);
      }

      internal void StopClients()
      {
         if (clients != null)
            return;

         foreach (var item in clients)
         {
            item.Value.Item1.StopClient();
         }
         clients.Clear();
      }

      internal void StartClients()
      {
         if (clients == null)
         {
            clients = new Dictionary<int, Tuple<TcpClass, List<Tuple<int, int>>>>();
         }
         else
         {
            StopClients();
         }

         foreach (var item in connections)
         {
            int kanal = item.Item1;
            if (!clients.ContainsKey(kanal))
            {
               TcpClass client = new TcpClass();
               client.RunClient("", kanal);
               clients[kanal] = new Tuple<TcpClass, List<Tuple<int, int>>>(client, new List<Tuple<int, int>>());
            }
            clients[kanal].Item2.Add(new Tuple<int, int>(item.Item2, item.Item3));
         }
      }

      internal void Send()
      {
         if (clients == null || clients.Count == 0)
            StartClients();

         foreach (var item in clients)
         {
            TcpClass client = item.Value.Item1;
            var connections = item.Value.Item2;
            foreach (var connection in connections)
            {
               string message = connection.Item2.ToString() + ";";
               var rute = brett.GetRute(connection.Item1);
               foreach (var plass in rute)
               {
                  foreach (var mulig in plass)
                  {
                     message += mulig.ToString() + ",";
                  }
                  message += ";";
               }
               client.Send(message);
            }
         }
      }

      private void Receiving(object sender, TcpClass.MessageArgs e)
      {
         var liste = e.message.Split(';');
         if (liste.Length < 10)
            return;

         int tilRute;
         if (!Int32.TryParse((string)liste[0], out tilRute))
         {
            return;
         }
         var rute = brett.GetRute(tilRute);
         var nyRute = new List<List<int>>();
         bool endring = false;
         for (int i = 0; i < 9; i++)
         {
            var plass = new List<int>();
            var mulige = liste[i + 1].Split(',');
            foreach (int j in rute[i])
            {
               if (mulige.Contains<string>(j.ToString()))
               {
                  plass.Add(j);
               }
               else
               {
                  endring = true;
               }
            }
            nyRute.Add(plass);
         }

         if (endring)
         {
            brett.SetRute(tilRute, nyRute);
            Invalidate();
         }
      }

   }
}
