using Contracts;
using Entities.Models;
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


        public IEnumerable<Category> GetCategories() => FindAll(false).OrderBy(x => x.Name);


        public Category? GetCategory(Guid id) => FindByCondition(c => c.Id.Equals(id), false).SingleOrDefault();



        public void UpdateCategory(Category category)=>Update(category);
       
    }
}
