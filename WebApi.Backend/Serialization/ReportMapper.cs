using VueProject.Data.Models;
using WebApi.Backend.ViewModels;

namespace WebApi.Backend.Serialization
{
    public class ReportMapper
    {
        public static ReportViewModel SerializeReport(Report report) 
        {
            return new ReportViewModel
            {
                Id = report.Id,
                Number = report.Number,
                CreateOn = report.CreateOn
            };
        }

        public static Report SerializeReport(ReportViewModel reportVM)
        {
            return new Report
            {
                Id = reportVM.Id,
                Number = reportVM.Number,
                CreateOn = reportVM.CreateOn
            };
        }
    }
}
