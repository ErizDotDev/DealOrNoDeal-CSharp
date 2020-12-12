using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
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

      public void Run()
      {
         List<Briefcase> briefcases = _briefcaseService.RandomizeBriefcaseValues();
         Player player = _playerService.GetPlayerDetails();
         Dictionary<int, int> numberOfBriefcasesToOpenPerRound = _gameRoundService.GetNumberOfBriefcasesToOpenPerRound();

         foreach (KeyValuePair<int, int> roundBriefcaseCountPair in numberOfBriefcasesToOpenPerRound)
         {
            int roundNumber = roundBriefcaseCountPair.Key;
            int briefcaseCount = roundBriefcaseCountPair.Value;
            _gameRoundService.PlayRound(roundNumber, briefcaseCount);
         }

         Console.WriteLine($"{player.Name} has won {player.SelectedBriefcase.FullAmount}");
      }
   }
}
