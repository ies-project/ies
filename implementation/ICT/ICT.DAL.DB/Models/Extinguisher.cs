﻿using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
	/// <summary>
	/// Extinguishers class
	/// </summary>
	public class Extinguisher
	{
		/// <summary>
		/// Primary key of Extinguisher
		/// </summary>
		[Key]
		public int Id { get; set; }

		/// <summary>
		/// Foreign key from table Area
		/// </summary>
		public int Id_Area { get; set; }

		/// <summary>
		/// Type of Extinguisher
		/// </summary>
		[StringLength(64)]
		public string Type { get; set; }

		/// <summary>
		/// Description of the Extinguisher
		/// </summary>
		[StringLength(64)]
		public string Description { get; set; }

		/// <summary>
		/// Extinguisher Manufactured Date 
		/// </summary>
		public DateTime ManufacturedDate { get; set; }

		/// <summary>
		/// Extinguisher Last Maintenance Date 
		/// </summary>
		public DateTime LastMaintenanceDate { get; set; }

		/// <summary>
		/// Extinguisher Maintenance Due Date 
		/// </summary>
		public DateTime MaintenanceDueDate { get; set; }

		public Area Area { get; set; }
	}
}