using ICT.Core.DTO;
using ICT.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase {
        [HttpGet(Name = "GetReport")]
        public ListReportResponseDTO GetList()
        {       
            return ReportBLL.ListReport();
        }

        [HttpDelete(Name = "DeleteReport")]
        public void DeleteReport(DeleteReportRequestDTO dto)
        {
            ReportBLL.DeleteReport(dto);
        }

        [HttpPut(Name = "InsertReport")]
        public void InsertReport(InsertReportRequestDTO dto)
        {
            ReportBLL.InsertReport(dto);
        }

        [HttpPatch(Name = "UpdateReport")]
        public void UpdateReport(UpdateReportRequestDTO dto)
        {
            ReportBLL.UpdateReport(dto);
        }
    }
}
