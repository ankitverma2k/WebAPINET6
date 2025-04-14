using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.RequestFeatures;
namespace Service.Contracts
{
    public interface ICategoryService
    {
        Task DeleteCategoryAsync(Guid id);
        Task UpdateCategoryAsync(CategoryDto categoryDto);
        Task<Guid> AddCategoryAsync(CategoryDto categoryDto);
        Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync(CategoryParameters categoryParameters);
        Task<CategoryDto> GetCategoryByIdAsync(Guid id);




    }
}
