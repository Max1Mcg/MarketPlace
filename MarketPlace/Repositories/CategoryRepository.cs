using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MarketPlaceContext _context;
        public CategoryRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories;
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Idcategory == id);
        }
    }
}
