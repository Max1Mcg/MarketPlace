using MarketPlace.Models.DTOs;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Models;
using AutoMapper;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories;

namespace MarketPlace.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
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
            await _userRepository.Create(user);
            return user.Iduser;
        }
        public UserDTO GetUser(Guid id)
        {
            var user = _userRepository.GetUser(id);
            return _mapper.Map<UserDTO>(user);
        }
        public async Task UpdateUser(Guid id, UserDTO userDTO)
        {
            var user = _mapper.Map<User>(userDTO);
            user.Iduser = id;
            await _userRepository.Update(user);
        }
        public async Task DeleteUser(Guid id)
        {
            await _userRepository.Delete(id);
        }
    }
}
