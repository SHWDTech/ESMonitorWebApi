namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Offset
    {
        [Key]
        [Column(Order = 0)]
        public double OffSetCpm { get; set; }

        [Key]
        [Column(Order = 1)]
        public double OffSetPlusCpm { get; set; }

        [Key]
        [Column(Order = 2)]
        public double OffSetNoise { get; set; }

        [Key]
        [Column(Order = 3)]
        public double OffSetPlusNoise { get; set; }
    }
}
