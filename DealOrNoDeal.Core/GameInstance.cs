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

      private List<Briefcase> briefcases;
      private Player player;

      public GameInstance(IBriefcaseService briefcaseService, IPlayerService playerService)
      {
         _briefcaseService = briefcaseService;
         _playerService = playerService;
      }

      public void Run()
      {         
         briefcases = _briefcaseService.RandomizeBriefcaseValues();
         player = _playerService.GetPlayerDetails();
         Console.WriteLine($"{player.Name} has won {player.SelectedBriefcase.FullAmount}");
      }
   }
}
