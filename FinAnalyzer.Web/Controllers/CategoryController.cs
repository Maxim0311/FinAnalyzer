using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{roomId}")]
        public async Task<ActionResult<OperationResult<IEnumerable<CategoryResponse>>>>
            GetAll(int roomId)
        {
            var result = await _categoryService.GetAllAsync(roomId);

            return Ok(result);
        }
    }
}
