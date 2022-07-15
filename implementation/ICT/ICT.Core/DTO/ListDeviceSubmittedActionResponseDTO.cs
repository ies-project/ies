using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class ListDeviceSubmittedActionResponseDTO
    {
        public int Total { get; set; }

        public List<ListItemDeviceSubmittedActionResponseDTO> Items { get; set; }
    }
    public class ListItemDeviceSubmittedActionResponseDTO
    {
        public int Id { get; set; }
        public int Id_Action { get; set; }
        public int Id_Device { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ResponseStatus { get; set; }
    }
}
