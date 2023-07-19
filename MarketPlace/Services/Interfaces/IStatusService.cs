using MarketPlace.Models.DTOs;
using MarketPlace.Models;

namespace MarketPlace.Services.Interfaces
{
    public interface IStatusService
    {
        public IEnumerable<StatusDTO> GetStatuses();
        public Task<int> CreateStatus(StatusDTO statusDTO);
    }
}
