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
        IBasketRepository _basketRepository;
        IMapper _mapper;
        public BasketService(IBasketRepository basketRepository,
        IMapper mapper)
        {
            _mapper = mapper;
            _basketRepository = basketRepository;
        }
        public Basket GetBasket(Guid id)
        {
            return _basketRepository.GetBasket(id);
        }
        public async Task<Guid> CreateBasket(BasketDTO basketDTO)
        {
            var basket = _mapper.Map<Basket>(basketDTO);
            basket.Idbasket = Guid.NewGuid();
            await _basketRepository.CreateBasket(basket);
            return basket.Idbasket;
        }
    }
}
