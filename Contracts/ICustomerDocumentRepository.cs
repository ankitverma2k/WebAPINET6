using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ICustomerDocumentRepository
    {
        IEnumerable<CustomerDocument> GetCustomerDocuments(Guid customerId, bool trackChanges);
        CustomerDocument? GetCustomerDocumentById(Guid id, Guid documentId, bool trackChanges);
        void CreateCustomerDocument(CustomerDocument customerDocument);
        void DeleteCustomerDocument(CustomerDocument customerDocument);
        void UpdateCustomerDocument(CustomerDocument customerDocument);

    }
}
