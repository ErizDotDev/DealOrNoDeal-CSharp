using DealOrNoDeal.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealOrNoDeal.Core
{
   public class GameInstance
   {
      private IBriefcaseService _briefcaseService;
      private IPlayerService _playerService;

      private List<Briefcase> briefcases;
      private Player player;

      public GameInstance(IBriefcaseService briefcaseService, IPlayerService playerService)
      {
         _briefcaseService = briefcaseService;
         _playerService = playerService;
      }

      public void Run()
      {         
         briefcases = _briefcaseService.RandomizeBriefcaseValues();
         
      }
   }
}
