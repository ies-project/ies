using ICT.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ActionController : ControllerBase {
        [HttpGet(Name = "GetAction")]
        public ListActionResponseDTO GetList()
        {       
            return BLL.ActionBLL.ListAction();
        }

        [HttpDelete(Name = "DeleteAction")]
        public void DeleteAction(DeleteActionRequestDTO dto)
        {
            BLL.ActionBLL.DeleteAction(dto);
        }

        [HttpPut(Name = "UpdateAction")]
        public void UpdateAction(UpdateActionRequestDTO dto)
        {
            BLL.ActionBLL.UpdateAction(dto);
        }

        [HttpPut(Name = "InsertAction")]
        public void InsertAction(InsertActionRequestDTO dto)
        {
            BLL.ActionBLL.InsertAction(dto);
        }
    }
}
