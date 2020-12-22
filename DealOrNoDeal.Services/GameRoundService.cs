using DealOrNoDeal.Core;
using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Services.Validation;
using System;
using System.Collections.Generic;

namespace DealOrNoDeal.Services
{
   public class GameRoundService : IGameRoundService
   {
      private IBriefcaseService _briefcaseService;
      private IBankerOfferService _bankerOfferService;
      private Game _game;

      public GameRoundService(IBriefcaseService briefcaseService, IBankerOfferService bankerOfferService)
      {
         _briefcaseService = briefcaseService;
         _bankerOfferService = bankerOfferService;
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

         double bankerOffer = _bankerOfferService.CalculateOffer(_game.RemainingBriefcases, roundNumber);
         Console.WriteLine($"The banker's offer is: PHP{bankerOffer}");
         _game.BankerOffers.Add(bankerOffer);

         _game.GameState = GetContestantsDecision();
         _game.WinCondition = GetContestantsWinCondition(roundNumber);

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

      private void DisplayBriefcase(Briefcase briefcase)
      {
         Console.WriteLine($"Briefcase number {briefcase.Number} contains...");
         Console.WriteLine($"PHP {briefcase.Amount.ToString()}");
      }

      private GameState GetContestantsDecision()
      {
         GameState gameState = GameState.Invalid;

         while (gameState == GameState.Invalid)
         {
            Console.Write("Is it a Deal or No Deal? (Type `Deal` or `No Deal`)");
            string contestantsAnswer = Console.ReadLine().ToLower();
            gameState = ValidateContestantsAnswer(contestantsAnswer);
         }
         
         return gameState;
      }

      private GameState ValidateContestantsAnswer(string contestantsAnswer)
      {
         string dealAnswer = "deal";
         string noDealAnswer = "no deal";

         if (contestantsAnswer == dealAnswer)
            return GameState.Conclude;
         else if (contestantsAnswer == noDealAnswer)
            return GameState.Active;
         else return GameState.Invalid;
      }

      private WinCondition GetContestantsWinCondition(int roundNumber)
      {
         if (_game.GameState == GameState.Conclude && roundNumber > 10)
            return WinCondition.BankerOffer;
         else return WinCondition.PersonalBriefcase;
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
