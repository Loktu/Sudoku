using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Tallbilde
{
   public class Brett
   {
      [XmlIgnore]
      public TimeSpan Record { get; set; }
      [XmlElement(ElementName = "record")]
      public long Xmlrecord
      {
         get { return Record.Ticks; }
         set { Record = new TimeSpan(value); }
      }

      public void SetRecord()
      {
         if ((SoFar < Record) || (Record.TotalSeconds < 1))
         {
            Record = SoFar;
         }
         history.Add(DateTime.Now, SoFar);
      }

      public TallListe tallListe = new TallListe();

      [XmlIgnore]
      public List<KeyValuePair<DateTime, TimeSpan>> Results => history.results;

      public History history = new History();

      [XmlIgnore]
      public TimeSpan SoFar { get; set; }

      [XmlElement(ElementName = "soFar")]
      public long Xmlsofar
      {
         get { return SoFar.Ticks; }
         set { SoFar = new TimeSpan(value); }
      }


      public int nLines;
      public int nColumns;

      [XmlIgnore]
      public Plass[,] brett;
      // For xml:
      public List<Plass> plassListe;


      public void ForberedXml()
      {
         plassListe = new List<Plass>();
         foreach (var plass in brett)
            plassListe.Add(plass);

         history.ForberedXml();
      }
      public void EtterXml()
      {
         brett = new Plass[nLines, nColumns];

         int n = 0;
         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               brett[x, y] = plassListe[n++];
            }
         }
         history.EtterXml();

         Record = TimeSpan.MaxValue;
         foreach (var t in Results)
         {
            if (t.Value < Record)
               Record = t.Value;
         }
      }

      public Plass this[int l, int c] => (l >= 0 && l < nLines && c >= 0 && c < nColumns) ? brett[l, c] : null;

      public Brett()
      {
      }

      public Brett(int nl, int nc)
      {
         Clear(nl, nc);
      }

      public void Clear(int n, int m)
      {
         nLines = n;
         nColumns = m;
         InitBrett();
         tallListe.Clear();
      }

      public void Restart()
      {
         brett.ForEach(plass => plass.Clear());
         SoFar = TimeSpan.Zero;
      }


      public void InitBrett()
      {
         brett = new Plass[nLines, nColumns];

         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               brett[x, y] = new Plass();
            }
         }

         Results.Clear();
      }

      public void Reset()
      {
         brett.ForEach(plass => plass.Clear());
      }


      public void SetFasit()
      {
         brett.ForEach(plass => plass.SetFasit());
      }

      internal bool HarFasit()
      {
         return !brett.Exists(plass => plass.Fasit == Verdi.Ledig);
      }

      internal bool Ferdig()
      {
         return !brett.Exists(plass => plass.Fasit != plass.Verdi || plass.Verdi == Verdi.Ledig);
      }

      public void CheckFasit()
      {
         brett.ForEach(plass => plass.CheckFasit());
      }

      public bool Step()
      {
         bool done = false;
         while (!done)
         {
            done = true;
            foreach (var item in tallListe.talliste)
            {
               int t = item.tall;
               int row = item.row;
               int col = item.col;
               int r1 = row > 0 ? row - 1 : 0;
               int r2 = row < nLines - 1 ? row + 1 : row;
               int c1 = col > 0 ? col - 1 : 0;
               int c2 = col < nColumns - 1 ? col + 1 : col;
               int nt = 0;
               int ns = 0;
               int nh = 0;
               for (int r = r1; r <= r2; r++)
               {
                  for (int c = c1; c <= c2; c++)
                  {
                     nt = nt + 1;
                     if (brett[r, c].Verdi == Verdi.Sort)
                        ++ns;
                     else if (brett[r, c].Verdi == Verdi.Hvit)
                        ++nh;
                  }
               }
               if (ns == t)
               {
                  if (nh != nt - ns)
                  {
                     done = false;
                     for (int r = r1; r <= r2; r++)
                     {
                        for (int c = c1; c <= c2; c++)
                        {
                           if (brett[r, c].Verdi == Verdi.Ledig)
                              brett[r, c].Verdi = Verdi.Hvit;
                        }
                     }
                  }
               }
               else if (nh == nt - t)
               {
                  done = false;
                  for (int r = r1; r <= r2; r++)
                  {
                     for (int c = c1; c <= c2; c++)
                     {
                        if (brett[r, c].Verdi == Verdi.Ledig)
                           brett[r, c].Verdi = Verdi.Sort;
                     }
                  }
               }
            }
         }
         return done;
      }

      internal void ClearValue(int mouseCol, int mouseRow)
      {
         tallListe.Remove(mouseCol, mouseRow);
      }

      internal void AddValue(int v, int mouseCol, int mouseRow)
      {
         tallListe.Add(v, mouseCol, mouseRow);
      }
   }
   public enum Verdi { Sort = -1, Ledig = 0, Hvit = 1 }

   public class Plass
   {
      [XmlIgnore]
      public Verdi Verdi { get; set; } = Verdi.Ledig;
      [XmlElement(ElementName = "verdi")]
      public int Xmlverdi
      {
         get { return (int)Verdi; }
         set { Verdi = (Verdi)value; }
      }

      public Plass()
      {
      }

      public void Clear()
      {
         Verdi = Verdi.Ledig;
      }

      public void SetVerdi(Verdi v)
      {
         if (Verdi == v)
            Clear();
         else
            Verdi = v;
      }

      [XmlIgnore]
      public Verdi Fasit { get; private set; } = Verdi.Ledig;
      [XmlElement(ElementName = "fasit")]
      public int Xmlfasit
      {
         get { return (int)Fasit; }
         set { Fasit = (Verdi)value; }
      }

      public void SetFasit() { Fasit = Verdi; }
      public void CheckFasit()
      {
         if (Fasit != Verdi.Ledig)
            if (Verdi != Fasit)
               Clear();
      }
   }

   public class History
   {

      [XmlIgnore]
      public List<KeyValuePair<DateTime, TimeSpan>> results = new List<KeyValuePair<DateTime, TimeSpan>>();

      [XmlElement(ElementName = "results")]
      public List<Result> resultList;

      public struct Result
      {
         public long time;
         public long used;
         public Result(long t, long u)
         {
            time = t;
            used = u;
         }

      }
      public void ForberedXml()
      {
         resultList = new List<Result>();
         foreach (var item in results)
         {
            resultList.Add(new Result(item.Key.Ticks, item.Value.Ticks));
         }
      }
      public void EtterXml()
      {
         results.Clear();
         if (resultList != null)
         {
            resultList.Sort((b, a) => a.used.CompareTo(b.used));
            //var fem = resultList.GetRange(0, Math.Min(resultList.Count, 5));
            var fem = resultList.GetRange(Math.Max(0, resultList.Count - 5), Math.Min(resultList.Count, 5));
            foreach (var item in fem)
            {
               long time = item.time;
               long used = item.used;
               if (time > 0 && used > 0)
               {
                  results.Add(new KeyValuePair<DateTime, TimeSpan>(new DateTime(time), new TimeSpan(used)));
               }
            }
         }
      }


      public void Add(DateTime time, TimeSpan timeUsed)
      {
         // Lagrer bare ett resultat pr time
         TimeSpan enTime = new TimeSpan(1, 0, 0);
         int n = results.Count;
         if (n > 0)
         {
            if (time - results[n - 1].Key < enTime) return;
         }
         results.Add(new KeyValuePair<DateTime, TimeSpan>(time, timeUsed));
      }

      public void VisResultater()
      {
         string resultater = "Dato: \tTid\n";
         foreach (var item in results)
         {
            resultater += item.Key.ToShortDateString() + "\t" + item.Value.ToString() + "\n";
         }
         MessageBox.Show(resultater);
      }

   }

   public class TallListe
   {
      public struct Tall
      {
         public int row;
         public int col;
         public int tall;
         public Tall(int t, int r, int c) { tall = t; row = r; col = c; }
      }
      public TallListe() { }
      public List<Tall> talliste = new List<Tall>();
      public void Clear() { talliste.Clear(); }

      public void Remove(int row, int col)
      {
         foreach (var item in talliste)
         {
            if (item.row == row && item.col == col)
            {
               talliste.Remove(item);
               break;
            }
         }
      }

      public void Add(int v, int row, int col) 
      {
         Remove(row, col);
         talliste.Add(new Tall(v,row,col));
      }
   }
}
