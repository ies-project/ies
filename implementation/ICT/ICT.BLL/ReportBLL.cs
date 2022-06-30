using ICT.DAL.DB;

public class ReportBLL
{

    public void insertReport(int id, string name, DateTime date, string criteria, string createdBy, DateTime createdDate, string modifiedBy, DateTime modifiedDate)
    {
        ICTDbContext db = new ICTDbContext();

        Report newReport = new Report();

        newReport.Id = id;

        newReport.Name = name;

        newReport.Date = date;

        newReport.Criteria = criteria;

        newReport.CreatedBy = createdBy;

        newReport.CreatedDate = createdDate;

        newReport.ModifiedBy = modifiedBy;

        newReport.ModifiedDate = modifiedDate;

        db.Reports.Add(newReport);

        db.SaveChanges();
    }

    public void deleteReport(int idReport)
    {
        ICTDbContext db = new ICTDbContext();

        db.Reports.Remove(db.Reports.Find(idReport));

        db.Reports.RemoveRange(db.Reports.Where(x => x.Id == idReport));

        db.SaveChanges();

    }

    public void deleteReport(int id, string name, DateTime date, string criteria, string createdBy, DateTime createdDate, string modifiedBy, DateTime modifiedDate)
    {
        ICTDbContext db = new ICTDbContext();

        Report newReport = db.Reports.Find(id);

        newReport.Id = id;

        newReport.Name = name;

        newReport.Date = date;

        newReport.Criteria = criteria;

        newReport.CreatedBy = createdBy;

        newReport.CreatedDate = createdDate;

        newReport.ModifiedBy = modifiedBy;

        newReport.ModifiedDate = modifiedDate;

        db.Reports.Add(newReport);

        db.SaveChanges();
    }

    public ICollection<Report> listReport()
    {
        ICTDbContext db = new ICTDbContext();

        ICollection<Report> reportList = db.Reports.ToList();

        db.SaveChanges();

        return reportList;
    }
}