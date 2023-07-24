using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories;
using MarketPlace.Enums;

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
        /// <summary>
        /// Отмена заказа. Если он был оплачен, то возврат средств(иммуляция этого в виде строки).
        /// </summary>
        /// <param name="id">id заказа</param>
        /// <returns>Результат, при надобность информаровании о возврате средств</returns>
        public async Task<string> CancelOrder(Guid id)
        {
            var order = _orderRepository.GetOrder(id);
            order.Statusid = (int)StatusEnum.Closed;
            await SetAvailableItems(order.Basket);
            await _orderRepository.Update(order);
            if (order.receipt.hasPayment)
                return $"Заказ отменен, пользователю с id = {order.Basket.User.Iduser} переведены обратно {order.receipt.Cost} у.е.";
            return "Заказ отменен";
        }
        /// <summary>
        /// Если заказ отменяется, то товары из него снова становятся доступными
        /// </summary>
        /// <param name="basket">текущая корзина</param>
        /// <returns></returns>
        private async Task SetAvailableItems(Basket basket)
        {
            basket.Items = basket.Items.Select(i => { i.Available = true; return i; }).ToList();
            await _basketRepository.Update(basket);
        }
    }
}
