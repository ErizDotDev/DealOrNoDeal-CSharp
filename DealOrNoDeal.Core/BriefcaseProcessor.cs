using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Core
{
   public class BriefcaseProcessor
   {
      List<double> briefcaseValues;

      public BriefcaseProcessor()
      {
         briefcaseValues = BriefcaseValues.Load();
      }

      public List<Briefcase> RandomizeBriefcaseValues()
      {
         List<Briefcase> briefcases = new List<Briefcase>();

         for (int i = 0; i < briefcaseValues.Count; i++)
         {
            Briefcase briefcase = new Briefcase()
            {
               Number = i + 1,
               Amount = GetRandomAmountFromBriefcaseValues()
            };
         }

         return briefcases;
      }

      public double GetRandomAmountFromBriefcaseValues()
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
