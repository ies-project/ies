using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Data of DeviceRequestedReads
    /// </summary>
    public class DeviceRequestedReads
    {

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id_Device { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime ResponseDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string ResponseStatus { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(500, ErrorMessage = "The {0} cannot have more than 500 characters")]
        public string ResponseBody { get; set; }

    }
}




