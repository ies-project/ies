using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace ICT.MM.DAL.DB
{
    /// <summary>
    /// 
    /// </summary>
    public class Scenario {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(64)]
        public String Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        [StringLength(64)]
        public String Description { get; set; }

        public ICollection<ScenarioDevice> ScenarioDevices { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Relationship from Scenario to ScenarioDevices
            modelBuilder.Entity<ScenarioDevice>()
                .HasOne(d => d.Scenario)
                .WithMany(dt => dt.ScenarioDevices)
                .HasForeignKey(d => d.Id_Scenario);
        }
    }
}
