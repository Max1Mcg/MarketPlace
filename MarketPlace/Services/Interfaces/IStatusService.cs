using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using AutoMapper.Configuration.Conventions;

namespace MarketPlace.Services.Interfaces
{
    public interface IStatusService
    {
        public IEnumerable<StatusDTO> GetStatuses();
        public Task<int> CreateStatus(StatusDTO statusDTO);
        public Task UpdateStatus(int id, StatusDTO statusDTO);
        public Task DeleteStatus(int id);
    }
}
