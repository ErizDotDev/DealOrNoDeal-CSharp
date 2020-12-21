using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Core
{
   public interface IGameRoundService
   {
      void Initialize(Game game);
      Game PlayRound(int roundNumber, int briefcaseToOpenCount);
      Dictionary<int, int> GetNumberOfBriefcasesToOpenPerRound();
   }
}
