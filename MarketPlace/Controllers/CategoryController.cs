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
        /// <summary>
        /// Получение всех категорий
        /// </summary>
        /// <returns>коллекция категорий</returns>
        [HttpGet]
        public IEnumerable<CategoryDTO> Categories()
        {
            return _categoryService.GetCategories();
        }
        /// <summary>
        /// Создание категории
        /// </summary>
        /// <param name="categoryDTO">Информация для создания категории</param>
        /// <returns>id категории</returns>
        [HttpPost("create")]
        public async Task<int> Create([FromBody] CategoryDTO categoryDTO)
        {
            return await _categoryService.CreateCategory(categoryDTO);
        }
        /// <summary>
        /// Изменение категории
        /// </summary>
        /// <param name="id">id категории</param>
        /// <param name="categoryDTO">Новая информация по категории</param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] CategoryDTO categoryDTO)
        {
            await _categoryService.UpdateCategory(id, categoryDTO);
            return Ok();
        }
        /// <summary>
        /// Удаление категории
        /// </summary>
        /// <param name="id">id категории</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategory(id);
            return Ok();
        }
    }
}
