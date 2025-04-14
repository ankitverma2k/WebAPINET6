using Contracts;
using Entities.Models;
using Shared.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void AddCategory(Category category) => Create(category);


        public void DeleteCategory(Category category) => Delete(category);


        public IEnumerable<Category> GetAllCategories() => FindAll(false).OrderBy(x => x.Name);

        public async Task<IEnumerable<Category>> GetCategoriesAsync(CategoryParameters categoryParameters)
        {
            return await FindAll(false).OrderBy(x => x.Name)
                .Skip((categoryParameters.PageNumber - 1) * categoryParameters.PageSize)
                .Take(categoryParameters.PageSize).ToListAsync();
        }

        public Category? GetCategoryById(Guid id) => FindByCondition(c => c.Id.Equals(id), false).SingleOrDefault();

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await FindByCondition(x => x.Id.Equals(id), false).SingleOrDefaultAsync();
        }

        public void UpdateCategory(Category category) => Update(category);

    }
}
