namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_DevAddr
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DevId { get; set; }

        [Key]
        [Column(Order = 1)]
        [MaxLength(4)]
        public byte[] NodeId { get; set; }
    }
}
