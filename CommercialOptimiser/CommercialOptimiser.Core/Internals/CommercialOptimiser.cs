using System.Collections.Generic;
using Combinatorics.Collections;
using CommercialOptimiser.Models;
using System.Linq;

namespace CommercialOptimiser.Core
{
    internal class CommercialOptimiser : ICommercialOptimiser
    {
        #region Variables

        readonly IList<Commercial> _commercials;
        readonly IList<Break> _breaksRatings;

        #endregion

        #region Ctor

        public CommercialOptimiser(IList<Commercial> commercials, IList<Break> breaksRatings)
        {
            _commercials = commercials;
            _breaksRatings = breaksRatings;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Find the optimised commercial placements for the 3 given breaks.
        /// </summary>
        /// <param name="adLimitForBreak1"></param>
        /// <param name="adLimitForBreak2"></param>
        /// <param name="adLimitForBreak3"></param>
        /// <returns>The group typed list which contains the maximum rating obtained and the list of combinations of the commercials</returns>
        public IGrouping<int, (IReadOnlyList<Commercial> Break1, IReadOnlyList<Commercial> Break2, IReadOnlyList<Commercial> Break3)> ObtainOptimisedRatings(int adLimitForBreak1, int adLimitForBreak2, int adLimitForBreak3)
        {
            if (adLimitForBreak1 < 1 || adLimitForBreak2 < 1 || adLimitForBreak3 < 1 || (adLimitForBreak1 + adLimitForBreak2 + adLimitForBreak3) > _commercials.Count)
                throw new InvalidInputException("Invalid input!");

            var C1 = new Combinations<Commercial>(_commercials, adLimitForBreak1, GenerateOption.WithoutRepetition);
            var C2 = new Combinations<Commercial>(_commercials, adLimitForBreak2, GenerateOption.WithoutRepetition);
            var C3 = new Combinations<Commercial>(_commercials, adLimitForBreak3, GenerateOption.WithoutRepetition);

            var forBreak1 = ApplyFilters(C1, BreakType.Break1);
            var forBreak2 = ApplyFilters(C2, BreakType.Break2);
            var forBreak3 = ApplyFilters(C3, BreakType.Break3);
            
            var uniqueSet = new List<(IReadOnlyList<Commercial> Break1, IReadOnlyList<Commercial> Break2, IReadOnlyList<Commercial> Break3)>();
            foreach (var break1 in forBreak1)
            {
                foreach (var break2 in forBreak2)
                {
                    foreach (var break3 in forBreak3)
                    {
                        if (break1.NotEquals(break2) && break1.NotEquals(break3) && break2.NotEquals(break3))
                            uniqueSet.Add((break1, break2, break3));
                    }
                }
            }

            var max = uniqueSet.GroupBy(item => item.Break1.Sum(c => _breaksRatings.FirstOrDefault(b=> b.Type == BreakType.Break1 && b.Demographic == c.Demographic).Rating) +
                                        item.Break2.Sum(c => _breaksRatings.FirstOrDefault(b => b.Type == BreakType.Break2 && b.Demographic == c.Demographic).Rating) +
                                        item.Break3.Sum(c => _breaksRatings.FirstOrDefault(b => b.Type == BreakType.Break3 && b.Demographic == c.Demographic).Rating)).OrderByDescending(x => x.Key).FirstOrDefault();
            return max;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Apply the given filters
        /// Filter 1 - Finance type commercials cannot go into Break 2
        /// Filter 2 - Commercials of the same type cannot be next to each other within a break
        /// </summary>
        /// <param name="adBreak"></param>
        /// <param name="breakType"></param>
        /// <returns>Filtered list of commercials</returns>
        private IEnumerable<IReadOnlyList<Commercial>> ApplyFilters(Combinations<Commercial> adBreak, BreakType breakType)
        {
            var filteredBreak = new List<IReadOnlyList<Commercial>>();

            foreach (var commercial in adBreak)
            {
                if (commercial.Count > 1)
                {
                    var enumerator = commercial.GetEnumerator();
                    Commercial currentCommercial = null;
                    bool isVaild = false;
                    do
                    {
                        if (currentCommercial != null)
                        {
                            if (currentCommercial.Type != enumerator.Current.Type)
                                isVaild = true;
                            else
                            {
                                isVaild = false;
                                break;
                            }                             
                        }
                        currentCommercial = enumerator.Current;
                    }
                    while (enumerator.MoveNext());

                    if (isVaild)
                        filteredBreak.Add(commercial);                   
                }
                else
                    filteredBreak.Add(commercial);
            }

            return breakType == BreakType.Break2 ? filteredBreak.Where(x => !x.Any(y => y.Type == CommercialTypes.Finance)) : filteredBreak;
        }

        #endregion

    }
}
