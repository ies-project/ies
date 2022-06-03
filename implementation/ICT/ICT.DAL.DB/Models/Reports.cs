using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.DAL.DB
{
    /// <summary>
    /// Data of reports
    /// </summary>
    public class Reports
    {
        [Key]
        public int Id { get; set; }

        [StringLength(32, ErrorMessage = "The {0} cannot have more than 32 characters")]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string Criteria { get; set; }
        
        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string CreatedBy { get; set; }

        [StringLength(64, ErrorMessage = "The {0} cannot have more than 64 characters")]
        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}




