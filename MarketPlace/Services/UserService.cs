using MarketPlace.Models.DTOs;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Models;

namespace MarketPlace.Services
{
    public class UserService:IUserService
    {
        IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Guid> Registration(UserDTO userDTO)
        {
            //Test run, replace with automapper
            var user = new User {
            Iduser = Guid.NewGuid(),
            Name= userDTO.Name,
            Surname= userDTO.Surname,
            Patronymic= userDTO.Patronymic,
            Age= userDTO.Age,
            Login= userDTO.Login,
            Password= userDTO.Password
            };
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
