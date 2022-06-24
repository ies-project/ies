using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
    /// <summary>
    /// DeviceType class
    /// </summary>
    public class DeviceType
    {
        /// <summary>
        /// Primary key of DeviceType
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the DeviceType
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the DeviceType
        /// </summary>
        public string Description { get; set; }

        public ICollection<Device> Devices { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Relationship from DeviceType to Devices
            modelBuilder.Entity<Device>()
                .HasOne(d => d.DeviceType)
                .WithMany(dt => dt.Devices)
                .HasForeignKey(d => d.Id_DeviceType);
        }

    }
}




