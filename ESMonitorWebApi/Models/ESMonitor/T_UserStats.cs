namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_UserStats
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int StatId { get; set; }
    }
}
