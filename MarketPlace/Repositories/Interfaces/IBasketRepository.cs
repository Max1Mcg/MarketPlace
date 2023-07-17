using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IBasketRepository
    {
        public Task CreateBasket(Basket basket);
        public Basket GetBasket(Guid id);
    }
}
