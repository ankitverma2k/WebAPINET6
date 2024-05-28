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

        public async Task<CompanyDto> CreateCompanyAsync(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repositoryManager.CompanyRepository.CreateCompany(companyEntity);
            await _repositoryManager.SaveAsync();

            var companyToReturn = _mapper.Map<CompanyDto>(companyEntity);
            return companyToReturn;
        }

        public async Task DeleteCompanyAsync(Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyById(companyId, trackChanges: false);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            _repositoryManager.CompanyRepository.DeleteCompany(company);
            await _repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync(bool trackChanges)
        {
            var companies = await _repositoryManager.CompanyRepository.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;
        }

        public async Task<CompanyDto> GetCompanyByIdAsync(Guid companyId, bool trackChanges)
        {
            var company = await _repositoryManager.CompanyRepository.GetCompanyById(companyId, trackChanges);
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
