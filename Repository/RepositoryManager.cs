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
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;
            _companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(_context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(_context));
            _categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(_context));
        }


        public ICompanyRepository CompanyRepository => _companyRepository.Value;

        public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

        public ICategoryRepository CategoryRepository => _categoryRepository.Value;

        public Task SaveAsync() => _context.SaveChangesAsync();

        public void Save()=>_context.SaveChanges();

    }
}
