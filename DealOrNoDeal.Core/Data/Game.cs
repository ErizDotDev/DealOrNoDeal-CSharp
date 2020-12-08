using System.Collections.Generic;

namespace DealOrNoDeal.Core.Data
{
   public class Game
   {
      public List<Briefcase> RemainingBriefcases { get; set; }
      public List<Briefcase> RemovedBriefcases { get; set; }
      public List<double> BankerOffers { get; set; }
   }
}
