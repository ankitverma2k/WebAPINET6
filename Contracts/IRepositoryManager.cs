using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    /*
     This Interface contain all the repositories
     */
    public interface IRepositoryManager
    {
        public ICompanyRepository CompanyRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }

        public ICategoryRepository CategoryRepository { get; }
        Task SaveAsync();

        void Save();
    }
}
