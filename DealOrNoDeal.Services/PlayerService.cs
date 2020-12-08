using DealOrNoDeal.Core.Data;
using DealOrNoDeal.Core.Interfaces;
using System;

namespace DealOrNoDeal.Services
{
   public class PlayerService : IPlayerService
   {
      private IBriefcaseService _briefcaseService;

      public PlayerService(IBriefcaseService briefcaseService)
      {
         _briefcaseService = briefcaseService;
      }

      public Player GetPlayerDetails()
      {
         Player player = null;

         while (player.IsNotValid())
         {
            player = new Player
            {
               Name = GetPlayerName(),
               SelectedBriefcase = _briefcaseService.LoadBriefcase(GetPlayerBriefcase())
            };
         }

         return player;
      }

      private string GetPlayerName()
      {
         Console.Write("Enter your name: ");
         return Console.ReadLine();
      }

      private int GetPlayerBriefcase()
      {
         Console.Write("Select a briefcase number (from 1 to 26): ");
         return GetPlayerBriefcaseValue();
      }

      private int GetPlayerBriefcaseValue()
      {
         try
         {
            string selectedBriefcase = Console.ReadLine();
            int selectedBriefcaseNumber;

            if (int.TryParse(selectedBriefcase, out selectedBriefcaseNumber))
            {
               return selectedBriefcaseNumber;
            }

            throw new Exception();
         }
         catch (Exception e)
         {
            Console.WriteLine("Please select a valid number");
         }

         return 0;
      }
   }
}
