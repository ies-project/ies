using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using ICT.BLL;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AreaTypeController : ControllerBase {
        [HttpGet(Name = "GetAreaTypes")]
        public ListAreaTypeResponseDTO GetList()
        {
            return AreaTypeBLL.ListAreaType();
        }

        [HttpDelete(Name = "DeleteAreaType")]
        public void DeleteAreaType(DeleteAreaTypeRequestDTO dto)
        {
            AreaTypeBLL.DeleteAreaType(dto);
        }

        [HttpPut(Name = "InsertAreaType")]
        public void InsertBuilding(InsertAreaTypeRequestDTO dto)
        {
            AreaTypeBLL.InsertAreaType(dto);
        }

        [HttpPut(Name = "UpdateAreaType")]
        public void UpdateAreaType(UpdateAreaTypeRequestDTO dto)
        {
            AreaTypeBLL.UpdateAreaType(dto);
        }
    }
}
