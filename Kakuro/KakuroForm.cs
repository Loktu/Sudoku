using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kakuro
{
   public partial class KakuroForm : Form
   {
      public KakuroForm()
      {
         InitializeComponent();
      }

      private void beregn_Click(object sender, EventArgs e)
      {
         int n = (int)antall.Value;
         int s = (int)sum.Value;
         string ja = this.ja_boks.Text;
         string nei = this.nei_boks.Text;
         var ja_liste = string2list(ja);
         var nei_liste = string2list(nei);

         string resultat = "";
         int[] liste = new int[n];

         for (int i = 0; i < n; ++i)
         {
            liste[i] = i + 1;
         }
         do
         {
            if (ok(liste, s, ja_liste, nei_liste))
            {
               if (resultat.Length > 0)
                  resultat += "\r\n";
               resultat += list2string(liste);
            }
         } while (neste(ref liste));

         resultatboks.Text = resultat;
         Invalidate();
      }

      static string list2string(int[] liste)
      {
         string tekst = "";
         foreach (var tall in liste)
         {
            if (tekst.Length > 0)
               tekst += ",";
            tekst += tall;
         }
         return tekst;
      }

      static List<int> string2list(string tekst)
      {
         var liste = new List<int>();
         var nummer = tekst.Split(',');
         foreach (var tall in nummer)
         {
            try
            {
               var i = int.Parse(tall);
               liste.Add(i);
            }
            catch { }
         }
         return liste;
      }

      bool ok(int[] liste, int sum, List<int> ja, List<int> nei)
      {
         foreach (int j in ja)
         {
            if (!liste.Contains(j))
               return false;
         }
         int res = 0;
         foreach (var i in liste)
         {
            if (nei.Contains(i))
               return false;
            res += i;
         }
         return res == sum;
      }

      static bool neste(ref int[] liste)
      {
         int n = liste.Length;
         for (int i = n - 1; i >= 0; i--)
         {
            if (liste[i] < 10 - n + i)
            {
               ++liste[i];
               for (int j = i + 1; j < n; j++)
               {
                  liste[j] = liste[j - 1] + 1;
               }
               return true;
            }
         }
         return false;
      }
   }
}
