using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace MarketPlace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("/categories")]
        public IEnumerable<CategoryDTO> Categories()
        {
            return _categoryService.GetCategories();
        }
        [HttpPost("/create")]
        public async Task<int> Create([FromBody]CategoryDTO categoryDTO)
        {
            return await _categoryService.CreateCategory(categoryDTO);
        }
        [HttpPatch]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody]CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategory(id, categoryDTO);
            return Ok();
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
