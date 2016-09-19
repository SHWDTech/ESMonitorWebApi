namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Camera
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string CameraName { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DevId { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string DnsAddr { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(25)]
        public string Port { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string PassWord { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CameraId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(25)]
        public string Type { get; set; }
    }
}
