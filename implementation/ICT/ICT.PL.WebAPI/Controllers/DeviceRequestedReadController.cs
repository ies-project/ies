using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DeviceRequestedReadController : ControllerBase {
        [HttpGet(Name = "GetDeviceRequestedReads")]
        public ListDeviceRequestedReadResponseDTO GetList()
        {
            return DeviceRequestedReadBLL.ListDeviceRequestedRead();
        }

        [HttpDelete(Name = "DeleteDeviceRequestedReads")]
        public void DeleteDeviceRequestedRead(DeleteDeviceRequestedReadRequestDTO dto)
        {
            DeviceRequestedReadBLL.DeleteDeviceRequestedRead(dto);
        }

        [HttpPut(Name = "InsertDeviceRequestedReads")]
        public void InsertListDeviceRequestedRead(InsertDeviceRequestedReadRequestDTO dto)
        {
            DeviceRequestedReadBLL.InsertDeviceRequestedRead(dto);
        }

        [HttpPatch(Name = "UpdateDeviceRequestedReads")]
        public void UpdateListDeviceRequestedRead(UpdateDeviceRequestedReadRequestDTO dto)
        {
            DeviceRequestedReadBLL.UpdateDeviceRequestedRead(dto);
        }
    }
}
