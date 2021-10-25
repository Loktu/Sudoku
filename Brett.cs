using System.Collections.Generic;

namespace Sudoku
{
   public class Brett
   {
      public class Plass
      {
         public Plass()
         {
            Laast.ForEach(laast => laast = false);
         }

         public int k;
         public bool[] Laast = new bool[9];

         int verdi = 0;
         public int Verdi
         {
            get { return verdi; }
            set { verdi = value; }
         }

         List<int> mulige = new List<int>(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
         public List<int> Mulige { get { return mulige; } set { mulige = value; } }

         public void Clear()
         {
            mulige.Clear();
            verdi = 0;
            mulige = new List<int>(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
         }

         public List<Kombinasjon> kombinasjoner = new List<Kombinasjon>();
         public void Add(Kombinasjon kominasjon) { kombinasjoner.Add(kominasjon); }

         public void Snu(int n)
         {
            if (mulige.Contains(n))
               mulige.Remove(n);
            else
               mulige.Add(n);
         }

         public bool Reduser(int i1, int i2)
         {
            if (mulige.Count != 2)
            {
               mulige.Clear();
               mulige.Add(i1);
               mulige.Add(i2);
               return true;
            }
            return false;
         }

         public bool Reduser(int i1, int i2, int i3)
         {
            int n = mulige.Count;
            bool b1 = mulige.Contains(i1);
            bool b2 = mulige.Contains(i2);
            bool b3 = mulige.Contains(i3);
            mulige.Clear();
            if (b1) mulige.Add(i1);
            if (b2) mulige.Add(i2);
            if (b3) mulige.Add(i3);
            return mulige.Count != n;
         }

         public bool TaBort(int n)
         {
            if (mulige.Contains(n))
            {
               mulige.Remove(n);
               return true;
            }
            return false;
         }

         public void LeggTil(int n)
         {
            if (!mulige.Contains(n))
               mulige.Add(n);
         }

         public void SetVerdi(int value)
         {
            if (value == 0)
            {
               mulige = new List<int>(9) { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
               foreach (Kombinasjon kombinasjon in kombinasjoner)
               {
                  kombinasjon.LeggTil(verdi);
               }
               verdi = value;
            }
            else
            {
               if (mulige.Contains(value))
               {
                  foreach (Kombinasjon kombinasjon in kombinasjoner)
                  {
                     kombinasjon.TaBort(value);
                  }
                  mulige.Clear();
                  verdi = value;
               }
            }
         }

         public int Lett(int n)
         {
            if (mulige.Count == 1) return 1;
            int l = 9;
            foreach (Kombinasjon kombinasjon in kombinasjoner)
            {
               int m = kombinasjon.Count(n);
               if (m < l)
                  l = m;
            }
            return l;
         }

         public bool Par(int n)
         {
            for (int i = 1; i < 10; i++)
            {
               if (i == n) continue;
               foreach (Kombinasjon kombinasjon in kombinasjoner)
               {
                  if (kombinasjon.Par(i, n, this))
                     return true;
               }
            }
            return false;
         }

         public bool Trippel(int n)
         {
            for (int i = 1; i < 9; i++)
            {
               if (i == n) continue;
               for (int j = i + 1; j < 10; j++)
               {
                  if (j == n) continue;
                  foreach (Kombinasjon kombinasjon in kombinasjoner)
                  {
                     if (kombinasjon.Trippel(i, j, n, this))
                        return true;
                  }
               }
            }
            return false;
         }

         public bool Singel(int n)
         {
            if (mulige.Count == 1)
               return true;

            foreach (Kombinasjon kombinasjon in kombinasjoner)
            {
               if (kombinasjon.Count(n) == 1)
                  return true;
            }
            return false;
         }

      }

      public class Kombinasjon
      {
         List<Plass> plasser = new List<Plass>();
         public List<Plass> Plasser { get { return plasser; } set { plasser = value; } }
         public void Add(Plass plass) { plasser.Add(plass); }

         public void LeggTil(int v)
         {
            foreach (Plass plass in plasser)
            {
               plass.LeggTil(v);
            }
         }

         public void TaBort(int v)
         {
            foreach (Plass plass in plasser)
            {
               plass.TaBort(v);
            }
         }

         public int Count(int m)
         {
            int n = 0;
            foreach (Plass plass in plasser)
            {
               if (plass.Mulige.Contains(m))
                  ++n;
            }
            return n;
         }

         public bool Par(int i1, int i2, Plass enPlass)
         {
            int n = 0;
            int m = 0;
            bool synligPar = false;
            bool skjultPar = false;
            foreach (Plass plass in plasser)
            {
               if (plass.Verdi != 0)
                  continue;

               bool b1 = plass.Mulige.Contains(i1);
               bool b2 = plass.Mulige.Contains(i2);

               if (b1 && b2)
               {
                  if (plass.Mulige.Count == 2)
                  {
                     m++;
                     if (plass == enPlass)
                        synligPar = true;
                  }
                  if (m == 2)
                     return synligPar;

                  if (plass == enPlass)
                     skjultPar = true;
                  n++;
               }
               else if (b1 || b2)
                  n = 3;
            }
            return (n == 2) && skjultPar;
         }

         public bool Trippel(int i1, int i2, int i3, Plass enPlass)
         {
            int n = 0;
            int m = 0;
            bool synligTrippel = false;
            bool skjultTrippel = false;
            foreach (Plass plass in plasser)
            {
               if (plass.Verdi != 0)
               {
                  if (plass.Verdi == i1) return false;
                  if (plass.Verdi == i2) return false;
                  if (plass.Verdi == i3) return false;
                  continue;
               }

               bool b1 = plass.Mulige.Contains(i1);
               bool b2 = plass.Mulige.Contains(i2);
               bool b3 = plass.Mulige.Contains(i3);

               int k = (b1 ? 1 : 0) + (b2 ? 1 : 0) + (b3 ? 1 : 0);

               if (k > 0)
               {
                  if (plass.Mulige.Count == k)
                  {
                     m++;
                     if (plass == enPlass)
                        synligTrippel = true;
                  }
                  if (m == 3)
                     return synligTrippel;

                  if (plass == enPlass)
                     skjultTrippel = true;
                  n++;
               }
            }
            if ((n == 3) && skjultTrippel)
               return true;

            return false;
         }

         public bool Reduser()
         {
            if (ReduserPar())
               return true;
            if (ReduserTrippel())
               return true;
            return false;
         }

         public bool ReduserPar()
         {
            Plass[] funnetSynlig = new Plass[2];
            Plass[] funnetSkjult = new Plass[2];

            for (int i1 = 1; i1 <= 8; ++i1)
            {
               for (int i2 = i1 + 1; i2 <= 9; ++i2)
               {
                  int n = 0;
                  int m = 0;

                  foreach (Plass plass in plasser)
                  {
                     if (plass.Verdi != 0)
                        continue;

                     bool b1 = plass.Mulige.Contains(i1);
                     bool b2 = plass.Mulige.Contains(i2);

                     if (b1 && b2)
                     {
                        if (plass.Mulige.Count == 2)
                        {
                           if (m < 2)
                           {
                              funnetSynlig[m] = plass;
                           }
                           ++m;
                           if (m == 2)
                           {
                              break;
                           }
                        }

                        if (n < 2)
                        {
                           funnetSkjult[n] = plass;
                        }
                        ++n;
                     }
                     else if (b1 || b2)
                        n = 3;
                  }
                  if (m == 2)
                  {
                     if (Reduser(funnetSynlig, i1, i2))
                        return true;
                  }
                  if (n == 2)
                  {
                     if (Reduser(funnetSkjult, i1, i2))
                        return true;
                  }
               }
            }
            return false;
         }

         public bool ReduserTrippel()
         {
            Plass[] funnetSynlig = new Plass[3];
            Plass[] funnetSkjult = new Plass[3];

            for (int i1 = 1; i1 <= 7; ++i1)
            {
               for (int i2 = i1 + 1; i2 <= 8; ++i2)
               {
                  for (int i3 = i2 + 1; i3 <= 9; ++i3)
                  {
                     int n = 0;
                     int m = 0;

                     foreach (Plass plass in plasser)
                     {
                        if (plass.Verdi != 0)
                        {
                           if ((plass.Verdi == i3) ||
                               (plass.Verdi == i2) ||
                               (plass.Verdi == i1))
                           {
                              n = 4;
                              break;
                           }
                           continue;
                        }

                        bool b1 = plass.Mulige.Contains(i1);
                        bool b2 = plass.Mulige.Contains(i2);
                        bool b3 = plass.Mulige.Contains(i3);

                        int k = (b1 ? 1 : 0) + (b2 ? 1 : 0) + (b3 ? 1 : 0);

                        if (k > 0)
                        {
                           if (plass.Mulige.Count == k)
                           {
                              if (m < 3)
                              {
                                 funnetSynlig[m] = plass;
                              }
                              ++m;
                              if (m == 3)
                              {
                                 break;
                              }
                           }

                           if (n < 3)
                           {
                              funnetSkjult[n] = plass;
                           }
                           ++n;
                        }
                     }
                     if (m == 3)
                     {
                        if (Reduser(funnetSynlig, i1, i2, i3))
                           return true;
                     }
                     if (n == 3)
                     {
                        if (Reduser(funnetSkjult, i1, i2, i3))
                           return true;
                     }
                  }
               }
            }
            return false;
         }


         bool Reduser(Plass[] funnet, int i1, int i2)
         {
            bool done = false;
            foreach (Plass plass in plasser)
            {
               if (plass != funnet[0] && plass != funnet[1])
               {
                  done |= plass.TaBort(i1);
                  done |= plass.TaBort(i2);
               }
            }
            done |= funnet[0].Reduser(i1, i2);
            done |= funnet[1].Reduser(i1, i2);
            return done;
         }

         bool Reduser(Plass[] funnet, int i1, int i2, int i3)
         {
            bool done = false;
            foreach (Plass plass in plasser)
            {
               if (plass != funnet[0] && plass != funnet[1] && plass != funnet[2])
               {
                  done |= plass.TaBort(i1);
                  done |= plass.TaBort(i2);
                  done |= plass.TaBort(i3);
               }
            }
            done |= funnet[0].Reduser(i1, i2, i3);
            done |= funnet[1].Reduser(i1, i2, i3);
            done |= funnet[2].Reduser(i1, i2, i3);
            return done;
         }

      }

      public Kombinasjon[] kombinasjoner;
      public Plass[,] brett;

      public Plass this[int x, int y]
      {
         get
         {
            if (x < 0 || x > 8) return null;
            if (y < 0 || y > 8) return null;
            return brett[x, y];
         }
      }

      public Brett()
      {
         InitBrett();
      }

      public void InitBrett()
      {
         brett = new Plass[9, 9];
         int n = 3 * 9;
         if (Diagonal) n += 2;
         kombinasjoner = new Kombinasjon[n];

         for (int k = 0; k < n; ++k)
         {
            kombinasjoner[k] = new Kombinasjon();
         }

         for (int x = 0; x < 9; ++x)
         {
            for (int y = 0; y < 9; ++y)
            {
               brett[x, y] = new Plass();

               brett[x, y].Add(kombinasjoner[x]);
               kombinasjoner[x].Add(brett[x, y]);

               brett[x, y].Add(kombinasjoner[y + 9]);
               kombinasjoner[y + 9].Add(brett[x, y]);

               int k = x / 3 + (int)(y / 3) * 3;
               brett[x, y].Add(kombinasjoner[k + 18]);
               brett[x, y].k = k + 1;
               kombinasjoner[k + 18].Add(brett[x, y]);
            }

            if (Diagonal)
            {
               brett[x, x].Add(kombinasjoner[27]);
               kombinasjoner[27].Add(brett[x, x]);

               brett[x, 8 - x].Add(kombinasjoner[28]);
               kombinasjoner[28].Add(brett[x, 8 - x]);
            }
         }
      }

      public List<List<int>> GetRute(int rute)
      {
         List<List<int>> plasser = new List<List<int>>();
         int k = rute + 17;
         foreach (var plass in kombinasjoner[k].Plasser)
         {
            List<int> mulige = new List<int>();
            if (plass.Verdi > 0)
            {
               mulige.Add(plass.Verdi);
            }
            else
            {
               mulige.AddRange(plass.Mulige);
            }
            plasser.Add(mulige);
         }
         return plasser;
      }

      public void SetRute(int rute, List<List<int>> plasser)
      {
         int k = rute + 17;
         int i = 0;
         foreach (var plass in kombinasjoner[k].Plasser)
         {
            List<int> mulige = plasser[i++];
            if (mulige.Count > 1)
            {
               plass.Mulige = mulige;
               plass.Verdi = 0;
            }
            else
            {
               plass.SetVerdi(mulige[0]);
            }
         }
      }


      public bool Diagonal { get; set; }

      public void Clear()
      {
         //InitBrett();
         foreach (Plass plass in brett)
         {
            plass.Clear();
         }
      }

      public bool SetFirstEasy()
      {
         foreach (Plass plass in brett)
         {
            if (plass.Verdi == 0)
            {
               if (plass.Mulige.Count == 1)
               {
                  plass.SetVerdi(plass.Mulige[0]);
                  return true;
               }
            }
            foreach (int m in plass.Mulige)
            {
               foreach (Kombinasjon kombinasjon in plass.kombinasjoner)
               {
                  if (kombinasjon.Count(m) == 1)
                  {
                     plass.SetVerdi(m);
                     return true;
                  }
               }
            }
         }
         return false;
      }

      public bool Reduser()
      {
         foreach (Kombinasjon kombinasjon in kombinasjoner)
         {
            if (kombinasjon.Reduser())
               return true;
         }

         return false;
      }

      public void SetAllEasy()
      {
         foreach (Plass plass in brett)
         {
            if (plass.Verdi == 0)
            {
               if (plass.Mulige.Count == 1)
               {
                  plass.SetVerdi(plass.Mulige[0]);
                  continue;
               }
            }
         }

         foreach (Plass plass in brett)
         {
            if (plass.Verdi == 0)
            {
               foreach (int m in plass.Mulige)
               {
                  foreach (Kombinasjon kombinasjon in plass.kombinasjoner)
                  {
                     if (kombinasjon.Count(m) == 1)
                     {
                        plass.SetVerdi(m);
                        return;
                     }
                  }
               }
            }
         }
      }

      public void Reset()
      {
         foreach (Plass plass in brett)
         {
            if (plass.Verdi == 0)
               plass.Clear();
         }
         foreach (Plass plass in brett)
         {
            if (plass.Verdi != 0)
            {
               foreach (Kombinasjon kombinasjon in plass.kombinasjoner)
               {
                  kombinasjon.TaBort(plass.Verdi);
               }
               plass.Mulige.Clear();
            }
         }
      }

      /// <summary>
      /// Finn låsete i en kombinasjon, og reduser i andre
      /// </summary>
      public bool ReduserLaaste()
      {
         bool done = false;
         List<Plass> funnet = new List<Plass>();
         foreach (Kombinasjon kombinasjon in kombinasjoner)
         {
            for (int i = 1; i <= 9; ++i)
            {
               funnet.Clear();
               foreach (Plass plass in kombinasjon.Plasser)
               {
                  if (plass.Verdi == i)
                  {
                     funnet.Clear();
                     break;
                  }
                  if (plass.Mulige.Contains(i))
                     funnet.Add(plass);
               }
               if (funnet.Count > 0 && funnet.Count < 4)
               {
                  foreach (Kombinasjon annenKombinasjon in kombinasjoner)
                  {
                     if (annenKombinasjon == kombinasjon)
                        continue;

                     bool alle = true;
                     foreach (Plass plass in funnet)
                     {
                        if (!annenKombinasjon.Plasser.Contains(plass))
                        {
                           alle = false;
                           break;
                        }
                     }
                     if (alle)
                     {
                        foreach (Plass plass in annenKombinasjon.Plasser)
                        {
                           if (!funnet.Contains(plass))
                           {
                              done |= plass.TaBort(i);
                           }
                        }
                        if (done)
                           return true;
                     }
                  }
               }
            }
         }
         return done;
      }

      /// <summary>
      /// Finn låsete for å hinte, reduser ikke
      /// </summary>
      public void FinnLaaste()
      {
         brett.ForEach(plass => plass.Laast.ForEach(laast => laast = false));

         List<Plass> funnet = new List<Plass>();
         foreach (Kombinasjon kombinasjon in kombinasjoner)
         {
            for (int i = 1; i <= 9; ++i)
            {
               funnet.Clear();
               foreach (Plass plass in kombinasjon.Plasser)
               {
                  if (plass.Verdi == i)
                  {
                     funnet.Clear();
                     break;
                  }
                  if (plass.Mulige.Contains(i))
                     funnet.Add(plass);
               }
               if (funnet.Count > 0 && funnet.Count < 4)
               {
                  foreach (Kombinasjon annenKombinasjon in kombinasjoner)
                  {
                     if (annenKombinasjon == kombinasjon)
                        continue;

                     bool alle = true;
                     foreach (Plass plass in funnet)
                     {
                        if (!annenKombinasjon.Plasser.Contains(plass))
                        {
                           alle = false;
                           break;
                        }
                     }
                     if (alle)
                     {
                        foreach (Plass plass in annenKombinasjon.Plasser)
                        {
                           if (plass.Mulige.Contains(i))
                           {
                              if (!funnet.Contains(plass))
                                 plass.Laast[i - 1] = true;
                           }
                        }
                     }
                  }
               }
            }
         }
      }

   }
}
