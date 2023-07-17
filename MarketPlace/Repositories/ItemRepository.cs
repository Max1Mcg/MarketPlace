using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class ItemRepository:IItemRepository
    {
        MarketPlaceContext _context;
        public ItemRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateItem(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }
        public Item GetItem(Guid id)
        {
            return _context.Items.FirstOrDefault(i => i.Iditem == id);
        }
    }
}
