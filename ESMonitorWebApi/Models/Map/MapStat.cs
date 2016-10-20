using System;

namespace ESMonitorWebApi.Models.Map
{
    public class MapStat
    {
        public int id { get; set; }

        public string name { get; set; }

        public string time { get; set; }

        public double tsp { get; set; }

        public int rate { get; set; }

        public double windSpeed { get; set; }

        public double windDirection { get; set; }

        public double temperature { get; set; }

        public double humidity { get; set; }

        public string longitude { get; set; }

        public string latitude { get; set; }
    }
}