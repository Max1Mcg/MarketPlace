using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        public Item GetItem(Guid id);
        public List<Item> GetItems(List<Guid>ids);
    }
}
