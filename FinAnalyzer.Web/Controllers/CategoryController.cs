﻿using FinAnalyzer.Common;
using FinAnalyzer.Core.Dto.Category;
using FinAnalyzer.Core.Services.Interfaces;
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
        public async Task<ActionResult<OperationResult<IEnumerable<CategoryResponse>>>> GetAll(int roomId)
        {
            var result = await _categoryService.GetAllAsync(roomId);

            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<ActionResult<OperationResult<int>>> Create(CategoryCreateRequest categoryDto)
        {
            var result = await _categoryService.CreateAsync(categoryDto);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
