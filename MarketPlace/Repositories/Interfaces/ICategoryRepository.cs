using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public Task CreateCategory(Category category);
        public IEnumerable<Category> GetCategories();
    }
}
