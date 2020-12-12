using System.Collections.Generic;

namespace DealOrNoDeal.Core.Interfaces
{
   public interface IGameRoundService
   {      
      void PlayRound(int roundNumber, int briefcaseToOpenCount);
      Dictionary<int, int> GetNumberOfBriefcasesToOpenPerRound();
   }
}
