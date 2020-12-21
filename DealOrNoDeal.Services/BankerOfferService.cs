using DealOrNoDeal.Core;
using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Services
{
   public class BankerOfferService : IBankerOfferService
   {
      public double CalculateOffer(List<Briefcase> remainingBriefcases, int roundNumber)
      {
         double averageAmountLeft = GetAverageAmountLeft(remainingBriefcases);
         return averageAmountLeft * roundNumber / 10;
      }

      private double GetAverageAmountLeft(List<Briefcase> remainingBriefcases)
      {
         double average = 0;
         int briefcaseCount = 0;

         foreach(Briefcase briefcase in remainingBriefcases)
         {
            average += briefcase.Amount;
            briefcaseCount++;
         }

         average = average / briefcaseCount;
         return average;
      }
   }
}
