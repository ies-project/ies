using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO
{
    public class ListBuildingResponseDTO
    {
        public int Total { get; set; }
        public List<ListItemBuildingResponseDTO> Items {get; set;}
    }

    public class ListItemBuildingResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
    }
}
