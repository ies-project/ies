using ICT.MM.BLL;
using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.API
{
    [ApiController]
    [Route("[controller]")]
    public class ScenarioController : ControllerBase
    {
        /// <summary>
        /// Lista os cenarios presentes na base de dados
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetScenarios")]
        public ListScenarioResponseDTO GetList()
        {
            return ScenariosBLL.ListScenarios();
        }
        /// <summary>
        /// Elimina um cenario presente na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpDelete(Name = "DeleteScenario")]
        public void DeleteScenario(DeleteScenarioRequestDTO dto)
        {
            ScenariosBLL.DeleteScenario(dto);
        }

        /// <summary>
        /// Inser um cenario da base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPut(Name = "InsertScenarios")]
        public void InsertScenario(InsertScenarioRequestDTO dto)
        {
            ScenariosBLL.InsertScenario(dto);
        }

        /// <summary>
        /// Atualiza um cenario presente na base de dados
        /// </summary>
        /// <param name="dto"></param>
        [HttpPatch(Name = "UpdateScenarios")]
        public void UpdateScenario(UpdateScenarioRequestDTO dto)
        {
            ScenariosBLL.UpdateScenario(dto);
        }
    }
}
