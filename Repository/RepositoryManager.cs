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
        public ICompanyRepository CompanyRepository => throw new NotImplementedException();

        public IEmployeeRepository EmployeeRepository => throw new NotImplementedException();

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
