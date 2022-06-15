using System.ComponentModel.DataAnnotations;

namespace ICT.DAL.DB
{
    /// <summary>
    /// DeviceRequestedRead class
    /// </summary>
    public class DeviceRequestedRead
    {

        /// <summary>
        /// Primary key of DeviceRequestedReads
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Foreign Key from table Device
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
        
        /// <summary>
        /// Body of the response
        /// </summary>
        [StringLength(500, ErrorMessage = "The {0} cannot have more than 500 characters")]
        public string ResponseBody { get; set; }

        public Device Device { get; set; }

    }
}




