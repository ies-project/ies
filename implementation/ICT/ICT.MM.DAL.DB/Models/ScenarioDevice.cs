using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel.DataAnnotations;

namespace ICT.MM.DAL.DB
{
    /// <summary>
    /// ScenarioDevice class
    /// </summary>
    public class ScenarioDevice {
        /// <summary>
        /// Primary key of Scenarios
        /// </summary>
        public int Id_Scenario { get; set; }

        /// <summary>
        /// Primary key and Foreign Key from table Devices
        /// </summary>
        public int Id_Device { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime? ManufacturedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastMaintenanceDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? MaintenanceDueDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(64)]
        public string OriginalState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(64)]
        public string CurrentState { get; set; }

        public Scenario Scenario { get; set; }
        public Device Device { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Defined primary key
            modelBuilder.Entity<ScenarioDevice>()
                .HasKey(sd => new { sd.Id_Scenario, sd.Id_Device });
        }
    }
}
