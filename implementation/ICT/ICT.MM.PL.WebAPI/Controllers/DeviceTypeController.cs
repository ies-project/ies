using ICT.MM.BLL;
using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DeviceTypeController : ControllerBase{

        [HttpGet(Name = "GetDeviceTypes")]
        public ListDeviceTypesResponseDTO GetList()
        {
            return DeviceTypesBLL.ListDeviceTypes();
        }

        [HttpDelete(Name = "DeleteDeviceType")]
        public void DeleteDeviceType(DeleteDeviceRequestDTO dto)
        {
            DeviceTypesBLL.DeleteDeviceType(dto);
        }

        [HttpPut(Name = "InsertDeviceType")]
        public void InsertDeviceType(InsertDeviceRequestDTO dto)
        {
            DeviceTypesBLL.InsertDeviceType(dto);
        }

        [HttpPatch(Name = "UpdateDeviceType")]
        public void UpdateDevice(UpdateDeviceRequestDTO dto)
        {
            DeviceTypesBLL.UpdateDeviceType(dto);
        }
    }
}
