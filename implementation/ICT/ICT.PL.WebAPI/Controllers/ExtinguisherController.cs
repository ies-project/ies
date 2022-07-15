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
            return ExtinguisherBLL.ListExtinguishers();
        }

        [HttpDelete(Name = "DeleteExtinguisher")]
        public void DeleteDevice(DeleteExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.DeleteExtinguisher(dto);
        }

        [HttpPut(Name = "InsertExtinguisher")]
        public void InsertExtinguisher(InsertExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.InsertExtinguisher(dto);
        }

        [HttpPatch(Name = "UpdateDevice")]
        public void UpdateExtinguisher(UpdateExtinguisherRequestDTO dto)
        {
            ExtinguisherBLL.UpdateExtinguisher(dto);
        }
    }
}
