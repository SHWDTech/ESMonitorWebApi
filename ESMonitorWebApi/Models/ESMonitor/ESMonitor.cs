namespace ESMonitorWebApi.Models.ESMonitor
{
    using System.Data.Entity;

    public class EsMonitor : DbContext
    {
        public EsMonitor()
            : base("name=EsMonitor")
        {
        }

        public EsMonitor(string connString) : base(connString)
        {
            
        }

        public virtual DbSet<T_AlarmType> AlarmType { get; set; }
        public virtual DbSet<T_Camera> Camera { get; set; }
        public virtual DbSet<T_Country> Country { get; set; }
        public virtual DbSet<T_DevAddr> DevAddr { get; set; }
        public virtual DbSet<T_Devs> Devs { get; set; }
        public virtual DbSet<T_ESDay> EsDay { get; set; }
        public virtual DbSet<T_ESHour> EsHour { get; set; }
        public virtual DbSet<T_ESMin> EsMin { get; set; }
        public virtual DbSet<T_ESMin_Fifteen> EsMinFifteen { get; set; }
        public virtual DbSet<T_Files> Files { get; set; }
        public virtual DbSet<T_GroupModules> GroupModules { get; set; }
        public virtual DbSet<T_Photos> Photos { get; set; }
        public virtual DbSet<T_Province> Province { get; set; }
        public virtual DbSet<T_Stage> Stage { get; set; }
        public virtual DbSet<T_Stats> Stats { get; set; }
        public virtual DbSet<T_SysConfig> SysConfig { get; set; }
        public virtual DbSet<T_TaskNotice> TaskNotice { get; set; }
        public virtual DbSet<T_Tasks> Tasks { get; set; }
        public virtual DbSet<T_UserAuthority> UserAuthority { get; set; }
        public virtual DbSet<T_UserGroup> UserGroup { get; set; }
        public virtual DbSet<T_UserInGroups> UserInGroups { get; set; }
        public virtual DbSet<T_Users> Users { get; set; }
        public virtual DbSet<T_UserStats> UserStats { get; set; }
        public virtual DbSet<T_Alarms> Alarms { get; set; }
        public virtual DbSet<T_ESDaytemp1> EsDaytemp1 { get; set; }
        public virtual DbSet<T_Offset> Offset { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T_AlarmType>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<T_AlarmType>()
                .HasMany(e => e.T_Stats)
                .WithOptional(e => e.T_AlarmType)
                .HasForeignKey(e => e.AlarmType);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.CameraName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.DnsAddr)
                .IsUnicode(false);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.Port)
                .IsUnicode(false);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<T_Camera>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<T_Country>()
                .Property(e => e.Country)
                .IsFixedLength();

            modelBuilder.Entity<T_Country>()
                .HasMany(e => e.T_Stats)
                .WithRequired(e => e.T_Country)
                .HasForeignKey(e => e.Country)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_DevAddr>()
                .Property(e => e.NodeId)
                .IsFixedLength();

            modelBuilder.Entity<T_Devs>()
                .Property(e => e.VideoURL)
                .IsUnicode(false);

            modelBuilder.Entity<T_Devs>()
                .Property(e => e.OuterCode)
                .IsFixedLength();

            modelBuilder.Entity<T_ESDay>()
                .Property(e => e.DataStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ESDay>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<T_ESHour>()
                .Property(e => e.DataStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ESHour>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<T_ESMin>()
                .Property(e => e.DataStatus)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<T_ESMin>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<T_Files>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Files>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<T_Photos>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Province>()
                .Property(e => e.Province)
                .IsFixedLength();

            modelBuilder.Entity<T_Province>()
                .HasMany(e => e.T_Country)
                .WithRequired(e => e.T_Province)
                .HasForeignKey(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Stage>()
                .Property(e => e.StageName)
                .IsFixedLength();

            modelBuilder.Entity<T_Stage>()
                .HasOptional(e => e.T_Stage1)
                .WithRequired(e => e.T_Stage2);

            modelBuilder.Entity<T_Stage>()
                .HasMany(e => e.T_Stats)
                .WithRequired(e => e.T_Stage)
                .HasForeignKey(e => e.Stage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.StatCode)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.StatName)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.ChargeMan)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Telepone)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Department)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<T_Stats>()
                .Property(e => e.ProType)
                .IsUnicode(false);

            modelBuilder.Entity<T_SysConfig>()
                .Property(e => e.ConfigType)
                .IsFixedLength();

            modelBuilder.Entity<T_SysConfig>()
                .Property(e => e.ConfigName)
                .IsFixedLength();

            modelBuilder.Entity<T_SysConfig>()
                .Property(e => e.ConfigValue)
                .IsFixedLength();

            modelBuilder.Entity<T_TaskNotice>()
                .Property(e => e.Data)
                .IsFixedLength();

            modelBuilder.Entity<T_Tasks>()
                .Property(e => e.Data)
                .IsFixedLength();

            modelBuilder.Entity<T_Alarms>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<T_ESDaytemp1>()
                .Property(e => e.UpdateTime)
                .IsUnicode(false);

            modelBuilder.Entity<T_ESDaytemp1>()
                .Property(e => e.Country)
                .IsUnicode(false);
        }
    }
}
