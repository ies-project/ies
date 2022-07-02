﻿using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase {
        [HttpGet(Name = "GetDevices")]
        public ListDeviceResponseDTO GetList()
        {
            return DeviceBLL.ListDevices();
        }

        [HttpDelete(Name = "DeleteDevice")]
        public void DeleteDevice(DeleteDeviceRequestDTO dto)
        {
            DeviceBLL.DeleteDevice(dto);
        }

        [HttpPut(Name = "InsertDevice")]
        public void InsertDevice(InsertDeviceRequestDTO dto)
        {
            DeviceBLL.InsertDevice(dto);
        }
    }
}