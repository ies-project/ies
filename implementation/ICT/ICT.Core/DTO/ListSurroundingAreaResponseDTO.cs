using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListSurroundingAreaResponseDTO
    {
        public int Total { get; set; }

        public List<ListItemSurroundingAreaResponseDTO> Items { get; set; }
    }
    public class ListItemSurroundingAreaResponseDTO
    {
        public int Id { get; set; }
        public int Id_Area { get; set; }

    }
}
