using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICT.DAL.DB
{
    public class ICTDbContext : DbContext{

        public DbSet<DeviceType> DeviceTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ICTDatabase"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DeviceType.ConfigureRelations(modelBuilder);
            ReportDevice.ConfigureRelations(modelBuilder);
            // ac = Action
            // ar = Areas
            // at = AreaType
            // bl = Building
            // dv = Device
            // dt = DeviceType
            // drr = DeviceRequestedReads
            // dsa = DeviceSubmittedActions
            // ex = Extinguishers
            // fh = FireHoseReel
            // rp = Report
            // rd = ReportDevice
            // sa = SurroundingArea

            //Relationship from Building to Areas
            //modelBuilder.Entity<Area>()
            //    .HasOne(ar => ar.Building)
            //    .WithMany(bl => bl.Areas)
            //    .HasForeignKey(ar => ar.Id_Building);

            ////Relationship from AreaType to Areas
            //modelBuilder.Entity<Area>()
            //    .HasOne(ar => ar.AreaType)
            //    .WithMany(at => at.Areas)
            //    .HasForeignKey(ar => ar.Id_Type);

            ////Relationship from Area to Devices
            //modelBuilder.Entity<Device>()
            //    .HasOne(dv => dv.Area)
            //    .WithMany(ar => ar.Devices)
            //    .HasForeignKey(dv => dv.Id_Area);

            ////Relationship from Area to Extinguisher
            //modelBuilder.Entity<Extinguisher>()
            //    .HasOne(ex => ex.Area)
            //    .WithMany(ar => ar.Extinguishers)
            //    .HasForeignKey(ex => ex.Id_Area);

            ////Relationship from Area to FireHoseReel
            //modelBuilder.Entity<FireHoseReel>()
            //    .HasOne(fh => fh.Area)
            //    .WithMany(ar => ar.FireHoseReels)
            //    .HasForeignKey(fh => fh.Id_Area);

            ////Relationship from Area to SurroundingArea (M - N)
            //modelBuilder.Entity<SurroundingArea>()
            //    .HasOne(sa => sa.Area)
            //    .WithMany(ar => ar.SurroundingAreas)
            //    .HasForeignKey(sa => sa.Id_Area);

            ////Relationship from SurroundingArea to Area (M - N)
            //modelBuilder.Entity<Area>()
            //    .HasOne(ar => ar.SurroundingArea)
            //    .WithMany(sa => sa.Areas);

            ////Relationship from DeviceType to Devices
            //modelBuilder.Entity<Device>()
            //    .HasOne(dv => dv.DeviceType)
            //    .WithMany(dt => dt.Devices)
            //    .HasForeignKey(dv => dv.Id_DeviceType);

            ////Relationship from Device to DeviceRequestedReads
            //modelBuilder.Entity<DeviceRequestedRead>()
            //    .HasOne(drr => drr.Device)
            //    .WithMany(dv => dv.DeviceRequestedReads)
            //    .HasForeignKey(drr => drr.Id_Device);



            ////Relationship from Action to DeviceSubmittedActions
            //modelBuilder.Entity<DeviceSubmittedAction>()
            //     .HasOne(dsa => dsa.Action)
            //     .WithMany(ac => ac.DeviceSubmittedActions)
            //     .HasForeignKey(dsa => dsa.Id_Action);
        }
    }
}
