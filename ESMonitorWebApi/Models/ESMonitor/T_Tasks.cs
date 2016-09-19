namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Tasks
    {
        [Key]
        public long TaskId { get; set; }

        public byte Status { get; set; }

        public DateTime? SendTime { get; set; }

        public int CmdType { get; set; }

        public int CmdByte { get; set; }

        public int DevId { get; set; }

        [Required]
        [MaxLength(1000)]
        public byte[] Data { get; set; }

        public short Length { get; set; }
    }
}
