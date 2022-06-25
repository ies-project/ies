using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Action class
    /// </summary>
    public class Action
    {
        /// <summary>
        /// Primary key of Action
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Action
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the Action
        /// </summary>
        public string Description { get; set; }

        public ICollection<DeviceSubmittedAction> DeviceSubmittedActions { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Relationship from Action to DeviceSubmittedActions
            modelBuilder.Entity<DeviceSubmittedAction>()
                 .HasOne(dsa => dsa.Action)
                 .WithMany(ac => ac.DeviceSubmittedActions)
                 .HasForeignKey(dsa => dsa.Id_Action);
        }

    }
}




