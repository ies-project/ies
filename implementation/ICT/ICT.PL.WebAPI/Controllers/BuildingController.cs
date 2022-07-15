using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using ICT.BLL;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class BuildingController : ControllerBase {
        [HttpGet(Name = "GetBuildings")]
        public ListBuildingResponseDTO GetList()
        {
            return BuildingBLL.ListBuilding();
        }

        [HttpDelete(Name = "DeleteBuilding")]
        public void DeleteBuilding(DeleteBuildingRequestDTO dto)
        {
            BuildingBLL.DeleteBuilding(dto);
        }

        [HttpPut(Name = "InsertBuilding")]
        public void InsertBuilding(InsertBuildingRequestDTO dto)
        {
            BuildingBLL.InsertBuilding(dto);
        }

        [HttpPatch(Name = "UpdateBuilding")]
        public void UpdateBuilding(UpdateBuildingRequestDTO dto)
        {
            BuildingBLL.UpdateBuilding(dto);
        }
    }
}
