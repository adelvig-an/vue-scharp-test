using VueProject.Data;

namespace VueProject.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly ApplicationDbContext _db;

        public ReportService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public List<Data.Models.Report> GetAllReports()
        {
            return _db.Reports.ToList();
        }

        public ServiceResponse<Data.Models.Report> CreateReport(Data.Models.Report report)
        {
            var now = DateTime.UtcNow;

            try
            {
                _db.Reports.Add(report);
                _db.SaveChanges();

                return new ServiceResponse<Data.Models.Report>
                {
                    Data = report,
                    Time = now,
                    IsSuccess = true,
                    Message = "New report added"
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Report>
                {
                    Data = report,
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace
                };
            }
        }

        public ServiceResponse<bool> DeleteReport(int id)
        {
            var report = _db.Reports.Find(id);
            var now = DateTime.UtcNow;

            if (report == null)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    IsSuccess = false,
                    Message = "Report to delete not found!"
                };
            }

            try
            {
                _db.Reports.Remove(report);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Data = true,
                    Time = now,
                    IsSuccess = true,
                    Message = "Report delete"
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Data = false,
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace
                };
            }
        }

        public Data.Models.Report GetReport(int id)
        {
            return _db.Reports.Find(id);
        }
    }
}
