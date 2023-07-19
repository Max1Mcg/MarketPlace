using AutoMapper;
using MarketPlace.Models;
using MarketPlace.Models.DTOs;
using MarketPlace.Repositories;
using MarketPlace.Repositories.Interfaces;
using MarketPlace.Services.Interfaces;

namespace MarketPlace.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public IEnumerable<CategoryDTO> GetCategories()
        {
            return _categoryRepository.GetCategories().Select(c => _mapper.Map<CategoryDTO>(c));
        }
        public async Task<int> CreateCategory(CategoryDTO categoryDTO) {
            var indexToAdd = _categoryRepository.GetCategories().Count();
            var category = _mapper.Map<Category>(categoryDTO);
            category.Idcategory = indexToAdd;
            await _categoryRepository.CreateCategory(category);
            return indexToAdd;
        }
    }
}
