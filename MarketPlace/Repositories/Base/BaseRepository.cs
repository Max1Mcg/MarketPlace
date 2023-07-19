using MarketPlace.Contexts;
using MarketPlace.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories.Base
{
    public class BaseRepository<T> where T:class
    {
        private readonly MarketPlaceContext _context;
        private readonly DbSet<T> _set;
        public BaseRepository(MarketPlaceContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }
        public async Task Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(object id)
        {
            _set.Remove(await _set.FindAsync(id));
            await _context.SaveChangesAsync();
        }
        //Над этим подумать, т.к. у разных моделей разные связанные сущности
        /*public async Task<T> GetById(object id)
        {

        }*/
    }
}
