using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        Guid AddCategory(CategoryDto categoryDto);
        CategoryDto GetCategoryById(Guid id);
        void DeleteCategory(Guid id);

    }
}
