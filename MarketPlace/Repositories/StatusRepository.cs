using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
namespace MarketPlace.Repositories
{
    public class StatusRepository:IStatusRepository
    {
        private readonly MarketPlaceContext _context;
        public StatusRepository(MarketPlaceContext context)
        {
            _context = context;
        }
        public async Task CreateStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
        }
        public IEnumerable<Status> GetStatuses()
        {
            return _context.Statuses;
        }
        public Status GetStatus(int id)
        {
            return _context.Statuses.FirstOrDefault(s => s.Idstatus == id);
        }
    }
}
