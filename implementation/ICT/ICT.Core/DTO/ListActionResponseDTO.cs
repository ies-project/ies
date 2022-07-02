using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListActionResponseDTO
    {
        public int Total { get; set; }

        public List<ListItemActionResponseDTO> Items { get; set; }
    }
    public class ListItemActionResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
