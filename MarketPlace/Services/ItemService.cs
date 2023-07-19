using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories.Interfaces;
using AutoMapper;

namespace MarketPlace.Services
{
    public class ItemService:IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public ItemService(IItemRepository itemRepository,
            IMapper mapper,
            ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _itemRepository = itemRepository;
        }
        public ItemDTO GetItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            var itemDTO = _mapper.Map<ItemDTO>(item);
            itemDTO.Categories = item.Categories.Select(c => c.Idcategory).ToList();
            return itemDTO;
        }
        public async Task<Guid> CreateItem(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Iditem = Guid.NewGuid();
            item.Categories = itemDTO.Categories.Select(c => _categoryRepository.GetCategory(c)).ToList();
            await _itemRepository.CreateItem(item);
            return item.Iditem;
        }
    }
}
