﻿using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using Npgsql.PostgresTypes;

namespace MarketPlace.Services.Interfaces
{
    public interface IBasketService
    {
        public BasketDTO GetBasket(Guid id);
        public Task<Guid> CreateBasket(BasketDTO basketDTO);
        public Task DeleteBasket(Guid id);
        public Task UpdateBasket(Guid id, BasketDTO basketDTO);
        public Task DeleteItemFromBasket(Guid itemId, Guid id);
        public Task<Guid> BasketToOrder(Guid userId, int deliveryId, Guid basketId);
    }
}
