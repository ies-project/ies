using ICT.BLL;
using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ExtinguishersController : ControllerBase {
        [HttpGet(Name = "GetExtinguishers")]
        public ListExtinguisherResponseDTO GetList()
        {
            return ExtinguishersBLL.ListExtinguishers();
        }

        [HttpDelete(Name = "DeleteExtinguisher")]
        public void DeleteDevice(DeleteExtinguisherRequestDTO dto)
        {
            ExtinguishersBLL.DeleteExtinguisher(dto);
        }

        [HttpPut(Name = "InsertExtinguisher")]
        public void InsertExtinguisher(InsertExtinguisherRequestDTO dto)
        {
            ExtinguishersBLL.InsertExtinguisher(dto);
        }

        [HttpPatch(Name = "UpdateDevice")]
        public void UpdateExtinguisher(UpdateExtinguisherRequestDTO dto)
        {
            ExtinguishersBLL.UpdateExtinguisher(dto);
        }
    }
}
