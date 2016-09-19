namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Files
    {
        public int Id { get; set; }

        public int? StatId { get; set; }

        public DateTime? CapTime { get; set; }

        public byte? Type { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string Path { get; set; }
    }
}
