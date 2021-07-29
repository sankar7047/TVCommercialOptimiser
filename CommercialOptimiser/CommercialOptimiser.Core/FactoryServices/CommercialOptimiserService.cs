using System;
using System.Collections.Generic;
using CommercialOptimiser.Models;

namespace CommercialOptimiser.Core
{
    public class CommercialOptimiserService
    {
        /// <summary>
        /// Gets the instance of ICommercialOptimiser
        /// </summary>
        /// <param name="commercials"></param>
        /// <param name="breaksRatings"></param>
        /// <returns>Instance of ICommercialOptimiser</returns>
        public static ICommercialOptimiser GetCommercialOptimiser(IList<Commercial> commercials, IList<Break> breaksRatings)
        {
            return new CommercialOptimiser(commercials, breaksRatings);
        }
    }
}
