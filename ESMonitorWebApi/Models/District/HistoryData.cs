using System.Collections.Generic;

namespace ESMonitorWebApi.Models.District
{
    public class HistoryData
    {
        public int stat { get; set; }

        public List<MonitorData> data { get; set; } = new List<MonitorData>();
    }

    public class MonitorData
    {
        public string date { get; set; }

        public double tsp { get; set; }

        public double windSpeed { get; set; }

        public double windDirection { get; set; }

        public double temperature { get; set; }

        public double humidity { get; set; }

        public int rate { get; set; }
    }
}