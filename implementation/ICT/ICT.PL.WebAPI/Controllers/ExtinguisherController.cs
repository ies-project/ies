using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ExtinguisherController : ControllerBase {
        [HttpGet(Name = "GetExtinguishers")]
        public ListExtinguisherResponseDTO GetList()
        {
            return ExtinguisherBLL.ListExtinguisher();
        }

        [HttpDelete(Name = "DeleteExtinguisher")]
        public void DeleteExtinguisher(DeleteExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.DeleteExtinguisher(dto);
        }

        [HttpPut(Name = "InsertExtinguisher")]
        public void InsertExtinguisher(InsertExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.InsertExtinguisher(dto);
        }

        [HttpPatch(Name = "UpdateExtinguisher")]
        public void UpdateExtinguisher(UpdateExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.UpdateExtinguisher(dto);
        }
    }
}
