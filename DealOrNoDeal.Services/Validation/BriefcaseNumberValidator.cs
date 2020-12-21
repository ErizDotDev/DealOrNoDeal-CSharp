using DealOrNoDeal.Core;
using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Services.Validation
{
   internal class BriefcaseNumberValidator
   {
      private IBriefcaseService _briefcaseService;
      private List<Briefcase> _remainingBriefcases = new List<Briefcase>();

      public BriefcaseNumberValidator(IBriefcaseService briefcaseService)
      {
         _briefcaseService = briefcaseService;         
      }

      public void Initialize(List<Briefcase> remainingBriefcases)
      {
         _remainingBriefcases = remainingBriefcases;
      }

      public int TryValidateInput(string input)
      {
         int briefcaseNumber = TryParseInput(input);

         if (!BriefcaseNumberIsValid(briefcaseNumber))
         {
            briefcaseNumber = 0;
         }
                  
         return briefcaseNumber;
      }

      private int TryParseInput(string input)
      {
         int parsedInput;

         if (int.TryParse(input, out parsedInput))
         {
            return parsedInput;
         }

         return 0;
      }

      private bool BriefcaseNumberIsValid(int briefcaseNumber)
      {
         if (briefcaseNumber > 0 && BriefcaseNumberExists(briefcaseNumber))
         {
            return true;
         }

         return false;
      }

      private bool BriefcaseNumberExists(int briefcaseNumber)
      {
         return _briefcaseService.ValidateBriefcaseNumberIfExists(_remainingBriefcases, briefcaseNumber);
      }
   }
}
