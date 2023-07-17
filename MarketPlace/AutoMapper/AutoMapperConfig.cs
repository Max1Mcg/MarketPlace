using AutoMapper;
using MarketPlace.Models;
using MarketPlace.Models.DTOs;

namespace MarketPlace.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<UserDTO, User>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ItemDTO, Item>();
            CreateMap<BasketDTO, Basket>();
            CreateMap<DeliveryDTO, Delivery>();
            CreateMap<OrderDTO, Order>();
            CreateMap<StatusDTO, Status>();
        }
    }
}
