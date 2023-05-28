using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZucoBackend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService reportService;

        public ReportController(ReportService reportService)
        {
            this.reportService = reportService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Report>>> GetAll()
        {
            var reports = await reportService.GetReports();
            return Ok(reports);
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Report>> Get(int id)
        {
            var report = await reportService.GetReport(id);
            if (report == null)
                return NotFound("Report not found");
            return Ok(report);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Report>> Add(ReportDto reportDto)
        {
            var report = await reportService.AddReport(reportDto);
            return Ok(report);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Report>> Delete(int id)
        {
            var report = await reportService.GetReport(id);
            if (report == null)
                return NotFound("Report not found");
            await reportService.RemoveReport(report); 
            return Ok(report);
        }

        [HttpPut("Upvote/{id}")]
        public async Task<ActionResult<Report>> Upvote(int id)
        {
            var report = await reportService.GetReport(id);
            if (report == null)
                return NotFound("Report not found");
            await reportService.Upvote(report);
            return Ok(report);
        }

        [HttpPut("Downvote/{id}")]
        public async Task<ActionResult<Report>> Downvote(int id)
        {
            var report = await reportService.GetReport(id);
            if (report == null)
                return NotFound("Report not found");
            await reportService.Downvote(report);
            return Ok(report);
        }

        [HttpPut("Approve/{id}")]
        public async Task<ActionResult<Report>> Approve(int id)
        {
            var report = await reportService.GetReport(id);
            if (report == null)
                return NotFound("Report not found");
            await reportService.Approve(report);
            return Ok(report);
        }

        [HttpGet("GetComments/{id}")]
        public async Task<ActionResult<List<Comment>>> GetComments(int id)
        {
            var comments = await reportService.GetComments(id);
            return comments;
        }
    }
}
