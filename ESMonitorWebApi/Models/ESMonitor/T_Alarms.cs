namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Alarms
    {
        public int Id { get; set; }

        public int? StatId { get; set; }

        public int? DevId { get; set; }

        public short? DustType { get; set; }

        public double? FaultVal { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        public bool IsReaded { get; set; }
    }
}
