namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_SysConfig
    {
        [Key]
        public Guid ConfigId { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfigType { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfigName { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfigValue { get; set; }
    }
}
