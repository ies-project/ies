using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ICT.DAL.DB
{
    /// <summary>
    /// ReportDevice class
    /// </summary>
    public class ReportDevice
    {
        /// <summary>
        /// Primary key of ReportDevice
        /// </summary>
        public int Id_Report { get; set; }

        /// <summary>
        /// Primary key of ReportDevice
        /// </summary>
        public int Id_Device { get; set; }

        /// <summary>
        /// Foreign Key from table Area
        /// </summary>
        public int Id_Area { get; set; }

        /// <summary>
        /// State of a Device
        /// </summary>
        [StringLength(32, ErrorMessage = "The {0} cannot have more than 32 characters")]
        public string State { get; set; }

        public Device Device { get; set; }

        public Report Report { get; set; }

        public static void ConfigureRelations(ModelBuilder modelBuilder)
        {
            //Defined primary key
            modelBuilder.Entity<ReportDevice>()
                .HasKey(rd => new { rd.Id_Report, rd.Id_Device });
        }
    }
}




