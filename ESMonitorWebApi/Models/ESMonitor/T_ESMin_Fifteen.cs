namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ESMin_Fifteen
    {
        public int Id { get; set; }

        public int StatId { get; set; }

        public double TP { get; set; }

        public double DB { get; set; }

        public double PM25 { get; set; }

        public double PM100 { get; set; }

        public double Temperature { get; set; }

        public double Humidity { get; set; }

        public DateTime UpdateTime { get; set; }
    }
}
