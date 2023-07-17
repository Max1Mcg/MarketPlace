using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IOrderService
    {
        public Order GetOrder(Guid id);
        public Task<Guid> CreateOrder(OrderDTO orderDTO);
    }
}
