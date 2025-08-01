using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly Lazy<ICustomerRepository> _customerRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;

            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
        }

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();

        public void Save() => _context.SaveChanges();

    }
}
