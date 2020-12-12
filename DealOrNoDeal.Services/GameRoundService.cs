using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Services
{
   public class GameRoundService : IGameRoundService
   {
      public void PlayRound(int roundNumber, int briefcaseToOpenCount)
      {
         Console.WriteLine($"Round {roundNumber}");
         
         for (int i = 1; i <= briefcaseToOpenCount; i++)
         {
            int briefcaseNumber = GetBriefcaseNumber();
         }
      }

      private int GetBriefcaseNumber()
      {
         int briefcaseNumber = 0;

         while (briefcaseNumber == 0)
         {
            Console.Write("Select briefcase to open: ");
            briefcaseNumber = GetBriefcaseNumber(Console.ReadLine());
         }

         return briefcaseNumber;
      }

      private int GetBriefcaseNumber(string input)
      {
         int parsedInput;
         
         if (int.TryParse(input, out parsedInput))
         {
            return parsedInput;
         }

         return 0;
      }

      public Dictionary<int, int> GetNumberOfBriefcasesToOpenPerRound()
      {
         return new Dictionary<int, int>()
         {
            // key = Round number, value = number of briefcases to open
            { 1, 6 },
            { 2, 5 },
            { 3, 4 },
            { 4, 3 },
            { 5, 2 },
            { 6, 1 },
            { 7, 1 },
            { 8, 1 },
            { 9, 1 },

            { 10, 0 }
         };
      }
   }
}
