﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICT.Core.DTO {
    public class InsertDeviceRequestedReadRequestDTO {
        public int Id { get; set; }
        public int Id_Device { get; set; }
        public DateTime RequestDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public string ResponseStatus { get; set; }
        public string ResponseBody { get; set; }
       
    }
}