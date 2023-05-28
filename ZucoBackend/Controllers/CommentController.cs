using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly CommentService commentService;

        public CommentController(CommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Comment>> AddComment(CommentDto commentDto)
        {
            var comment = await commentService.AddComment(commentDto);
            return Ok(comment);
        }

        [HttpPut("Upvote/{id}")]
        public async Task<ActionResult<Comment>> Upvote(int id)
        {
            var comment = await commentService.GetComment(id);
            if (comment == null)
                return NotFound("Report not found");
            await commentService.Upvote(comment);
            return Ok(comment);
        }

        [HttpPut("Downvote/{id}")]
        public async Task<ActionResult<Comment>> Downvote(int id)
        {
            var comment = await commentService.GetComment(id);
            if (comment == null)
                return NotFound("Report not found");
            await commentService.Downvote(comment);
            return Ok(comment);
        }
    }
}
