using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.DAL.DB
{
    /// <summary>
    /// DeviceType class
    /// </summary>
    public class DeviceType
    {
        /// <summary>
        /// Primary key of DeviceType
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Name of the DeviceType
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Description of the DeviceType
        /// </summary>
        public int Description { get; set; }

 
    }
}




