using System;
namespace CommercialOptimiser.Models
{
    public class Commercial : IEquatable<Commercial>
    {
        public string Name { get; set; }
        public CommercialTypes Type { get; set; }
        public Demographics Demographic { get; set; }

        public bool Equals(Commercial other)
        {
            return Name == other.Name;
        }
    }
}
