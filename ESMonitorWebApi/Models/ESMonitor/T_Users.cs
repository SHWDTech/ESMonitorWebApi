namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Users
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(32)]
        public string Pwd { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(128)]
        public string Email { get; set; }

        public byte? Status { get; set; }

        public DateTime RegTime { get; set; }

        public int RoleId { get; set; }

        public DateTime? LastTime { get; set; }

        public DateTime? NowTime { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
