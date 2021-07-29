using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Threading;
using CommercialOptimiser.Models;

namespace CommercialOptimiser.Core
{
	public static class Extensions
	{
		public static bool NotEquals(this IReadOnlyList<Commercial> commercials1, IReadOnlyList<Commercial> commercials2)
        {
            foreach (var commercial in commercials1)
            {
				if (commercials2.Any(c => c == commercial))
					return false;
            }

			return true;
        }
	}
}
