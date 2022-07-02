using ICT.Core.DTO;
using ICT.DAL.DB;

public class ReportBLL
{

    public void insertReport(InsertReportRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
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

    public void deleteReport(DeleteReportRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            db.Reports.Remove(db.Reports.Find(dto.Id));

            db.Reports.RemoveRange(db.Reports.Where(x => x.Id == dto.Id));

            db.SaveChanges();

        }
    }

    public void updateReport(UpdateReportRequestDTO dto)
    {
        using (ICTDbContext db = new ICTDbContext())
        {

            Report newReport = db.Reports.Find(dto.Id);

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

    public ICollection<Report> listReport()
    {
        ICTDbContext db = new ICTDbContext();

        ICollection<Report> reportList = db.Reports.ToList();

        db.SaveChanges();

        return reportList;
    }
}