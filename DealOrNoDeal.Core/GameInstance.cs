using DealOrNoDeal.Core.Data;
using System.Collections.Generic;
using System;

namespace DealOrNoDeal.Core
{
   public class GameInstance
   {
      private IBriefcaseService _briefcaseService;
      private IPlayerService _playerService;
      private IGameRoundService _gameRoundService;            

      public GameInstance(IBriefcaseService briefcaseService, IPlayerService playerService, IGameRoundService gameRoundService)
      {
         _briefcaseService = briefcaseService;
         _playerService = playerService;
         _gameRoundService = gameRoundService;
      }

      public void Run(Game game)
      {
         List<Briefcase> briefcases = _briefcaseService.RandomizeBriefcaseValues();
         game.RemainingBriefcases = briefcases;

         Player player = _playerService.GetPlayerDetails();
         game.RemainingBriefcases.Remove(player.SelectedBriefcase);

         Dictionary<int, int> numberOfBriefcasesToOpenPerRound = _gameRoundService.GetNumberOfBriefcasesToOpenPerRound();

         foreach (KeyValuePair<int, int> roundBriefcaseCountPair in numberOfBriefcasesToOpenPerRound)
         {
            if (game.GameState == GameState.Conclude)
            {
               ConcludeGame(game, player);
               break;
            }

            int roundNumber = roundBriefcaseCountPair.Key;
            int briefcaseCount = roundBriefcaseCountPair.Value;
            _gameRoundService.Initialize(game);
            game = _gameRoundService.PlayRound(roundNumber, briefcaseCount);
         }         
      }

      private void ConcludeGame(Game game, Player player)
      {
         string amountWon = string.Empty;

         if (game.WinCondition == WinCondition.BankerOffer)
            amountWon = game.BankerOffers[game.BankerOffers.Count - 1].ToString();
         else amountWon = player.SelectedBriefcase.FullAmount;

         Console.WriteLine($"{player.Name} has won {amountWon}");
      }
   }
}
