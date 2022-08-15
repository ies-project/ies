using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICT.DAL.DB
{
    public class ICTDbContext : DbContext
    {

        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaType> AreaTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SurroundingArea> SurroundingAreas { get; set; }
        public DbSet<FireHoseReel> FireHoseReels { get; set; }
        public DbSet<Extinguisher> Extinguishers { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<DeviceSubmittedAction> DeviceSubmittedActions { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceRequestedRead> DeviceRequestedReads { get; set; }
        public DbSet<ReportDevice> ReportDevices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ICTDatabase"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(5), errorNumbersToAdd: null);
                }
                );
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defined database relations
            DeviceType.ConfigureRelations(modelBuilder);
            Action.ConfigureRelations(modelBuilder);
            Report.ConfigureRelations(modelBuilder);
            Building.ConfigureRelations(modelBuilder);
            AreaType.ConfigureRelations(modelBuilder);
            Area.ConfigureRelations(modelBuilder);
            Device.ConfigureRelations(modelBuilder);
            // Defined primary key
            ReportDevice.ConfigureRelations(modelBuilder);
            SurroundingArea.ConfigureRelations(modelBuilder);

        }
    }
}
