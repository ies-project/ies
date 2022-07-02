using ICT.MM.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.MM.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ScenarioController : ControllerBase {
        [HttpGet(Name = "GetScenarios")]
        public ListScenarioResponseDTO Get()
        {
            return BLL.ScenariosBLL.ListScenarios();
        }
    }
}
