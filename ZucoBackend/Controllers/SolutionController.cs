using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolutionController : ControllerBase
    {
        private readonly SolutionService solutionService;

        public SolutionController(SolutionService solutionService)
        {
            this.solutionService = solutionService;
        }

        [HttpGet("GetAll/{id}")]
        public async Task<ActionResult<List<Solution>>> GetAll(int id)
        {
            var solutions = await solutionService.GetSolutions(id);
            return Ok(solutions);
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Solution>> Add(SolutionDto solutionDto)
        {
            var solution = await solutionService.AddSolution(solutionDto);
            return Ok(solution);
        }
        [HttpPut("Approve/{id}")]
        public async Task<ActionResult<Solution>> Approve(int id)
        {
            var solution = await solutionService.ApproveSolution(id);
            return Ok(solution);
        }
    }
}
