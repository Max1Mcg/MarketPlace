using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories.Interfaces;
using AutoMapper;

namespace MarketPlace.Services
{
    public class ItemService:IItemService
    {
        IItemRepository _itemRepository;
        IMapper _mapper;
        public ItemService(IItemRepository itemRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
        }
        public Item GetItem(Guid id)
        {
            return _itemRepository.GetItem(id);
        }
        public async Task<Guid> CreateItem(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Iditem = Guid.NewGuid();
            await _itemRepository.CreateItem(item);
            return item.Iditem;
        }
    }
}
