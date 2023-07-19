using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IItemService
    {
        public ItemDTO GetItem(Guid id);
        public Task<Guid> CreateItem(ItemDTO itemDTO);
    }
}
