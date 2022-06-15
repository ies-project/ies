using ICT.MM.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ICT.MM.DAL.DB {
    public class ContextDB : DbContext{

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScenarioDevices>()
                .HasKey(sd => new { sd.Id_Scenario, sd.Id_Device });

            modelBuilder.Entity<ScenarioDevices>()
                .HasOne(sd => sd.scen)
                .WithMany(s => s.scenDev)
                .HasForeignKey(sd => sd.Id_Scenario);

            modelBuilder.Entity<ScenarioDevices>()
                .HasOne(sd => sd.devi)
                .WithMany(d => d.scenDev)
                .HasForeignKey(sd => sd.Id_Device);


        }
    }
}
