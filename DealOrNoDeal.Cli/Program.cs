using DealOrNoDeal.Core;
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

         IBriefcaseService briefcaseService = new BriefcaseService();
         IPlayerService playerService = new PlayerService(briefcaseService);
         IGameRoundService gameRoundService = new GameRoundService();
         GameInstance dealOrNoDeal = new GameInstance(briefcaseService, playerService, gameRoundService);
         dealOrNoDeal.Run();

         Console.ReadKey();
      }
   }
}
