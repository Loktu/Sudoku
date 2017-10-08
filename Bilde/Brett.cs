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
      public class GruppeListe: IEnumerable<int>
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
            var grupper = stringListe.Split(',');
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

         public void Add(char key)
         {
            var c = (char)key;
            if (key == '-')
            {
               if (stringListe.Length > 0)
                  stringListe = stringListe.Remove(stringListe.Length - 1);
            }
            else
            {
               stringListe += c;
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

         internal void SetVerdi(int v)
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
      public Plass[,] brett;
      public List<Plass> plassListe;

      [XmlIgnore]
      public List<GruppeListe> grupperPrLinje;
      [XmlIgnore]
      public List<GruppeListe> grupperPrKolonne;

      public List<string> linjeListe;
      public List<string> kolonneListe;

      public int GruppeBredde()
      {
         int n = 1;
         foreach(var liste in grupperPrLinje)
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

      internal void Clear(int n, int m)
      {
         nLines = n;
         nColumns = m;
         InitBrett();
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
      }

      public void Reset()
      {
         foreach (Plass plass in brett)
         {
            plass.Clear();
         }
      }

      public bool Step()
      {
         //@Todo:
         return false;
      }

   }
}
