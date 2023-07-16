using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task CreateUser(User user);
        public User GetUser(Guid id);
    }
}
