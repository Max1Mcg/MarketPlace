using AutoMapper;
using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<UserDTO, User>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ItemDTO, Item>()
                //временная затычка, чтобы настроить добавление элементов(в reverse повторение)
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
            CreateMap<BasketDTO, Basket>();
                //.ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.ItemsIds.Select(i => _itemRepository.GetItem(i))));
            CreateMap<DeliveryDTO, Delivery>();
            CreateMap<OrderDTO, Order>();
            CreateMap<StatusDTO, Status>();
            //reverse mapping
            CreateMap<User, UserDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Item, ItemDTO>()
                .ForMember(dest => dest.Categories, opt => opt.Ignore());
            CreateMap<Basket, BasketDTO>();
            CreateMap<Delivery, DeliveryDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Status, StatusDTO>();
        }
    }
}
