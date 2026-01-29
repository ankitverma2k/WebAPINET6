using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ICustomerService
    {
        Task DeleteCustomerAsync(Guid id);
        Task UpdateCustomerAsync(Guid id, CustomerDto customerDto);
        Task<Guid> AddCustomerAsync(CustomerDto customerDto);
        Task<IEnumerable<CustomerDto>> GetAllCustomersAsync();
        Task<CustomerDto> GetCustomerByIdAsync(Guid id);
    }
}
