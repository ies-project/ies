using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class UpdateReportDeviceRequestDTO {
        public int Id_Report { get; set; }
        public int Id_Device { get; set; }
        public int Id_Area { get; set; }
        public string State { get; set; }

    }
}
