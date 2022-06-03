using System;
using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
	/// <summary>
    /// Device Class
    /// </summary>
	public class Device
	{
		/// <summary>
        /// Primary Key for Devices
        /// </summary>
        [Key]
		public int Id { get; set; }
		/// <summary>
        /// Foreign Key from Area
        /// </summary>
		public int Id_Area { get; set; }
		public virtual Area Area { get; set; }
		/// <summary>
        /// Foreign Key from Device Type
        /// </summary>
		public int Id_DeviceType { get; set; }
		public virtual DeviceType DeviceType { get; set; }
		/// <summary>
        /// Name of the Device
        /// 32 Character Limit
        /// </summary>
		public string Name { get; set; }
		/// <summary>
        /// Description for the Device
        /// 64 Character Limit
        /// </summary>
		public string Description { get; set; }
		/// <summary>
        /// Current state for the device
        /// 64 Character Limit
        /// </summary>
		public string State { get; set; }
		/// <summary>
        /// Date of Device Manufacture
        /// </summary>
		public DateTime ManufacturedDate { get; set; }
		/// <summary>
        /// Date of Last Maintenance
        /// </summary>
		public DateTime LastMaintenanceDate { get; set; }
		/// <summary>
        /// Date of next Maintenance
        /// </summary>
		public DateTime MaintenanceDueDate { get; set; }
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
		public DateTime CreatedDate { get; set; }
		/// <summary>
        /// User that last modified the Device settings
        /// </summary>
		public string ModifiedBy { get; set; }
		/// <summary>
        /// Date and time the device was last modified
        /// </summary>
		public DateTime ModifiedDate { get; set; }

	}
}

