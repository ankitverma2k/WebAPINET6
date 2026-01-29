using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    internal class CustomerDocumentRepository : RepositoryBase<CustomerDocument>, ICustomerDocumentRepository
    {
        public CustomerDocumentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }
        public void CreateCustomerDocument(CustomerDocument customerDocument)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomerDocument(CustomerDocument customerDocument)
        {
            throw new NotImplementedException();
        }

        public CustomerDocument? GetCustomerDocumentById(Guid id, Guid documentId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDocument> GetCustomerDocuments(Guid customerId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void UpdateCustomerDocument(CustomerDocument customerDocument)
        {
            throw new NotImplementedException();
        }
    }
}
