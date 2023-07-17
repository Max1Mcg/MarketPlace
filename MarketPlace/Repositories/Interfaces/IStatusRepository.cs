using MarketPlace.Models;

namespace MarketPlace.Repositories.Interfaces
{
    public interface IStatusRepository
    {
        public Task CreateStatus(Status status);
        public IEnumerable<Status> GetStatuses();
    }
}
