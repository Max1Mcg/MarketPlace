using AutoMapper;
using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories;

namespace MarketPlace.Services
{
    public class StatusService:IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;
        public StatusService(IStatusRepository statusRepository,
        IMapper mapper)
        {
            _statusRepository= statusRepository;
            _mapper= mapper;
        }
        public IEnumerable<StatusDTO> GetStatuses()
        {
            return _statusRepository.GetStatuses().Select(s => _mapper.Map<StatusDTO>(s));
        }
        public async Task<int> CreateStatus(StatusDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            var indexToAdd = _statusRepository.GetStatuses().Count();
            status.Idstatus = indexToAdd;
            await _statusRepository.Create(status);
            return indexToAdd;
        }
        public async Task UpdateStatus(int id, StatusDTO statusDTO)
        {
            var status = _mapper.Map<Status>(statusDTO);
            status.Idstatus = id;
            await _statusRepository.Update(status);
        }
        public async Task DeleteStatus(int id)
        {
            await _statusRepository.Delete(id);
        }
    }
}
