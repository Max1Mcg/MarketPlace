using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.Repositories
{
    public class ItemRepository:BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(MarketPlaceContext context):base(context)
        {
        }
        public Item GetItem(Guid id)
        {
            return _context.Items
                .Where(i => i.Iditem == id)
                .Include(i => i.Categories)
                .SingleOrDefault();
        }
    }
}
