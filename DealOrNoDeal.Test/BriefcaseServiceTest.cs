using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DealOrNoDeal.Test
{
    public class BriefcaseServiceTest
    {
      [Fact]
      public void RandomizeBriefcaseValues__ShouldReturnLength26()
      {
         BriefcaseService briefcaseProcessor = new BriefcaseService();
         List<Briefcase> briefcases = briefcaseProcessor.RandomizeBriefcaseValues();

         Assert.True(briefcases.Count == 26);
      }

      [Fact]
      public void RandomizeBriefcaseValues__ShouldNotHaveRepeatingValues()
      {
         BriefcaseService briefcaseProcessor = new BriefcaseService();
         List<Briefcase> briefcases = briefcaseProcessor.RandomizeBriefcaseValues();

         Briefcase firstBriefcase = briefcases.First();
         double amount = firstBriefcase.Amount;
         bool isAmountDuplicated = CheckAmountForDuplicates(briefcases, firstBriefcase);

         Assert.False(isAmountDuplicated);
      }

      private bool CheckAmountForDuplicates(List<Briefcase> briefcases, Briefcase firstBriefcase)
      {
         foreach (Briefcase briefcase in briefcases)
         {
            if (briefcase == firstBriefcase) continue;

            if (briefcase.Amount == firstBriefcase.Amount) return true;
         }

         return false;
      }
   }
}
