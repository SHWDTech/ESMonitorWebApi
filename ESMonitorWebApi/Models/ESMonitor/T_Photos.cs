namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Photos
    {
        public long ID { get; set; }

        public int DevId { get; set; }

        public DateTime AddTime { get; set; }

        [Required]
        [StringLength(100)]
        public string FileName { get; set; }
    }
}
