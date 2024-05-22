using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repositoryManager.CompanyRepository.CreateCompany(companyEntity);
            _repositoryManager.Save();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);

            return companyToReturn;
        }

        public void DeleteCompany(Guid companyId, bool trackChanges)
        {
            var company = _repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            _repositoryManager.CompanyRepository.DeleteCompany(company);

            _repositoryManager.Save();
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {

            var companies = _repositoryManager.CompanyRepository.GetAllCompanies(trackChanges);
            //var companiesDto = companies
            //    .Select(c => new CompanyDto(c.Id, c.Name ?? "", string.Join(' ', c.Address, c.Country))).ToList();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);


            return companiesDto;

        }

        public CompanyDto GetCompanyById(Guid companyId, bool trackChanges)
        {
            var company = _repositoryManager.CompanyRepository.GetCompany(companyId, trackChanges);
            //Check if the company is null
            var companyDto = _mapper.Map<CompanyDto>(company);
            if (companyDto is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            return companyDto;
        }
    }
}
