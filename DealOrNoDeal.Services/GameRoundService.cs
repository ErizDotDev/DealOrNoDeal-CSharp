using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
using DealOrNoDeal.Services.Validation;
using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Services
{
   public class GameRoundService : IGameRoundService
   {
      private IBriefcaseService _briefcaseService;
      private Game _game;

      public GameRoundService(IBriefcaseService briefcaseService)
      {
         _briefcaseService = briefcaseService;
      }

      public void Initialize(Game game)
      {
         _game = game;
      }

      public Game PlayRound(int roundNumber, int briefcaseToOpenCount)
      {
         Console.WriteLine($"Round {roundNumber}");
         
         for (int i = 1; i <= briefcaseToOpenCount; i++)
         {
            int briefcaseNumber = GetBriefcaseNumber();
            Briefcase briefcase = _briefcaseService.LoadBriefcase(briefcaseNumber);
            DisplayBriefcase(briefcase);
            _game = _game.RemoveBriefcaseFromList(briefcase);
         }

         return _game;
      }

      private int GetBriefcaseNumber()
      {
         int briefcaseNumber = 0;

         BriefcaseNumberValidator briefcaseNumberValidator = new BriefcaseNumberValidator(_briefcaseService);
         briefcaseNumberValidator.Initialize(_game.RemainingBriefcases);

         while (briefcaseNumber == 0)
         {
            Console.Write("Select briefcase to open: ");
            briefcaseNumber = briefcaseNumberValidator.TryValidateInput(Console.ReadLine());
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

      private void DisplayBriefcase(Briefcase briefcase)
      {
         Console.WriteLine($"Briefcase number {briefcase.Number} contains...");
         Console.WriteLine($"PHP {briefcase.Amount.ToString()}");
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
