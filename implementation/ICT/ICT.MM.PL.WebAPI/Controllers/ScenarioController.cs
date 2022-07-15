using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ScenarioController : ControllerBase {
        [HttpGet(Name = "GetScenarios")]
        public ListScenarioResponseDTO GetList()
        {
            return BLL.ScenariosBLL.ListScenarios();
        }

        [HttpDelete(Name = "DeleteScenario")]
        public void DeleteScenario(DeleteScenarioRequestDTO dto)
        {
            BLL.ScenariosBLL.DeleteScenario(dto);
        }

        [HttpPut(Name = "InsertScenarios")]
        public void InsertScenario(InsertScenarioRequestDTO dto)
        {
            BLL.ScenariosBLL.InsertScenario(dto);
        }

        [HttpPatch(Name = "UpdateScenarios")]
        public void UpdateScenario(UpdateScenarioRequestDTO dto)
        {
            BLL.ScenariosBLL.UpdateScenario(dto);
        }
    }
}
