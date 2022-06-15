using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ICT.MM.DAL.DB.Models {
    /// <summary>
    /// 
    /// </summary>
    public class ScenarioDevices {

        //Foreign Key To Scenarios
        [Key]
        public int Id_Scenario { get; set; }

        //Foreign Key To Devices
        [Key]
        public int Id_Device { get; set; }

        public Scenario scen { get; set; }

        public Device devi { get; set; }


        [Required]
        public DateTime ManufacturedDate { get; set; }

        public DateTime LastManteinanceDate { get; set; }

        public DateTime ManteinanceDueDate { get; set; }

        [Required]
        [StringLength(64)]
        public string OriginalState { get; set; }

        [Required]
        [StringLength(64)]
        public string CurrentState { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScenarioDevices>()
                .HasKey(sd => new { sd.Id_Scenario, sd.Id_Device });
            modelBuilder.Entity<ScenarioDevices>()
                .HasOne(sd => sd.Scenario)
                .WithMany(s => s.Scenario)
                .HasForeignKey(sd => sd.Id);
            modelBuilder.Entity<ScenarioDevices>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);
        }
    }
}
