using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListExtinguisherResponseDTO {
        public int Total { get; set; }
        public List<ListItemExtinguisherResponseDTO> Items { get; set; }
    }

    public class ListItemExtinguisherResponseDTO {
        public int Id { get; set; }
        public int Id_Area { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime MaintenanceDueDate { get; set; }
    }
}
