using DealOrNoDeal.Core;
using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
using DealOrNoDeal.Services;
using System;

namespace DealOrNoDeal.Cli
{
   class Program
   {
      static void Main(string[] args)
      {
         Console.WriteLine("Let's play Deal Or No Deal...");

         Game game = new Game();
         IBriefcaseService briefcaseService = new BriefcaseService(game);
         IPlayerService playerService = new PlayerService(briefcaseService);
         IGameRoundService gameRoundService = new GameRoundService(briefcaseService);
         GameInstance dealOrNoDeal = new GameInstance(briefcaseService, playerService, gameRoundService);
         dealOrNoDeal.Run(game);

         Console.ReadKey();
      }
   }
}
