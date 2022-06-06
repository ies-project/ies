using System;
using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
    /// <summary>
    /// FireHoseReel class
    /// </summary>
    public class FireHoseReel
    {

        /// <summary>
        /// Primary key of FireHoseReel
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key from table Area
        /// </summary>
        public int Id_Area { get; set; }


        /// <summary>
        /// Type of FireHoseReel
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Description of the FireHoseReel
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// FireHoseReel Manufactured Date 
        /// </summary>
        public DateTime ManufacturedDate { get; set; }

        /// <summary>
        /// FireHoseReel Last Maintenance Date 
        /// </summary>
        public DateTime LastMaintenanceDate { get; set; }

        /// <summary>
        /// FireHoseReel Maintenance Due Date 
        /// </summary>
        public DateTime ManteinanceDueDate { get; set; }
    }
}




