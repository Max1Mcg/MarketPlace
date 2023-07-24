using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;

namespace MarketPlace.Repositories
{
    public class UserRepository:BaseRepository<User>, IUserRepository
    {
        public UserRepository(MarketPlaceContext context):base(context)
        {
        }
        public User GetUser(Guid id)
        {
            return _context.Users.FirstOrDefault(u => u.Iduser == id);
        }
    }
}
