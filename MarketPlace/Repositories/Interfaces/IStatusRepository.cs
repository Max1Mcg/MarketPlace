using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IStatusRepository : IBaseRepository<Status>
    {
        public IEnumerable<Status> GetStatuses();
        public Status GetStatus(int id);
    }
}
