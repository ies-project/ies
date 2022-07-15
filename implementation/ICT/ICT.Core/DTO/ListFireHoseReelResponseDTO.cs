using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListFireHoseReelResponseDTO
    {
        public int Total { get; set; }
        public List<ListItemFireHoseReelResponseDTO> Items { get; set; }
    }

    public class ListItemFireHoseReelResponseDTO
    {
        public int Id { get; set; }
        public int Id_Area { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime ManufacturedDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public DateTime MaintenanceDueDate { get; set; }
    }
}
