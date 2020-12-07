using DealOrNoDeal.Core;
using DealOrNoDeal.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Services
{
    public class BriefcaseService : IBriefcaseService
    {
      List<double> briefcaseValues;

      public BriefcaseService()
      {
         briefcaseValues = BriefcaseValues.Load();
      }

      public List<Briefcase> RandomizeBriefcaseValues()
      {
         List<Briefcase> briefcases = new List<Briefcase>();
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
   }
}
