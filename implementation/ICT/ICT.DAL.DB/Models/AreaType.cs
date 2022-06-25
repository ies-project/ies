using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
	/// <summary>
    /// AreaType Class
    /// </summary>
	public class AreaType
	{
        /// <summary>
        /// Primary Key to AreaTypes
        /// </summary>
        [Key]
		public int Id { get; set; }
        /// <summary>
        /// Name of the Area Type
        /// </summary>
        [StringLength(32)]
		public string Name { get; set; }
        /// <summary>
        /// Description for the Area Type
        /// </summary>
        [StringLength(64)]
		public string Description { get; set; }
		/// <summary>
        /// Collection of the Areas with this AreaType
        /// </summary>
		public ICollection<Area>Areas { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Relationship from AreaType to Areas
            modelBuilder.Entity<Area>()
                .HasOne(ar => ar.AreaType)
                .WithMany(at => at.Areas)
                .HasForeignKey(ar => ar.Id_Type);
        }

    }
}

