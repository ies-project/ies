using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
    /// <summary>
    /// SurroundingArea class
    /// </summary>
    public class SurroundingArea
    {
        /// <summary>
        /// Primary key of SurroundingArea
        /// </summary>
        
        public int Id { get; set; }

        /// <summary>
        /// Primary key and Foreign Key from table Area
        /// </summary>
        public int Id_Area { get; set; }

        public ICollection<Area> Areas { get; set; }

        public Area Area { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Defined primary key
            modelBuilder.Entity<SurroundingArea>()
                .HasKey(sa => new { sa.Id, sa.Id_Area });
        }
    }
}




