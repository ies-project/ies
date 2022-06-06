using System;
using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Report class
    /// </summary>
    public class Report
    {
        /// <summary>
        /// Primary key of Report
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the report
        /// </summary>
        [StringLength(32, ErrorMessage = "The {0} cannot have more than 32 characters")]
        public string Name { get; set; }

        /// <summary>
        /// Date of the report
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Criteria of the report
        /// </summary>
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string Criteria { get; set; }
        
        /// <summary>
        /// Who Created the report
        /// </summary>
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Who modified the report
        /// </summary>
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string ModifiedBy { get; set; }

        /// <summary>
        /// Date of report creation
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Date of report modification
        /// </summary>
        public DateTime ModifiedDate { get; set; }

    }
}




