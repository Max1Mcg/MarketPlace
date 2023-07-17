using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task CreateOrder(Order order);
        public Order GetOrder(Guid id);
    }
}
