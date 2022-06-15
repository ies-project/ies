using ICT.MM.DAL.DB.Models;
using Microsoft.EntityFrameworkCore;


namespace ICT.MM.DAL.DB {
    public class ContextDB : DbContext{
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Primary Key composite of ScenarioDevices
            modelBuilder.Entity<ScenarioDevice>()
                .HasKey(sd => new { sd.Id_Scenario, sd.Id_Device });

            //Foreign Key from ScenarioDevices to Scenarios
            modelBuilder.Entity<ScenarioDevice>()
                .HasOne(sd => sd.Scenario)
                .WithMany(s => s.ScenarioDevices)
                .HasForeignKey(sd => sd.Id_Scenario);

            //Foreign Key from ScenarioDevices to Devices
            modelBuilder.Entity<ScenarioDevice>()
                .HasOne(sd => sd.Device)
                .WithMany(d => d.ScenarioDevices)
                .HasForeignKey(sd => sd.Id_Device);
            
            // Foreign Key from Devices to DevicesTypes
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceType)
                .WithMany(dt => dt.Devices)
                .HasForeignKey(d => d.Id_DeviceType);


        }
    }
}
