using ICT.Core.DTO;
using ICT.BLL;
using Microsoft.AspNetCore.Mvc;

namespace ICT.PL.WebAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ReportDeviceController : ControllerBase {
        [HttpGet(Name = "GetReportDevice")]
        public ListReportDeviceResponseDTO GetList()
        {       
            return ReportDeviceBLL.ListReportDevice();
        }

        [HttpDelete(Name = "DeleteReportDevice")]
        public void DeleteReport(DeleteReportDeviceRequestDTO dto)
        {
            ReportDeviceBLL.DeleteReportDevice(dto);
        }

        [HttpPut(Name = "InsertReportDevice")]
        public void InsertReport(InsertReportDeviceRequestDTO dto)
        {
            ReportDeviceBLL.InsertReportDevice(dto);
        }

        [HttpPatch(Name = "UpdateReportDevice")]
        public void UpdateReport(UpdateReportDeviceRequestDTO dto)
        {
            ReportDeviceBLL.UpdateReportDevice(dto);
        }
    }
}
