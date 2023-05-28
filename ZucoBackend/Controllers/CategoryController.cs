using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZucoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            var categories = await categoryService.GetCategories();
            return Ok(categories);
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await categoryService.GetCategory(id);
            if (category == null)
                return NotFound("Category not found");
            return Ok(category);
        }
    }
}
