using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase {
        [HttpGet(Name = "GetDevice")]
        public ListDeviceResponseDTO GetList()
        {
            return DeviceBLL.ListDevice();
        }

        [HttpDelete(Name = "DeleteDevice")]
        public void DeleteDevice(DeleteDeviceRequestDTO dto)
        {
            DeviceBLL.DeleteDevice(dto);
        }

        [HttpPut(Name = "InsertDevice")]
        public void InsertListDevice(InsertDeviceRequestDTO dto)
        {
            DeviceBLL.InsertDevice(dto);
        }

        [HttpPatch(Name = "UpdateDevice")]
        public void UpdateListDevice(UpdateDeviceRequestDTO dto)
        {
            DeviceBLL.UpdateDevice(dto);
        }
    }
}
