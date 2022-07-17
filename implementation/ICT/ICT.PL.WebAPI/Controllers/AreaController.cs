using ICT.Core.DTO;
using ICT.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace ICT.PL.WebAPI.Controllers {
    [EnableCors("*")]
    [ApiController]
    [Route("[controller]")]
    public class AreaController : ControllerBase {
        [HttpGet(Name = "GetAreas")]
        public ListAreaResponseDTO GetList()
        {
            return AreaBLL.ListArea();
        }

        [HttpDelete(Name = "DeleteArea")]
        public void DeleteArea(DeleteAreaRequestDTO dto)
        {
            AreaBLL.DeleteArea(dto);
        }

        [HttpPut(Name = "InsertArea")]
        public void InsertArea(InsertAreaRequestDTO dto)
        {
            AreaBLL.InsertArea(dto);
        }

        [HttpPatch(Name = "UpdateArea")]
        public void UpdateArea(UpdateAreaRequestDTO dto)
        {
            AreaBLL.UpdateArea(dto);
        }
    }
}
