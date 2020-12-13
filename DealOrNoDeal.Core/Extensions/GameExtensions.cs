namespace DealOrNoDeal.Core.Data
{
   public static class GameExtensions
   {
      public static Game RemoveBriefcaseFromList(this Game game, Briefcase briefcase)
      {
         game.RemainingBriefcases.Remove(briefcase);
         game.RemovedBriefcases.Add(briefcase);
         return game;
      }
   }
}
