﻿using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IDeliveryService
    {
        public IEnumerable<DeliveryDTO> GetDeliveries();
        public Task<int> CreateDelivery(DeliveryDTO deliveryDTO);
    }
}
