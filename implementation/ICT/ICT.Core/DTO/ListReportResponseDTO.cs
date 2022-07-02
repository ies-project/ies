using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListReportResponseDTO {
        public int Total { get; set; }

        public List<ListItemReportgResponseDTO> Items { get; set; }
    }
    public class ListItemReportgResponseDTO {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Criteria { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
