using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal class CustomerService : ICustomerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public CustomerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }
        public async Task<Guid> AddCustomerAsync(CustomerDto customerDto)
        {
            var customerEntity = _mapper.Map<Customer>(customerDto);
            _repositoryManager.CustomerRepository.CreateCustomer(customerEntity);
            await _repositoryManager.SaveAsync();

            var customerToReturn = _mapper.Map<CustomerDto>(customerEntity);
            return customerToReturn.Id;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {

            var customer = _repositoryManager.CustomerRepository.GetCustomerById(id, trackChanges: false);
            if (customer != null)
            {
                _repositoryManager.CustomerRepository.DeleteCustomer(customer);
                await _repositoryManager.SaveAsync();
            }
            else
            {
                throw new CustomerNotFoundException(id);
            }
        }

        public async Task<IEnumerable<CustomerDto>> GetAllCustomersAsync()
        {
            var result = _repositoryManager.CustomerRepository.GetCustomers(trackChanges: false);
            var customerDtos = _mapper.Map<IEnumerable<CustomerDto>>(result);
            _loggerManager.LogInfo("All Customer Accessed");
            return await Task.FromResult(customerDtos);
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid id)
        {
            var customer = _repositoryManager.CustomerRepository.GetCustomerById(id, trackChanges: false);
            if (customer == null)
            {
                throw new CustomerNotFoundException(id);
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            _loggerManager.LogInfo($"Customer with id: {id} accessed");
            return await Task.FromResult(customerDto);
        }

        public async Task UpdateCustomerAsync(CustomerDto customerDto)
        {
            var customer = _repositoryManager.CustomerRepository.GetCustomerById(customerDto.Id, trackChanges: true);
            if (customer == null)
            {
                throw new CustomerNotFoundException(customerDto.Id);
            }
            _mapper.Map(customerDto, customer);
            _repositoryManager.CustomerRepository.UpdateCustomer(customer);
            await _repositoryManager.SaveAsync();
            _loggerManager.LogInfo($"Customer with id: {customerDto.Id} updated");

        }
    }
}
