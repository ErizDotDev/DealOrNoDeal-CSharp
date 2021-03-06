﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Core.Data
{
   public class BriefcaseValues
   {
      public static List<double> Load()
      {
         List<double> briefcaseValues = new List<double>() {
            1.00,
            5.00,
            10.00,
            25.00,
            50.00,
            75.00,
            100.00,
            150.00,
            200.00,
            300.00,
            400.00,
            500.00,
            750.00,
            1000.00,
            2500.00,
            5000.00,
            10000.00,
            25000.00,
            50000.00,
            100000.00,
            200000.00,
            300000.00,
            400000.00,
            500000.00,
            1000000.00,
            2000000.00
         };

         return Randomize(briefcaseValues);
      }

      private static List<double> Randomize(List<double> briefcaseValues)
      {
         Random rng = new Random();
         var result = briefcaseValues
            .Select(x => new { value = x, order = rng.Next() })
            .OrderBy(x => x.order).Select(x => x.value)
            .ToList();

         return result;
      }
   }
}
