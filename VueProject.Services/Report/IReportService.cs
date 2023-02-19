using VueProject.Data.Models;

namespace VueProject.Services.Report
{
    public interface IReportService
    {
        List<Data.Models.Report> GetAllReports();
        ServiceResponse<Data.Models.Report> CreateReport(Data.Models.Report report);
        ServiceResponse<bool> DeleteReport(int id);
        Data.Models.Report GetReport(int id);
    }
}
