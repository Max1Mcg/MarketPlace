using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IBasketRepository : IBaseRepository<Basket>
    {
        public Basket GetBasket(Guid id);
    }
}
