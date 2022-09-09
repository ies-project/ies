using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.MM.DAL.DB
{
	/// <summary>
	/// Device Class
	/// </summary>
	public class Device {
		/// <summary>
		/// Primary Key for Devices
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Foreign Key from Device Type
		/// </summary>
		public int Id_DeviceType { get; set; }
		/// <summary>
		/// Name of the Device
		/// 32 Character Limit
		/// </summary>
		[Required]
		[StringLength(32)]
		public string Name { get; set; }
		/// <summary>
		/// Description for the Device
		/// 64 Character Limit
		/// </summary>
		[Required]
		[StringLength(32)]
		public string Description { get; set; }
		/// <summary>
		/// Date of Device Manufacture
		/// </summary>
		public DateTime? ManufacturedDate { get; set; }
		/// <summary>
		/// Date of Last Maintenance
		/// </summary>
		public DateTime? LastMaintenanceDate { get; set; }
		/// <summary>
		/// Date of next Maintenance
		/// </summary>
		public DateTime? MaintenanceDueDate { get; set; }
		/// <summary>
		/// Name of the Device Manufacturer
		/// </summary>
		public string ManufacturedBy { get; set; }
		/// <summary>
		/// User that added the Device to the system
		/// </summary>
		public string CreatedBy { get; set; }
		/// <summary>
		/// Date and time the Device was added to the system
		/// </summary>
		public DateTime? CreatedDate { get; set; }
		/// <summary>
		/// User that last modified the Device settings
		/// </summary>
		public string ModifiedBy { get; set; }
		/// <summary>
		/// Date and time the device was last modified
		/// </summary>
		public DateTime? ModifiedDate { get; set; }

		public ICollection<ScenarioDevice> ScenarioDevices { get; set; }
		public DeviceType DeviceType { get; set; }

		public static void ConfigureRelations(ModelBuilder modelBuilder)
		{
			//Relationship from Device to ScenarioDevices
			modelBuilder.Entity<ScenarioDevice>()
				.HasOne(d => d.Device)
				.WithMany(dt => dt.ScenarioDevices)
				.HasForeignKey(d => d.Id_Device);
		}

	}

}