using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Core.Interfaces
{
   public interface IBankerOfferService
   {
      double CalculateOffer(List<Briefcase> remainingBriefcases, int roundNumber);
   }
}
