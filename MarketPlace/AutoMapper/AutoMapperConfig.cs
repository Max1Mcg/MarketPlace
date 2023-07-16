using AutoMapper;
using MarketPlace.Models;
using MarketPlace.Models.DTOs;

namespace MarketPlace.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() {
            CreateMap<UserDTO, User>();
        }
    }
}
