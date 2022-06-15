using System.ComponentModel.DataAnnotations;

namespace ICT.MM.DAL.DB.Models {

	public class Devices {
		
		[Key]
		public int Id { get; set; }
		
		//[ForeignKey(nameof(DeviceTypes))]
		public int Id_DeviceType { get; set; }

		[Required]
		[StringLength(32)]
		public string Name { get; set; }

		[Required]
		[StringLength(32)]
		public string Description { get; set; }

		public DeviceType DeviceType { get; set; }

		public DateTime ManufacturedDate { get; set; }

		public DateTime LastMaintenanceDate { get; set; }

		public DateTime MaintenanceDueDate { get; set; }

		public string ManufacturedBy { get; set; }

		public string CreatedBy { get; set; }

		public DateTime CreatedDate { get; set; }

		public string ModifiedBy { get; set; }

		public DateTime ModifiedDate { get; set; }

		public ICollection<ScenarioDevices> ScenarioDevices { get; set; }

	}

}