using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
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
        public void InsertDevice(InsertAreaRequestDTO dto)
        {
            AreaBLL.InsertArea(dto);
        }
    }
}
