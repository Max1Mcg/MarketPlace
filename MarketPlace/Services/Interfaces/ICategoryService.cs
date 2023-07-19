using MarketPlace.Models;
using MarketPlace.Models.DTOs;

namespace MarketPlace.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDTO> GetCategories();
        public Task<int> CreateCategory(CategoryDTO categoryDTO);
        public Task UpdateCategory(int id, CategoryDTO categoryDTO);
        public Task DeleteCategory(int id);
    }
}
