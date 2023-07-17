using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Repositories;
using MarketPlace.Services.Interfaces;

namespace MarketPlace.Services
{
    public class DeliveryService:IDeliveryService
    {
        IDeliveryRepository _deliveryRepository;
        IMapper _mapper;
        public DeliveryService(IDeliveryRepository deliveryRepository,
        IMapper mapper)
        {
            _mapper = mapper;
            _deliveryRepository = deliveryRepository;
        }
        public IEnumerable<Delivery> GetDeliveries()
        {
            return _deliveryRepository.GetDeliveries();
        }
        public async Task<int> CreateDelivery(DeliveryDTO deliveryDTO)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDTO);
            var indexToAdd = _deliveryRepository.GetDeliveries().Count();
            delivery.Iddelivery = indexToAdd;
            await _deliveryRepository.CreateDelivery(delivery);
            return indexToAdd;
        }
    }
}
