using System;
using System.Collections.Generic;

namespace XO
{
   public class Brett
   {
      public class Plass
      {
         public int verdi { get; set; } = 0;
         public bool auto { get; set; } = false;
 
         public Plass()
         {
         }

         public void Clear()
         {
            verdi = 0;
            auto = false;
         }

         internal void SetVerdi(int v)
         {
            if (verdi == v)
               verdi = 0;
            else
               verdi = v;
         }
      }

      public Plass[,] brett;
      public int size { get; private set; }

      public Plass this[int x, int y]
      {
         get
         {
            if (x < 0 || x >= size) return null;
            if (y < 0 || y >= size) return null;
            return brett[x, y];
         }
      }

      public Brett(int brettSize=14)
      {
         InitBrett(brettSize);
      }

      public void InitBrett(int brettSize)
      {
         size = System.Math.Max(4, (2 * (brettSize / 2)));
         brett = new Plass[size, size];

         for (int x = 0; x < size; ++x)
         {
            for (int y = 0; y < size; ++y)
            {
               brett[x, y] = new Plass();
            }
         }
      }

      public void Clear(int n)
      {
         InitBrett(n);
         foreach (Plass plass in brett)
         {
            plass.Clear();
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
