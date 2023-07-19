using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories;

namespace MarketPlace.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IStatusRepository _statusRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository,
            IMapper mapper,
            IDeliveryRepository deliveryRepository,
            IStatusRepository statusRepository,
            IBasketRepository basketRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _deliveryRepository = deliveryRepository;
            _statusRepository = statusRepository;
            _basketRepository = basketRepository;
        }
        public OrderDTO GetOrder(Guid id)
        {
            var order = _orderRepository.GetOrder(id);
            return _mapper.Map<OrderDTO>(order);
        }
        public async Task<Guid> CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.Idorder = Guid.NewGuid();
            await _orderRepository.Create(order);
            return order.Idorder;
        }
        public async Task UpdateOrder(Guid id, OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            order.Idorder = id;
            await _orderRepository.Update(order);
        }
        public async Task DeleteOrder(Guid id)
        {
            await _orderRepository.Delete(id);
        }
    }
}
