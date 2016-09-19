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

        public int rate { get; set; }
    }
}