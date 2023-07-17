using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IStatusService
    {
        public IEnumerable<Status> GetStatuses();
        public Task<int> CreateStatus(StatusDTO statusDTO);
    }
}
