using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;


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

        public Guid AddCategory(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            category.Id = Guid.NewGuid();
            _repositoryManager.CategoryRepository.AddCategory(category);
            _repositoryManager.Save();
            return category.Id;
        }

        public void DeleteCategory(Guid id)
        {
            var category = _repositoryManager.CategoryRepository.GetCategory(id);
            if (category != null)
            {
                _repositoryManager.CategoryRepository.DeleteCategory(category);
                _repositoryManager.Save();
            }
            else
            {
                throw new CategoryNotFoundException(id);
            }
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var result = _repositoryManager.CategoryRepository.GetCategories().ToList();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(result);
            _loggerManager.LogInfo("Category Accessed");
            return categoryDto;
        }

        public CategoryDto GetCategoryById(Guid id)
        {
            var result = _repositoryManager.CategoryRepository.GetCategory(id);
            var categoryDto = _mapper.Map<CategoryDto>(result);
            return categoryDto;
        }
    }
}
