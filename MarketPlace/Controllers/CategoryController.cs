using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        //test
        [HttpPatch]
        public async Task<ActionResult> UpdateCategory(CategoryDTO categoryDTO)
        {
            return Ok();
        }
    }
}
