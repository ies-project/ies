using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ICT.DAL.DB
{
    public class ICTDbContext : DbContext{

        public DbSet<DeviceType> DeviceTypes { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaType> AreaTypes { get; set; }
        public DbSet<Report> Reports { get; set; }

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
