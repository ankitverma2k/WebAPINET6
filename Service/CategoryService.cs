using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IEnumerable<CategoryDto> GetCategories()
        {
            var result = _repositoryManager.CategoryRepository.GetCategories().ToList();
            var categoryDto = _mapper.Map<IEnumerable<CategoryDto>>(result);
            _loggerManager.LogInfo("Category Accessed");
            return categoryDto;
        }
    }
}
