using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IOrderService
    {
        public OrderDTO GetOrder(Guid id);
        public Task<Guid> CreateOrder(OrderDTO orderDTO);
        public Task UpdateOrder(Guid id, OrderDTO orderDTO);
        public Task DeleteOrder(Guid id);
    }
}
