using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace ICT.MM.PL.WebAPI.API
{
    [EnableCors("*", "*", "*")]
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        /// <summary>
        /// Lista com os dispositivos presentes na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetDevices")]
        public ListDeviceResponseDTO GetList()
        {
            return DeviceBLL.ListDevices();
        }

        /// <summary>
        /// Elimina um dispositivo da base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpDelete(Name = "DeleteDevice")]
        public void DeleteDevice(DeleteDeviceRequestDTO dto)
        {
            DeviceBLL.DeleteDevice(dto);
        }
        /// <summary>
        /// Inser um dispositivo na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "InsertDevice")]
        public void InsertDevice(InsertDeviceRequestDTO dto)
        {
            DeviceBLL.InsertDevice(dto);
        }
        /// <summary>
        /// Atualiza um dispositivo da base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPatch(Name = "UpdateDevice")]
        public void UpdateDevice(UpdateDeviceRequestDTO dto)
        {
            DeviceBLL.UpdateDevice(dto);
        }
    }
}
