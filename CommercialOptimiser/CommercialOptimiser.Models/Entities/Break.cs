using System;
namespace CommercialOptimiser.Models
{
    public class Break
    {
        public BreakType Type { get; set; }
        public Demographics Demographic { get; set; }
        public int Rating { get; set; }
    }
}
