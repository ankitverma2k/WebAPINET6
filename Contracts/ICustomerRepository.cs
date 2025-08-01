using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
namespace Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customer>GetCustomers(bool trackChanges);

        Customer? GetCustomerById(Guid id, bool trackChanges);

        void CreateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        void UpdateCustomer(Customer customer); 

        //Task<IEnumerable<Customer>> GetCustomersAsync(bool trackChanges);
        //Task<Customer?> GetCustomerByIdAsync(Guid id, bool trackChanges);
        //Task<IEnumerable<Customer>> GetCustomersByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        //Task<IEnumerable<Customer>> GetCustomersByNameAsync(string name, bool trackChanges);
        //Task<IEnumerable<Customer>> GetCustomersByEmailAsync(string email, bool trackChanges);
        //Task<IEnumerable<Customer>> GetCustomersByPhoneNumberAsync(string phoneNumber, bool trackChanges);
        //Task<IEnumerable<Customer>> GetCustomersByCityAsync(string city, bool trackChanges);

    }
}
