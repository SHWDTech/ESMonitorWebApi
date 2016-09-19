namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_TaskNotice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long TaskId { get; set; }

        public int DevId { get; set; }

        [MaxLength(1000)]
        public byte[] Data { get; set; }

        public short? Length { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? UpdateTime { get; set; }
    }
}
