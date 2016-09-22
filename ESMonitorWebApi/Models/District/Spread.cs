// ReSharper disable InconsistentNaming

using System.Collections.Generic;

namespace ESMonitorWebApi.Models.District
{
    public class Spread
    {
        public string city { get; set; }

        public List<Pie> pieCharts { get; set; } = new List<Pie>();

    }
    public class Pie
    {
        public int projectType { get; set; }

        public int good { get; set; }

        public int normal { get; set; }

        public int bad { get; set; }
    }
}