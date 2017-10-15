using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Bilde
{
   public class Brett
   {
      public class GruppeListe : IEnumerable<int>
      {
         public GruppeListe()
         {
            stringListe = "";
            liste = new List<int>();
         }

         public string stringListe;
         [XmlIgnore]
         List<int> liste;

         [XmlIgnore]
         public string Liste
         {
            get { return stringListe; }
            set
            {
               stringListe = value;
               StringToListe();
            }
         }
         [XmlIgnore]
         public int Count { get { return liste.Count; } }

         public void StringToListe()
         {
            liste.Clear();
            var grupper = stringListe.Split(' ');
            foreach (string gruppe in grupper)
            {
               int antall;
               if (int.TryParse(gruppe, out antall))
               {
                  liste.Add(antall);
               }
            }
         }

         [XmlIgnore]
         public int this[int i]
         {
            get { return liste[i]; }
         }

         public IEnumerator<int> GetEnumerator()
         {
            return ((IEnumerable<int>)liste).GetEnumerator();
         }

         IEnumerator IEnumerable.GetEnumerator()
         {
            return ((IEnumerable<int>)liste).GetEnumerator();
         }

         bool noSpaceNext = false;
         public void Add(char key)
         {
            var c = (char)key;
            if (key == '*' || key == '+')
               noSpaceNext = true;
            else
            {
               if (key == '-' || key == '\b')
               {
                  if (stringListe.Length > 0)
                     stringListe = stringListe.Remove(stringListe.Length - 1);
               }
               else
               {
                  if (key >= '0' && key <= '9')
                  {
                     if (!noSpaceNext && !stringListe.EndsWith(" ") && stringListe.Length > 0)
                     {
                        stringListe += " ";
                     }
                     stringListe += c;
                  }
               }
               noSpaceNext = false;
            }
            StringToListe();
         }
      }

      public class Plass
      {
         public int verdi { get; set; } = 0;

         public Plass()
         {
         }

         public void Clear()
         {
            verdi = 0;
         }

         public void SetVerdi(int v)
         {
            if (verdi == v)
               verdi = 0;
            else
               verdi = v;
         }
      }

      public int nLines;
      public int nColumns;

      [XmlIgnore]
      private Plass[][] linjer;
      [XmlIgnore]
      private Plass[][] kolonner;

      [XmlIgnore]
      public Plass[,] brett;
      // For xml:
      public List<Plass> plassListe;

      [XmlIgnore]
      public List<GruppeListe> grupperPrLinje;
      [XmlIgnore]
      public List<GruppeListe> grupperPrKolonne;

      // For xml
      public List<string> linjeListe;
      public List<string> kolonneListe;

      public int GruppeBredde()
      {
         int n = 1;
         foreach (var liste in grupperPrLinje)
         {
            n = Math.Max(liste.Count, n);
         }
         return n;
      }
      public int GruppeHoyde()
      {
         int n = 1;
         foreach (var liste in grupperPrKolonne)
         {
            n = Math.Max(liste.Count, n);
         }
         return n;
      }

      public void ListeFromArray()
      {
         plassListe = new List<Plass>();
         foreach (var plass in brett)
            plassListe.Add(plass);

         linjeListe = new List<string>();
         foreach (var gruppeliste in this.grupperPrLinje)
         {
            linjeListe.Add(gruppeliste.stringListe);
         }
         kolonneListe = new List<string>();
         foreach (var gruppeliste in this.grupperPrKolonne)
         {
            kolonneListe.Add(gruppeliste.stringListe);
         }

      }
      public void ArrayFromListe()
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
         grupperPrLinje = new List<GruppeListe>();
         n = 0;
         grupperPrLinje = new List<GruppeListe>();
         foreach (var gruppe in linjeListe)
         {
            var grupper = new GruppeListe();
            grupper.stringListe = gruppe;
            grupper.StringToListe();
            grupperPrLinje.Add(grupper);
         }
         n = 0;
         grupperPrKolonne = new List<GruppeListe>();
         foreach (var gruppe in kolonneListe)
         {
            var grupper = new GruppeListe();
            grupper.stringListe = gruppe;
            grupper.StringToListe();
            grupperPrKolonne.Add(grupper);
         }
         LagLinjerOgKollonner();
      }

      public Plass this[int l, int c]
      {
         get
         {
            if (l < 0 || l >= nLines) return null;
            if (c < 0 || c >= nColumns) return null;
            return brett[l, c];
         }
      }


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
      }

      public void Restart()
      {
         foreach (var plass in brett)
            plass.Clear();
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

         grupperPrLinje = new List<GruppeListe>();
         grupperPrKolonne = new List<GruppeListe>();
         for (int l = 0; l < nLines; ++l)
         {
            grupperPrLinje.Add(new GruppeListe());
         }
         for (int c = 0; c < nColumns; ++c)
         {
            grupperPrKolonne.Add(new GruppeListe());
         }
         LagLinjerOgKollonner();
      }

      public void Reset()
      {
         foreach (Plass plass in brett)
         {
            plass.Clear();
         }
      }
      private void LagLinjerOgKollonner()
      {
         linjer = new Plass[nLines][];
         for (int x = 0; x < nLines; ++x)
         {
            linjer[x] = new Plass[nColumns];
            for (int y = 0; y < nColumns; ++y)
            {
               linjer[x][y] = brett[x, y];
            }
         }
         kolonner = new Plass[nColumns][];
         for (int y = 0; y < nColumns; ++y)
         {
            kolonner[y] = new Plass[nLines];
            for (int x = 0; x < nLines; ++x)
            {
               kolonner[y][x] = brett[x, y];
            }
         }
      }

      public bool Step()
      {
         bool done = false;
         for (int x = 0; x < nLines; ++x)
         {
            done |= Step(grupperPrLinje[x], linjer[x]);
         }
         for (int y = 0; y < nColumns; ++y)
         {
            done |= Step(this.grupperPrKolonne[y], kolonner[y]);
         }
         return done;
      }

      class Rom
      {

         public int start;
         public int slutt;
         public int Size() { return slutt - start + 1; }
         public List<Gruppe> muligeGrupper = new List<Gruppe>();
      }
      class Gruppe
      {
         public List<Rom> muligeRom = new List<Rom>();
         public int size;
         public int index;
      }

      private bool Step2(GruppeListe gruppeListe, Plass[] plass)
      {
         bool funnet = false;
         List<Gruppe> grupper = new List<Gruppe>();
         int index = 0;
         foreach (var gruppe in gruppeListe)
         {
               grupper.Add(new Gruppe() { size = gruppe, index = index++ });
         }
         List<Rom> romListe = new List<Rom>();

         int i = 0;
         int s = 0;
         romListe.Add(new Rom() { start = i, slutt = s });
         int h = i;
         while (FinnHvit(plass, ref h, s))
         {
            romListe[romListe.Count - 1].slutt = h - 1;
            while (h < s && plass[h].verdi == 1) { ++h; }
            romListe.Add(new Rom() { start = h, slutt = s });
         }


         return funnet;
      }

      private bool FinnHvit(Plass[] plass, ref int h, int s)
      {
         while (++h < s)
         {
            if (plass[h].verdi == 1)
               return true;
         }
         return false;
      }



      private bool Step(GruppeListe gruppeListe, Plass[] plass)
      {
         bool done = false;
         int i = 0;
         int np = plass.Length;
         int ng = gruppeListe.Count;
         int restBehov = ng-1;
         for (int g=0; g<ng; ++g)
         {
            restBehov += gruppeListe[g];
         }
         int s = np - 1;
         // Siste ledige
         while (s > i && plass[s].verdi == 1) { --s; }

         for (int g = 0; g < ng; ++g)
         {
            restBehov -= gruppeListe[g];

            // Neste ledige
            while (i < s && plass[i].verdi == 1) { ++i; }


            int rom = s-i+1 - restBehov;
            int ns = rom - gruppeListe[g];

            if (ns < 0) break; // Ikke plass, feil

            int nt = gruppeListe[g] - ns;
            if (nt > 0)
            {
               i += ns;
               for (int j = 0; j < nt; ++j) { plass[i++].verdi = -1; }
               done = true;
            }
            else
            {
               i += gruppeListe[g];
            }
            restBehov -= 1;
            i += 1;
         }
         return done;
      }
   }
}
