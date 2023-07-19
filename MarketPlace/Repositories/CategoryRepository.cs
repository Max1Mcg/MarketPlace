using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        //private readonly MarketPlaceContext _context;
        //Возможно из-за этого контекст будет дублировать и его нужно будет сделать транзиент
        public CategoryRepository(MarketPlaceContext context):base(context)
        {
            //_context = context;
        }
        /*public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }*/
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
