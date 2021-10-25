using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
   public static class Extensions
   {
      public static void ForEach<T>(this T[] array, Action<T> action)
      {
         foreach (T item in array)
         {
            action(item);
         }
      }

      public static void ForEach<T>(this T[,] array, Action<T> action)
      {
         foreach (T item in array)
         {
            action(item);
         }
      }
      public static bool Exists<T>(this T[,] array, Predicate<T> predicate)
      {
         foreach (T item in array)
         {
            if (predicate(item))
               return true;
         }
         return false;
      }
   }
}
