using ICT.MM.BLL;
using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class ScenarioDeviceController : ControllerBase
    {
        /// <summary>
        /// Lista os ScenariosDevices presente na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetScenarioDevices")]
        public ListScenarioDeviceResponseDTO GetList()
        {
            return ScenarioDevicesBLL.ListScenarioDevices();
        }
        /// <summary>
        /// Elimina um scenarioDevice presente na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpDelete(Name = "DeleteScenarioDevices")]
        public void DeleteScenarioDevices(DeleteScenarioDeviceRequestDTO dto)
        {
            ScenarioDevicesBLL.DeleteScenarioDevices(dto);
        }
        /// <summary>
        /// Inser um scenario device na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "InsertScenarioDevices")]
        public void InsertScenarioDevices(InsertScenarioDeviceRequestDTO dto)
        {
            ScenarioDevicesBLL.InsertScenarioDevices(dto);
        }
        /// <summary>
        /// Atualiza um ScenarioDevice presente na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPatch(Name = "UpdateScenarioDevices")]
        public void UpdateScenarioDevices(UpdateScenarioDeviceRequestDTO dto)
        {
            ScenarioDevicesBLL.UpdateScenarioDevices(dto);
        }
    }
}
