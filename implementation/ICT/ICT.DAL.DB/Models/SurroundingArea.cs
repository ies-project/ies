using System.ComponentModel.DataAnnotations;

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
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key from table Area
        /// </summary>
        public int Id_Area { get; set; }

        public ICollection<Area> Areas { get; set; }

        public Area Area { get; set; }
    }
}




