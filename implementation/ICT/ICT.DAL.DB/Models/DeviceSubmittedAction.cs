using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
    /// <summary>
    /// DeviceSubmittedAction class
    /// </summary>
    public class DeviceSubmittedAction
    {

        /// <summary>
        /// Primary key of DeviceSubmittedAction
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key from table Action
        /// </summary>
        public int Id_Action { get; set; }

        /// <summary>
        /// Foreign key from table Device
        /// </summary>
        public int Id_Device { get; set; }

        /// <summary>
        /// Date of the request
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Date of the response
        /// </summary>
        public DateTime ResponseDate { get; set; }

        /// <summary>
        /// Status of the response
        /// </summary>
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string ResponseStatus { get; set; }

        public Device Device { get; set; }
        public Action Action { get; set; }
    }
}




