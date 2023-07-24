using MarketPlace.Models.DTOs;
using MarketPlace.Models;
using MarketPlace.Services.Interfaces;
using MarketPlace.Repositories.Interfaces;
using AutoMapper;
using MarketPlace.Repositories;
using Microsoft.EntityFrameworkCore;

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
            if (item == null || item.Available == false)
                throw new Exception("Товар не найден или не существует");
            var itemDTO = _mapper.Map<ItemDTO>(item);
            itemDTO.Categories = item.Categories.Select(c => c.Idcategory).ToList();
            return itemDTO;
        }
        public async Task<Guid> CreateItem(ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Iditem = Guid.NewGuid();
            item.Categories = itemDTO.Categories.Select(c => _categoryRepository.GetCategory(c)).ToList();
            item.Available = true;
            await _itemRepository.Create(item);
            return item.Iditem;
        }
        public async Task UpdateItem(Guid id, ItemDTO itemDTO)
        {
            var item = _mapper.Map<Item>(itemDTO);
            item.Iditem = id;
            await _itemRepository.Update(item);
        }
        /// <summary>
        /// Удаление представляет из себя недоступность товара, т.к. товар может быть уже добавлен в корзины и информации о нём оттуда просто так
        /// пропадать не должна.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            item.Available = false;
            await _itemRepository.Update(item);
        }
    }
}
