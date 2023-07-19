using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IBasketService
    {
        public BasketDTO GetBasket(Guid id);
        public Task<Guid> CreateBasket(BasketDTO basketDTO);
    }
}
