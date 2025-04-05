using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
        void AddCategory(Category category);

        void DeleteCategory(Category category);

        Category ? GetCategory(int id);

        void UpdateCategory(Category category);
    }
}
