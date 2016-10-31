namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Camera
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string CameraName { get; set; }

        public int DevId { get; set; }

        [Required]
        [StringLength(50)]
        public string DnsAddr { get; set; }

        [Required]
        [StringLength(25)]
        public string Port { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string PassWord { get; set; }

        public int CameraId { get; set; }

        [Required]
        [StringLength(25)]
        public string Type { get; set; }
    }
}
