using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class FireHoseReelController : ControllerBase {
        [HttpGet(Name = "GetFireHoseReel")]
        public ListFireHoseReelResponseDTO GetList()
        {
            return FireHoseReelBLL.ListFireHoseReel();
        }

        [HttpDelete(Name = "DeleteFireHoseReel")]
        public void DeleteFireHoseReel(DeleteFireHoseReelRequestDTO dto)
        {
            FireHoseReelBLL.DeleteFireHoseReel(dto);
        }

        [HttpPut(Name = "InsertFireHoseReel")]
        public void InsertFireHoseReel(InsertFireHoseReelRequestDTO dto)
        {
            FireHoseReelBLL.InsertFireHoseReel(dto);
        }

        [HttpPatch(Name = "UpdateFireHoseReel")]
        public void UpdateFireHoseReel(UpdateFireHoseReelRequestDTO dto)
        {
            FireHoseReelBLL.UpdateFireHoseReel(dto);
        }
    }
}
