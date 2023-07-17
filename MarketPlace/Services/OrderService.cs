using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;

namespace MarketPlace.Services
{
    public class OrderService:IOrderService
    {
        IOrderRepository _orderRepository;
        IMapper _mapper;
        public OrderService(IOrderRepository orderRepository,
        IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public Order GetOrder(Guid id)
        {
            return _orderRepository.GetOrder(id);
        }
        public async Task<Guid> CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.Idorder = Guid.NewGuid();
            await _orderRepository.CreateOrder(order);
            return order.Idorder;
        }
    }
}
