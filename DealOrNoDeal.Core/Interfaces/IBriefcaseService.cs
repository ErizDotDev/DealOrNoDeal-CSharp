using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Core.Interfaces
{
   public interface IBriefcaseService
   {
      List<Briefcase> RandomizeBriefcaseValues();
      Briefcase LoadBriefcase(int? briefcaseNumber);
   }
}
