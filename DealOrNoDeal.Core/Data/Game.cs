using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Core
{
   internal class Game
   {
      public List<Briefcase> RemainingBriefcases { get; set; }
      public List<Briefcase> RemovedBriefcases { get; set; }
      public List<double> BankerOffers { get; set; }
   }
}
