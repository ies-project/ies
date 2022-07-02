using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SurroundingAreaController : ControllerBase {
        [HttpGet(Name = "GetSurroundingAreas")]
        public ListSurroundingAreaResponseDTO GetList()
        {
            return SurroundingAreaBLL.ListSurroundingArea();
        }

        [HttpDelete(Name = "DeleteSurroundingArea")]
        public void SurroundingDeleteArea(DeleteSurroundingAreaRequestDTO dto)
        {
            SurroundingAreaBLL.DeleteSurroundingArea(dto);
        }

        [HttpPut(Name = "InsertSurroundingArea")]
        public void InsertSurroundingArea(InsertSurroundingAreaRequestDTO dto)
        {
            SurroundingAreaBLL.InsertSurroundingArea(dto);
        }
    }
}
