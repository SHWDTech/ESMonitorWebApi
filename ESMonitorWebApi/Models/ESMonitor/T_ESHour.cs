namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ESHour
    {
        public long Id { get; set; }

        public int StatId { get; set; }

        public double TP { get; set; }

        public double DB { get; set; }

        public double? PM25 { get; set; }

        public double? PM100 { get; set; }

        public double? VOCs { get; set; }

        public DateTime UpdateTime { get; set; }

        [Required]
        [StringLength(1)]
        public string DataStatus { get; set; }

        public int ValidDataNum { get; set; }

        public int DevId { get; set; }

        [StringLength(20)]
        public string Country { get; set; }
    }
}
