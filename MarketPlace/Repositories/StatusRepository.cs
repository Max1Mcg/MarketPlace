using MarketPlace.Contexts;
using MarketPlace.Models;
using MarketPlace.Repositories.Base;
using MarketPlace.Repositories.Interfaces;
namespace MarketPlace.Repositories
{
    public class StatusRepository:BaseRepository<Status>, IStatusRepository
    {
        public StatusRepository(MarketPlaceContext context):base(context)
        {
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
