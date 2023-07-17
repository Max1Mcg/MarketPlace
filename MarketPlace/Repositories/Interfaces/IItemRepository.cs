using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IItemRepository
    {
        public Task CreateItem(Item item);
        public Item GetItem(Guid id);
    }
}
