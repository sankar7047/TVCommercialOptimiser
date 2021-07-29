using System;
using System.ComponentModel;

namespace CommercialOptimiser.Models
{
    public enum Demographics
    {
        [Description("W 25-30")]
        W_25_30,
        [Description("M 18-35")]
        M_18_35,
        [Description("T 18-40")]
        T_18_40
    }

    public class DemographicsAttribute : Attribute
    {
        public DemographicsAttribute()
        {

        }

        public string Name { get; set; }
        public int Break1 { get; set; }
        public int Break2 { get; set; }
        public int Break3 { get; set; }
    }
}
