using ICT.Core.DTO;
using ICT.DAL.DB;

namespace ICT.BLL
{
    public class ReportBLL
    {
        public static void InsertReport(InsertReportRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.Reports.Find(dto.Id) == null)
                {
                    Report newReport = new Report();

                    newReport.Id = dto.Id;

                    newReport.Name = dto.Name;

                    newReport.Date = dto.Date;

                    newReport.Criteria = dto.Criteria;

                    newReport.CreatedBy = dto.CreatedBy;

                    newReport.CreatedDate = dto.CreatedDate;

                    newReport.ModifiedBy = dto.ModifiedBy;

                    newReport.ModifiedDate = dto.ModifiedDate;

                    db.Reports.Add(newReport);

                    db.SaveChanges();
                }
            }
        }

        public static void DeleteReport(DeleteReportRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                if (db.Reports.Find(dto.Id) != null)
                {
                    db.Reports.Remove(db.Reports.Find(dto.Id));

                    db.SaveChanges();
                }
            }
        }

        public static void UpdateReport(UpdateReportRequestDTO dto)
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                Report newReport = db.Reports.Find(dto.Id);

                newReport.Name = dto.Name;

                newReport.Date = dto.Date;

                newReport.Criteria = dto.Criteria;

                newReport.CreatedBy = dto.CreatedBy;

                newReport.CreatedDate = dto.CreatedDate;

                newReport.ModifiedBy = dto.ModifiedBy;

                newReport.ModifiedDate = dto.ModifiedDate;

                db.SaveChanges();
            }
        }

        public static ListReportResponseDTO ListReport()
        {
            using (ICTDbContext db = new ICTDbContext())
            {
                List<ListItemReportResponseDTO> listItemReportResponseDTOs = db.Reports
                        .Select(x => new ListItemReportResponseDTO
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Date = x.Date,
                            Criteria = x.Criteria,
                            CreatedBy = x.CreatedBy,
                            CreatedDate = x.CreatedDate,
                            ModifiedBy = x.ModifiedBy,
                            ModifiedDate = x.ModifiedDate,
                        }).ToList();
                return new ListReportResponseDTO
                {
                    Items = listItemReportResponseDTOs,
                    Total = listItemReportResponseDTOs.Count()
                };
            }
        }
    }
}