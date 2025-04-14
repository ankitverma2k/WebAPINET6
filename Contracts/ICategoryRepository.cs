using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.RequestFeatures;
namespace Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        Category? GetCategoryById(Guid id);
        void UpdateCategory(Category category);
        Task<IEnumerable<Category>> GetCategoriesAsync(CategoryParameters categoryParameters);
        Task<Category?> GetCategoryByIdAsync(Guid id);
 
    }
}
