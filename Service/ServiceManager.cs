using AutoMapper;
using Contracts;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICustomerService> _customerService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _customerService = new Lazy<ICustomerService>(() => new CustomerService(repositoryManager, loggerManager, mapper));
        }

        public ICustomerService CompanyService => _customerService.Value;

        public ICustomerService CustomerService => _customerService.Value;
    }
}



