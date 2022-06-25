using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
	/// <summary>
	/// Area class
	/// </summary>
	public class Area
	{
		/// <summary>
		/// Primary key of Area
		/// </summary>
		[Key]
		public int Id { get; set; }
		/// <summary>
		/// Foreign key from the table Building
		/// </summary>
		public int Id_Building { get; set; }
		/// <summary>
		/// Foreign key from the table Area Type
		/// </summary>
		public int Id_Type { get; set; }
		/// <summary>
		/// Name of the Area
		/// </summary>
		[StringLength(32)]
		public string Name { get; set; }
		/// <summary>
		/// Area FLoor
		/// </summary>
		[StringLength(32)]
		public string Floor { get; set; }
		/// <summary>
		/// Number of Fire Balls in a Area
		/// </summary>
		public int NumFireBalls { get; set; }
		/// <summary>
		/// Number of Springles in a Area
		/// </summary>
		public int NumSpringles { get; set; }
		/// <summary>
		/// Number of Bocas Singulares in a Area
		/// </summary>
		public int NumBocasSingulares { get; set; }
		/// <summary>
		/// Number of Bocas Siameses in a Area
		/// </summary>
		public int NumBocasSiameses { get; set; }

		public ICollection<FireHoseReel> FireHoseReels { get; set; }
		public ICollection<Device> Devices { get; set; }
		public ICollection<Extinguisher> Extinguishers { get; set; }
		public ICollection<SurroundingArea> SurroundingAreas { get; set; }

		public Building Building { get; set; }
		public AreaType AreaType { get; set; }
		public SurroundingArea SurroundingArea { get; set; }

		public static void ConfigureRelations(ModelBuilder modelBuilder)
		{
            //Relationship from Area to Devices
            modelBuilder.Entity<Device>()
                .HasOne(dv => dv.Area)
                .WithMany(ar => ar.Devices)
                .HasForeignKey(dv => dv.Id_Area);

            //Relationship from Area to Extinguisher
            modelBuilder.Entity<Extinguisher>()
                .HasOne(ex => ex.Area)
                .WithMany(ar => ar.Extinguishers)
                .HasForeignKey(ex => ex.Id_Area);

            //Relationship from Area to FireHoseReel
            modelBuilder.Entity<FireHoseReel>()
                .HasOne(fh => fh.Area)
                .WithMany(ar => ar.FireHoseReels)
                .HasForeignKey(fh => fh.Id_Area);

            //Relationship from Area to SurroundingArea (M - N)
            modelBuilder.Entity<SurroundingArea>()
                .HasOne(sa => sa.Area)
                .WithMany(ar => ar.SurroundingAreas)
                .HasForeignKey(sa => sa.Id_Area);
        }
	}
}
