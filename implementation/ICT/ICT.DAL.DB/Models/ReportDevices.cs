using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Data of devices that can be report
    /// </summary>
    public class ReportDevices
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id_Report { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Key]
        public int Id_Device { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id_Area { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(32, ErrorMessage = "The {0} cannot have more than 32 characters")]
        public string State { get; set; }

        //public Devices Device { get; set; }

        //public Reports Report { get; set; }
 
    }
}




