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
         public List<Gruppe> erFørsteMuligeForGruppe = new List<Gruppe>();
         public int Restplass()
         {
            int o = erFørsteMuligeForGruppe.Count;
            foreach (var gruppe in erFørsteMuligeForGruppe) o += gruppe.size;
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
            if (plasser[i].verdi < 0)
               ++n;
         }
         return n;
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
         while (s > i && plass[s].verdi == 1) { --s; }
         // Første ledige
         while (i < s && plass[i].verdi == 1) { ++i; }

         //Finn rom
         List<Rom> romListe = new List<Rom>();
         int h = i;
         romListe.Add(new Rom() { start = h, slutt = s });
         while (FinnHvit(plass, ref h, s))
         {
            romListe[romListe.Count - 1].slutt = h - 1;
            while (h < s && plass[h].verdi == 1) { ++h; }
            romListe.Add(new Rom() { start = h, slutt = s });
         }
         if (romListe.Count == 0) goto Feil;

         // Finn mulige rom forfra, ingen kan være foran sin forgjenger
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
            romListe[irom].erFørsteMuligeForGruppe.Add(gruppe);
            irom = romListe.IndexOf(gruppe.muligeRom[0]);
         }

         // Ingen kan være bak sin etterkommer
         irom = romListe.Count - 1;
         romListe[irom].erFørsteMuligeForGruppe.Clear();
         grupper.Reverse();
         foreach (var gruppe in grupper)
         {
            while (romListe[irom].Restplass() < gruppe.size)
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
            romListe[irom].erFørsteMuligeForGruppe.Add(gruppe);
         }
         grupper.Reverse();

         // Sjekk første og siste er besatt
         foreach (var gruppe in grupper)
         {
            var førsteRom = gruppe.muligeRom[0];
            if (BruktePlasser(førsteRom, ref plass) > 0)
            {
               if (førsteRom.muligeGrupper[0] == gruppe)
               {
                  // Må være i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[1].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(1);
                  }
               }
            }
            var sisteRom = gruppe.muligeRom[gruppe.muligeRom.Count-1];
            if (BruktePlasser(sisteRom, ref plass) > 0)
            {
               if (sisteRom.muligeGrupper[sisteRom.muligeGrupper.Count-1] == gruppe)
               {
                  // Må være i dette rommet
                  //Fjern andre rom
                  while (gruppe.muligeRom.Count > 1)
                  {
                     gruppe.muligeRom[0].muligeGrupper.Remove(gruppe);
                     gruppe.muligeRom.RemoveAt(0);
                  }
               }
            }
         }

         foreach (var gruppe in grupper)
         {
            if (gruppe.muligeRom.Count == 1)
            {
               var rom = gruppe.muligeRom[0];
               if (rom.muligeGrupper[0] == gruppe || rom.muligeGrupper[rom.muligeGrupper.Count-1] == gruppe)
               {
                  funnet |= SjekkRom(gruppe.muligeRom[0], ref plass);
               }
            }
         }

         // Fjern ubrukelige rom
         List<Rom> ubrukte = new List<Rom>();
         foreach (var rom in romListe)
         {
            if (rom.muligeGrupper.Count == 0)
               ubrukte.Add(rom);
         }
         foreach (var rom in ubrukte)
         {
            for (int j = romListe[0].start; j <= romListe[0].slutt; ++j) plass[j].verdi = 1;
            romListe.Remove(rom);
            funnet = true;
            if (romListe.Count == 0) goto Feil;
         }

         goto End;
         Feil:
         funnet = false;

         End:
         //funnet = Step2(gruppeListe, plass);
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


      bool SjekkRom(Rom rom, ref Plass[] plass)
      {
         bool done = false;
         int i = rom.start;
         int s = rom.slutt;
         int np = rom.Size();

         int restBehov = rom.muligeGrupper.Count-1;
         foreach (var gruppe in rom.muligeGrupper)
         {
            restBehov += gruppe.size;
         }

         foreach (var gruppe in rom.muligeGrupper)
         {
            restBehov -= gruppe.size;

            int ledige = rom.Size() - restBehov;
            int ns = ledige - gruppe.size;

            if (ns < 0) break; // Feil, ikke plass

            int nt = gruppe.size - ns;
            if (nt > 0)
            {
               i += ns;
               for (int j = 0; j < nt; ++j) { plass[i++].verdi = -1; }
               done = true;
            }
            else
            {
               i += gruppe.size;
            }
            restBehov -= 1;
            i += 1;
         }
         return done;
      }

      //private bool Step2(GruppeListe gruppeListe, Plass[] plass)
      //{
      //   bool done = false;
      //   int i = 0;
      //   int np = plass.Length;
      //   int ng = gruppeListe.Count;
      //   int restBehov = ng-1;
      //   for (int g=0; g<ng; ++g)
      //   {
      //      restBehov += gruppeListe[g];
      //   }
      //   int s = np - 1;
      //   // Siste ledige
      //   while (s > i && plass[s].verdi == 1) { --s; }

      //   for (int g = 0; g < ng; ++g)
      //   {
      //      restBehov -= gruppeListe[g];

      //      // Neste ledige
      //      while (i < s && plass[i].verdi == 1) { ++i; }


      //      int rom = s-i+1 - restBehov;
      //      int ns = rom - gruppeListe[g];

      //      if (ns < 0) break; // Feil, ikke plass

      //      int nt = gruppeListe[g] - ns;
      //      if (nt > 0)
      //      {
      //         i += ns;
      //         for (int j = 0; j < nt; ++j) { plass[i++].verdi = -1; }
      //         done = true;
      //      }
      //      else
      //      {
      //         i += gruppeListe[g];
      //      }
      //      restBehov -= 1;
      //      i += 1;
      //   }
      //   return done;
      //}
   }
}
