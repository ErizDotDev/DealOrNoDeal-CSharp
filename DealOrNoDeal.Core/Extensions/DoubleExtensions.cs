using System;

namespace DealOrNoDeal.Core
{
   public static class DoubleExtensions
   {
      public static string Format(this double amount)
      {
         string result = String.Format("{0:n}", Math.Round(amount, 2));
         return $"PHP{result}";
      }
   }
}
