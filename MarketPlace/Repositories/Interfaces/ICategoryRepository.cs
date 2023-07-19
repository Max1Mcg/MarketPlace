using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories.Interfaces
{
    public interface ICategoryRepository:IBaseRepository<Category>
    {
        public IEnumerable<Category> GetCategories();
        public Category GetCategory(int id);
        
    }
}
