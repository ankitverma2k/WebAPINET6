using Contracts;
using Service.Contracts;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }
    }
}
