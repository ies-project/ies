using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [EnableCors("*")]
    [ApiController]
    [Route("[controller]")]
    public class DeviceTypeController : ControllerBase {
        [HttpGet(Name = "GetDeviceType")]
        public ListDeviceTypeResponseDTO GetList()
        {
            return DeviceTypeBLL.ListDeviceType();
        }

        [HttpDelete(Name = "DeleteDeviceType")]
        public void DeleteDeviceType(DeleteDeviceTypeRequestDTO dto)
        {
            DeviceTypeBLL.DeleteDeviceType(dto);
        }

        [HttpPut(Name = "InsertDeviceType")]
        public void InsertListDeviceType(InsertDeviceTypeRequestDTO dto)
        {
            DeviceTypeBLL.InsertDeviceType(dto);
        }

        [HttpPatch(Name = "UpdateDeviceType")]
        public void UpdateListDeviceType(UpdateDeviceTypeRequestDTO dto)
        {
            DeviceTypeBLL.UpdateDeviceType(dto);
        }
    }
}
