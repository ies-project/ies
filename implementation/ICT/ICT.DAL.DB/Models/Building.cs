using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
	/// <summary>
	/// Building class
	/// </summary>
	public class Building
	{
		/// <summary>
		/// Primary key of Area
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Name of the Building
		/// </summary>
		[StringLength(32)]
		public string Name { get; set; }
		/// <summary>
		/// Address of the Building
		/// </summary>
		[StringLength(32)]
		public string Address { get; set; }
		/// <summary>
		/// Type of Building
		/// </summary>
		[StringLength(32)]
		public string Type { get; set; }
		/// <summary>
		/// Collection of the Areas with this Building
		/// </summary>
		public ICollection<Area> Areas { get; set; }
	}
}
