using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MarketPlaceContext context):base(context)
        {
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
