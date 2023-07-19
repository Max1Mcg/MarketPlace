using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;

namespace MarketPlace.Services
{
    public class BasketService:IBasketService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public BasketService(IBasketRepository basketRepository,
            IMapper mapper,
            IItemRepository itemRepository,
            IUserRepository userRepository)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
            _basketRepository = basketRepository;
            _userRepository = userRepository;
        }
        public BasketDTO GetBasket(Guid id)
        {
            var basket = _basketRepository.GetBasket(id);
            var basketDTO = _mapper.Map<BasketDTO>(basket);
            basketDTO.ItemsIds = basket.Items.Select(i => i.Iditem).ToList();
            return basketDTO;
        }
        //Для отношения 1-1 используется id, поэтому навигационные свойства не нужны
        //если в отношении n элементов, то ids преобразуются в сущности, хранящиеся в коллекции
        public async Task<Guid> CreateBasket(BasketDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            basket.Items = basketDTO.ItemsIds.Select(i => _itemRepository.GetItem(i)).ToList();
            //basket.User = _userRepository.GetUser(basketDTO.Userid);
            basket.Idbasket = Guid.NewGuid();
            await _basketRepository.CreateBasket(basket);
            return basket.Idbasket;
        }
    }
}
