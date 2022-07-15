using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DeviceSubmittedActionController : ControllerBase {
        [HttpGet(Name = "GetDeviceSubmittedAction")]
        public ListDeviceSubmittedActionResponseDTO GetList()
        {
            return DeviceSubmittedActionBLL.ListDeviceSubmittedAction();
        }

        [HttpDelete(Name = "DeleteDeviceSubmittedAction")]
        public void DeleteDeviceSubmittedAction(DeleteDeviceSubmittedActionRequestDTO dto)
        {
            DeviceSubmittedActionBLL.DeleteDeviceSubmittedAction(dto);
        }

        [HttpPut(Name = "InsertDeviceSubmittedAction")]
        public void InsertDeviceSubmittedAction(InsertDeviceSubmittedActionRequestDTO dto)
        {
            DeviceSubmittedActionBLL.InsertDeviceSubmittedAction(dto);
        }

        [HttpPatch(Name = "UpdateDeviceSubmittedAction")]
        public void UpdateDeviceSubmittedAction(UpdateDeviceSubmittedActionRequestDTO dto)
        {
            DeviceSubmittedActionBLL.UpdateDeviceSubmittedAction(dto);
        }
    }
}
