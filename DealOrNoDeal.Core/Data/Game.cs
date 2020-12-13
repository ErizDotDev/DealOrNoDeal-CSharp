using System.Collections.Generic;

namespace DealOrNoDeal.Core.Data
{
   public class Game
   {
      public List<Briefcase> RemainingBriefcases { get; set; } = new List<Briefcase>();
      public List<Briefcase> RemovedBriefcases { get; set; } = new List<Briefcase>();
      public List<double> BankerOffers { get; set; } = new List<double>();
   }
}
