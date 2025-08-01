using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {

        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer) => Create(customer);

        public void DeleteCustomer(Customer customer) => Delete(customer);

        public Customer? GetCustomerById(Guid id, bool trackChanges) => FindByCondition(c => c.Id.Equals(id), trackChanges).SingleOrDefault();

        public IEnumerable<Customer> GetCustomers(bool trackChanges) => FindAll(trackChanges).OrderBy(c => c.FirstName).ToList();

        public void UpdateCustomer(Customer customer)=> Update(customer);

    }
}
