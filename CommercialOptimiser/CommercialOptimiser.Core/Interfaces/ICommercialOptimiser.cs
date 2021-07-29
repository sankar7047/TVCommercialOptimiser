using System.Collections.Generic;
using System.Linq;
using CommercialOptimiser.Models;

namespace CommercialOptimiser.Core
{
    public interface ICommercialOptimiser
    {
        /// <summary>
        /// Find the optimised commercial placements for the 3 given breaks.
        /// </summary>
        /// <param name="adLimitForBreak1"></param>
        /// <param name="adLimitForBreak2"></param>
        /// <param name="adLimitForBreak3"></param>
        /// <returns>The group typed list which contains the maximum rating obtained and the list of combinations of the commercials</returns>
        IGrouping<int, (IReadOnlyList<Commercial> Break1, IReadOnlyList<Commercial> Break2, IReadOnlyList<Commercial> Break3)> ObtainOptimisedRatings(int adLimitForBreak1, int adLimitForBreak2, int adLimitForBreak3);
    }
}
