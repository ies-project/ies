using ICT.MM.BLL;
using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace ICT.MM.PL.WebAPI.API
{
    [EnableCors("*", "*", "*")]
    [ApiController]
    [Route("[controller]")]
    public class DeviceTypeController : ControllerBase
    {
        /// <summary>
        /// Lista os tipos de dispositivos presente na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetDeviceTypes")]
        public ListDeviceTypesResponseDTO GetList()
        {
            return DeviceTypesBLL.ListDeviceTypes();
        }
        /// <summary>
        /// Elimina um tipo de dispositivo da base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpDelete(Name = "DeleteDeviceType")]
        public void DeleteDeviceType(DeleteDeviceTypeRequestDTO dto)
        {
            DeviceTypesBLL.DeleteDeviceType(dto);
        }
        /// <summary>
        /// Inser um tipo de dispositivo na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "InsertDeviceType")]
        public void InsertDeviceType(InsertDeviceTypeRequestDTO dto)
        {
            DeviceTypesBLL.InsertDeviceType(dto);
        }
        /// <summary>
        /// Atualiza um tipo de dispositivo na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPatch(Name = "UpdateDeviceType")]
        public void UpdateDevice(UpdateDeviceTypeRequestDTO dto)
        {
            DeviceTypesBLL.UpdateDeviceType(dto);
        }
    }
}
