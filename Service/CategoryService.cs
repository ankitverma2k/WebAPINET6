using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CategoryService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public async Task<Guid> AddCategoryAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = Guid.NewGuid();
            _repositoryManager.CategoryRepository.AddCategory(category);
            await _repositoryManager.SaveAsync();
            return category.Id;
        }

        public async Task DeleteCategoryAsync(Guid id)
        {
            var category = _repositoryManager.CategoryRepository.GetCategoryById(id);
            if (category != null)
            {
                _repositoryManager.CategoryRepository.DeleteCategory(category);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                throw new CategoryNotFoundException(id);
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CategoryParameters categoryParameters)
        {
            var result = await _repositoryManager.CategoryRepository.GetCategoriesAsync(categoryParameters);
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(result);
            _loggerManager.LogInfo("Category Accessed");
            return categoryDto;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
        {
            var result = await _repositoryManager.CategoryRepository.GetCategoryByIdAsync(id);
            var categoryDto = _mapper.Map<CategoryDto>(result);
            return categoryDto;
        }

        public async Task UpdateCategoryAsync(CategoryDto categoryDto)
        {
            var category = await _repositoryManager.CategoryRepository.GetCategoryByIdAsync(categoryDto.Id);
            if (category != null)
            {
                category.Id = categoryDto.Id;
                category.Name = categoryDto.Name;
                category.Description = categoryDto.Description;
                _repositoryManager.CategoryRepository.UpdateCategory(category);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                throw new CategoryNotFoundException(categoryDto.Id);
            }
        }
    }
}
