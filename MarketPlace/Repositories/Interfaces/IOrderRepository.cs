using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        public Order GetOrder(Guid id);
    }
}
