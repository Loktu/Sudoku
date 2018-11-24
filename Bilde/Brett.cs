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
      [XmlIgnore]
      public TimeSpan record { get; set; }
      [XmlElement(ElementName = "record")]
      public long xmlrecord
      {
         get { return record.Ticks; }
         set { record = new TimeSpan(value); }
      }

      [XmlIgnore]
      public TimeSpan soFar { get; set; }

      [XmlElement(ElementName = "soFar")]
      public long xmlsofar
      {
         get { return soFar.Ticks; }
         set { soFar = new TimeSpan(value); }
      }


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

      public enum Verdi { Sort=-1, Ledig=0, Hvit=1}

      public class Plass
      {
         [XmlIgnore]
         public Verdi verdi { get; set; } = Verdi.Ledig;
         [XmlElement(ElementName = "verdi")]
         public int xmlverdi
         {
            get { return (int)verdi; }
            set { verdi = (Verdi)value; }
         }

         public Plass()
         {
         }

         public void Clear()
         {
            verdi = Verdi.Ledig;
         }

         public void SetVerdi(Verdi v)
         {
            if (verdi == v)
               Clear();
            else
               verdi = v;
         }

         [XmlIgnore]
         public Verdi fasit { get; private set; } = Verdi.Ledig;
         [XmlElement(ElementName = "fasit")]
         public int xmlfasit
         {
            get { return (int)fasit; }
            set { fasit = (Verdi)value; }
         }

         public void SetFasit() { fasit = verdi; }
         public void CheckFasit()
         {
            if (fasit != Verdi.Ledig)
               if (verdi != fasit)
                  Clear();
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
         soFar = TimeSpan.Zero;
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

      public void SetFasit()
      {
         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               brett[x, y].SetFasit();
            }
         }
      }

      internal bool HarFasit()
      {
         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               if (brett[x, y].fasit == Verdi.Ledig)
                  return false; ;
            }
         }
         return true;
      }

      internal bool Ferdig()
      {
         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               if (brett[x, y].fasit == Verdi.Ledig)
                  return false; ;
               if (brett[x, y].verdi != brett[x, y].fasit)
                  return false; ;
            }
         }
         return true;
      }

      public void CheckFasit()
      {
         for (int x = 0; x < nLines; ++x)
         {
            for (int y = 0; y < nColumns; ++y)
            {
               brett[x, y].CheckFasit();
            }
         }
      }

      public bool Step()
      {
         CheckFasit();
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
         public List<Gruppe> erF�rsteMuligeForGruppe = new List<Gruppe>();
         public int Restplass()
         {
            int o = erF�rsteMuligeForGruppe.Count;
            foreach (var gruppe in erF�rsteMuligeForGruppe)
            {
               o += gruppe.size;
            }
            return Size() - o;
         }
      }

      class Gruppe
      {
         public List<Rom> muligeRom = new List<Rom>();
         public int size;
         public int index;
      }

      private int BruktePlasser(Rom rom, ref Plass[] plasser)
      {
         int n = 0;
         for (int i = rom.start; i <= rom.slutt; ++i)
         {
            if (plasser[i].verdi == Verdi.Sort)
               ++n;
         }
         return n;
      }
      private int ForsteBrukte(Rom rom, ref Plass[] plasser)
      {
         for (int i = rom.start; i <= rom.slutt; ++i)
         {
            if (plasser[i].verdi < Verdi.Sort)
               return i;
         }
         return -1;
      }


      private bool Step(GruppeListe gruppeListe, Plass[] plass)
      {
         bool funnet = false;

         // Lag Grupper
         List<Gruppe> grupper = new List<Gruppe>();
         int index = 0;
         foreach (var gruppe in gruppeListe)
         {
            grupper.Add(new Gruppe() { size = gruppe, index = index++ });
         }
         if (grupper.Count == 0) goto Feil;

         int i = 0;
         int s = plass.Length - 1;

         // Siste ledige
         while (s > i && plass[s].verdi == Verdi.Hvit) { --s; }
         // F�rste ledige
         while (i < s && plass[i].verdi == Verdi.Hvit) { ++i; }

         //Finn rom
         List<Rom> romListe = new List<Rom>();
         int h = i;
         romListe.Add(new Rom() { start = h, slutt = s });
         while (FinnHvit(plass, ref h, s))
         {
            romListe[romListe.Count - 1].slutt = h - 1;
            while (h < s && plass[h].verdi == Verdi.Hvit) { ++h; }
            romListe.Add(new Rom() { start = h, slutt = s });
         }
         if (romListe.Count == 0) goto Feil;

         // Finn mulige rom forfra, ingen kan v�re foran sin forgjenger
         int irom = 0;
         foreach (var gruppe in grupper)
         {
            while (romListe[irom].Restplass() < gruppe.size)
            {
               ++irom;
               if (irom >= romListe.Count) goto Feil; // Feil
            }
            for (int jrom= irom; jrom<romListe.Count; ++jrom)
            {
               var rom = romListe[jrom];
               if (rom.Size() >= gruppe.size)
               {
                  gruppe.muligeRom.Add(rom);
                  rom.muligeGrupper.Add(gruppe);
               }
            }
            if (gruppe.muligeRom.Count == 0) goto Feil; //Feil
            romListe[irom].erF�rsteMuligeForGruppe.Add(gruppe);
            irom = romListe.IndexOf(gruppe.muligeRom[0]);

            // Sjekk om denne gruppa m� v�re her
            var f�rsteRom = gruppe.muligeRom[0];
            if (BruktePlasser(f�rsteRom, ref plass) > 0)
            {
               if (f�rsteRom.muligeGrupper[0] == gruppe)
               {
                  // M� v�re i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[1].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(1);
                  }
               }
            }
         }

         // Ingen kan v�re bak sin etterkommer
         foreach (Rom rom in romListe)
            rom.erF�rsteMuligeForGruppe.Clear();
         irom = romListe.Count - 1;

         grupper.Reverse();
         foreach (var gruppe in grupper)
         {
            while (romListe[irom] != gruppe.muligeRom[0] && romListe[irom].Restplass() < gruppe.size)
            {
               --irom;
               if (irom < 0) goto Feil; // Feil
            }

            var rom = gruppe.muligeRom[gruppe.muligeRom.Count - 1];
            while (romListe.IndexOf(rom) > irom)
            {
               gruppe.muligeRom.Remove(rom);
               rom.muligeGrupper.Remove(gruppe);
               rom = gruppe.muligeRom[gruppe.muligeRom.Count - 1];
            }
            irom = romListe.IndexOf(rom);
            romListe[irom].erF�rsteMuligeForGruppe.Add(gruppe);

            // Sjekk om denne gruppa m� v�re her
            var sisteRom = gruppe.muligeRom[gruppe.muligeRom.Count - 1];
            if (BruktePlasser(sisteRom, ref plass) > 0)
            {
               if (sisteRom.muligeGrupper[sisteRom.muligeGrupper.Count - 1] == gruppe)
               {
                  // M� v�re i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[0].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(0);
                  }
               }
            }
         }
         grupper.Reverse();

         // @Todo Flytt inn i l�kka over
         // Sjekk f�rste og siste er besatt
         foreach (var gruppe in grupper)
         {
            var f�rsteRom = gruppe.muligeRom[0];
            if (BruktePlasser(f�rsteRom, ref plass) > 0)
            {
               if (f�rsteRom.muligeGrupper[0] == gruppe)
               {
                  // M� v�re i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[1].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(1);
                  }
               }
            }
            var sisteRom = gruppe.muligeRom[gruppe.muligeRom.Count - 1];
            if (BruktePlasser(sisteRom, ref plass) > 0)
            {
               if (sisteRom.muligeGrupper[sisteRom.muligeGrupper.Count - 1] == gruppe)
               {
                  // M� v�re i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[0].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(0);
                  }
               }
            }
         }

         // Fyll ubrukelige rom med hvit
         foreach (var rom in romListe)
         {
            if (rom.muligeGrupper.Count == 0)
            {
               for (int j = rom.start; j <= rom.slutt; ++j) plass[j].verdi = Verdi.Hvit;
               funnet = true;
            }
            else
               funnet |= SjekkRom(rom, ref plass);
         }

         goto End;
         Feil:
         funnet = true;

         End:
         return funnet;
      }

      private bool FinnHvit(Plass[] plass, ref int h, int s)
      {
         while (++h < s)
         {
            if (plass[h].verdi == Verdi.Hvit)
               return true;
         }
         return false;
      }


      bool SjekkRom(Rom rom, ref Plass[] plass)
      {
         bool done = false;
         int i = rom.start;
         int s = rom.slutt;
         int np = rom.Size();

         var grupper = new List<Gruppe>();
         foreach (var gruppe in rom.muligeGrupper)
         {
            if (gruppe.muligeRom.Count == 1)
               grupper.Add(gruppe);
         }
         if (grupper.Count < 1)
            return false;

         int restBehov = grupper.Count-1;
         foreach (var gruppe in grupper)
         {
            restBehov += gruppe.size;
         }
         int ledige = rom.Size() - restBehov;

         if (ledige < 0)
            return true; // Feil



         foreach (var gruppe in grupper)
         {
            if (gruppe.size > ledige)
            {
               for (int j = 0; j < gruppe.size - ledige; ++j)
               {
                  plass[i + j + ledige].verdi = Verdi.Sort;
               }
               done = true;
            }
            if (ledige == 0)
            {
               if (i > 0)
                  plass[i - 1].verdi = Verdi.Hvit;
               if (i + gruppe.size < plass.Length)
                  plass[i + gruppe.size].verdi = Verdi.Hvit;
               done = true;
            }
            i += gruppe.size + 1;
         }
         return done;
      }

   }
}
