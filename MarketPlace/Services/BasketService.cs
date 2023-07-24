using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Enums;

namespace MarketPlace.Services
{
    public class BasketService:IBasketService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IReceiptRepository _receiptRepository;
        public BasketService(IBasketRepository basketRepository,
            IMapper mapper,
            IItemRepository itemRepository,
            IUserRepository userRepository,
            IDeliveryRepository deliveryRepository,
            IOrderRepository orderRepository,
            IReceiptRepository receiptRepository)
        {
            _deliveryRepository = deliveryRepository;
            _itemRepository = itemRepository;
            _mapper = mapper;
            _basketRepository = basketRepository;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
            _receiptRepository = receiptRepository;
        }
        public BasketDTO GetBasket(Guid id)
        {
            var basket = _basketRepository.GetBasket(id);
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            basketDTO.ItemsIds = basket.Items.Select(i => i.Iditem).ToList();
            return basketDTO;
        }
        public async Task<Guid> CreateBasket(BasketDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            basket.Items = basketDTO.ItemsIds.Select(i => _itemRepository.GetItem(i)).ToList();
            basket.Idbasket = Guid.NewGuid();
            await _basketRepository.Create(basket);
            return basket.Idbasket;
        }
        public async Task UpdateBasket(Guid id, BasketDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            basket.Idbasket = id;
            await _basketRepository.Update(basket);
        }
        public async Task DeleteBasket(Guid id)
        {
            await _basketRepository.Delete(id);
        }
        public async Task DeleteItemFromBasket(Guid itemId, Guid id)
        {
            var basket = _basketRepository.GetBasket(id);
            var itemForDelete = _itemRepository.GetItem(itemId);
            if (itemForDelete == null)
                throw new Exception("Предмета с таким id нет в корзине");
            basket.Items.Remove(itemForDelete);
            await _basketRepository.Update(basket);
        }
        public async Task<Guid> BasketToOrder(Guid userId, int deliveryId, Guid basketId)
        {
            var basket = _basketRepository.GetBasket(basketId);
            if(basket == null)
                throw new Exception($"Корзины с id = {basketId} не существует");
            if (basket.Items.Any(i => i.Available == false))
                throw new Exception($"Товар с id = {basket.Items.FirstOrDefault().Iditem} нельзя оформить");
            var totalCost = basket.Items.Sum(i => i.Cost);
            //Счёт на оплату
            var recept = new Receipt
            {
                Idreceipt = Guid.NewGuid(),
                Cost = totalCost,
                hasPayment = false
            };
            await _receiptRepository.Create(recept);
            var order = new Order
            {
                Idorder = Guid.NewGuid(),
                Receiptid = recept.Idreceipt,
                Statusid = (int)StatusEnum.Formed,
                Basketid = basket.Idbasket,
                Deliveryid = deliveryId
            };
            await _orderRepository.Create(order);
            await SetNotAvailableItems(basket);
            return recept.Idreceipt;
        }
        /// <summary>
        /// Если корзина превращается в заказ, то все оформленные товары становятся недоступными для добавления в корзины. Уже добавленные товары
        /// нужно будет удалить самому, т.к. корзины с ними оформить нельзя.
        /// </summary>
        /// <param name="basket">текущая корзина</param>
        /// <returns></returns>
        private async Task SetNotAvailableItems(Basket basket)
        {
            basket.Items = basket.Items.Select(i => { i.Available = false; return i; }).ToList();
            await _basketRepository.Update(basket);
        }
    }
}
