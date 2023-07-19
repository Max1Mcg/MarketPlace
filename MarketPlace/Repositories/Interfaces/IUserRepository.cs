using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User GetUser(Guid id);
    }
}
