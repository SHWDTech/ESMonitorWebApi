namespace ESMonitorWebApi.Models.ESMonitor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_AlarmType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_AlarmType()
        {
            T_Stats = new HashSet<T_Stats>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public double? DustRange { get; set; }

        public double? DbRange { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<T_Stats> T_Stats { get; set; }
    }
}
