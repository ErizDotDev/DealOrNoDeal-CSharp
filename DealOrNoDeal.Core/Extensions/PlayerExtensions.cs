namespace DealOrNoDeal.Core.Data
{
   public static class PlayerExtensions
   {
      public static bool IsValid(this Player player)
      {
         return player != null            
            && player?.SelectedBriefcase != null
            && !string.IsNullOrEmpty(player?.Name);
      }
   }
}
