using Microsoft.Extensions.FileProviders;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ImageService imageService;

        public ImageController(ImageService imageService)
        {
            this.imageService = imageService;
        }

        [HttpPost("/uploadImage")]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult> uploadImage(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("File is null!");
            }
            return Ok(await imageService.uploadImage(image));
        }
    }
}
