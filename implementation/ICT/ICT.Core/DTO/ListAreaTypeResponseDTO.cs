using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO
{
    public class ListAreaTypeResponseDTO
    {
        public int Total { get; set; }
        public List<ListItemAreaTypeResponseDTO> Items {get; set;}
    }

    public class ListItemAreaTypeResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
