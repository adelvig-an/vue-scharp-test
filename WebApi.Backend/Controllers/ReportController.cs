using Microsoft.AspNetCore.Mvc;
using VueProject.Data.Models;
using VueProject.Services.Report;
using WebApi.Backend.Serialization;
using WebApi.Backend.ViewModels;

namespace WebApi.Backend.Controllers
{
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IReportService _reportService;

        public ReportController(ILogger<ReportController> logger, IReportService reportService)
        {
            _logger = logger;
            _reportService = reportService;
        }

        [HttpGet("api/report")]
        public ActionResult<IEnumerable<ReportViewModel>> GetReport()
        {
            _logger.LogInformation("Getting all reports");
            var reports = _reportService.GetAllReports();
            var reportVM = reports
                .Select(ReportMapper.SerializeReport);
            return Ok(reportVM);
        }
    }
}
