using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.DAL.DB
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportDevices
    {
        public int Id_Report { get; set; }
        public int Id_Device { get; set; }

        public int Id_Area { get; set; }

        [StringLength(1, ErrorMessage = "The {0} cannot have more than 30 characters")]
        public string State { get; set; }

        //public Devices Device { get; set; }

        //public Reports Report { get; set; }
 
    }
}




