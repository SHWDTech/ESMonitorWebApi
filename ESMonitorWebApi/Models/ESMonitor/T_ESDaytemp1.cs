namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ESDaytemp1
    {
        [Key]
        [Column(Order = 0)]
        public long Id { get; set; }

        [StringLength(10)]
        public string UpdateTime { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int devID { get; set; }

        public int? StatId { get; set; }

        [StringLength(20)]
        public string Country { get; set; }

        public double? TP { get; set; }

        public double? DB { get; set; }

        public double? WindSpeed { get; set; }

        public double? WindDirection { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }
    }
}
