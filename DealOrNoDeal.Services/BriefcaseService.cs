using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DealOrNoDeal.Services
{
    public class BriefcaseService : IBriefcaseService
    {
      private List<double> briefcaseValues;
      private static List<Briefcase> briefcases;

      public BriefcaseService()
      {
         briefcaseValues = BriefcaseValues.Load();
      }

      public List<Briefcase> RandomizeBriefcaseValues()
      {
         briefcases = new List<Briefcase>();
         int briefcaseValuesCount = briefcaseValues.Count;

         for (int i = 0; i < briefcaseValuesCount; i++)
         {
            Briefcase briefcase = new Briefcase()
            {
               Number = i + 1,
               Amount = GetRandomAmountFromBriefcaseValues()
            };

            briefcases.Add(briefcase);
         }

         return briefcases;
      }

      private double GetRandomAmountFromBriefcaseValues()
      {
         int minLimit = 0;
         int maxLimit = briefcaseValues.Count - 1;
         Random random = new Random();
         int randomIndex = random.Next(minLimit, maxLimit);
         double randomAmount = briefcaseValues[randomIndex];
         RemoveAmountFromBriefcaseValues(randomAmount);
         return randomAmount;
      }

      private void RemoveAmountFromBriefcaseValues(double amountToRemove)
      {
         briefcaseValues.Remove(amountToRemove);
      }

      public Briefcase LoadBriefcase(int? briefcaseNumber)
      {
         return briefcaseNumber == null ? null : briefcases.Where(b => b.Number == briefcaseNumber.Value).FirstOrDefault();
      }
   }
}
