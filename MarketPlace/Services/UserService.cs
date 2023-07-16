using MarketPlace.Models.DTOs;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Models;
using AutoMapper;

namespace MarketPlace.Services
{
    public class UserService:IUserService
    {
        IUserRepository _userRepository;
        IMapper _mapper;
        public UserService(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Registration(UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Iduser = Guid.NewGuid();
            await _userRepository.CreateUser(user);
            return user.Iduser;
        }
        public UserDTO GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);
            return new UserDTO
            {
                Age= user.Age,
                Login= user.Login,
                Password= user.Password,
                Name= user.Name,
                Surname= user.Surname,
                Patronymic= user.Patronymic
            };
        }
    }
}
