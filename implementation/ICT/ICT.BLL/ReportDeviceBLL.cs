using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class ReportDeviceBLL
    {
        public static void InsertReportDevice(InsertReportDeviceRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.ReportDevices.Find(dto.Id_Report) == null)
                {
                    ReportDevice newReportDevice = new ReportDevice();

                    newReportDevice.Id_Report = dto.Id_Report;

                    newReportDevice.Id_Device = dto.Id_Device;

                    newReportDevice.Id_Area = dto.Id_Area;

                    newReportDevice.State = dto.State;

                    db.ReportDevices.Add(newReportDevice);

                    db.SaveChanges();
                }
            }
        }

        public static void DeleteReportDevice(DeleteReportDeviceRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.ReportDevices.Find(dto.Id_Report) != null)
                {
                    db.ReportDevices.Remove(db.ReportDevices.Find(dto.Id_Report));

                    db.SaveChanges();
                }
            }
        }

        public static void UpdateReportDevice(UpdateReportDeviceRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                ReportDevice newReportDevice = new ReportDevice();

                newReportDevice.State = dto.State;

                db.SaveChanges();
            }
        }

        public static ListReportDeviceResponseDTO ListReportDevice()
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                List<ListItemReportDeviceResponseDTO> listItemReportDeviceResponseDTOs = db.ReportDevices
                        .Select(x => new ListItemReportDeviceResponseDTO
                        {
                            Id_Report = x.Id_Report,
                            Id_Device = x.Id_Device,
                            Id_Area = x.Id_Area,
                            State = x.State,
                        }).ToList();
                return new ListReportDeviceResponseDTO
                {
                    Items = listItemReportDeviceResponseDTOs,
                    Total = listItemReportDeviceResponseDTOs.Count()
                };
            }
        }
    }
}