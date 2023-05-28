using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportTypeController : ControllerBase
    {
        private readonly ReportTypeService reportTypeService;

        public ReportTypeController(ReportTypeService reportTypeService)
        {
            this.reportTypeService = reportTypeService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<ReportType>>> GetAll()
        {
            var reportTypes = await reportTypeService.GetReportTypes();
            return Ok(reportTypes);
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var reportType = await reportTypeService.GetReportType(id);
            if (reportType == null)
                return NotFound("Category not found");
            return Ok(reportType);
        }
    }
}
