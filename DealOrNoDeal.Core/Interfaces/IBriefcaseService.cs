﻿using DealOrNoDeal.Core.Data;
using System.Collections.Generic;

namespace DealOrNoDeal.Core
{
   public interface IBriefcaseService
   {
      List<Briefcase> RandomizeBriefcaseValues();
      Briefcase LoadBriefcase(int? briefcaseNumber);
      bool ValidateBriefcaseNumberIfExists(List<Briefcase> remainingBriefcase, int briefcaseNumber);
   }
}
