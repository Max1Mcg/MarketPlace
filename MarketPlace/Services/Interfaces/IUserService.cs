using MarketPlace.Models.DTOs;

namespace MarketPlace.Services.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> Registration(UserDTO userDTO);
        public UserDTO GetUser(Guid id);
        public Task UpdateUser(Guid id, UserDTO userDTO);
        public Task DeleteUser(Guid id);
    }
}
