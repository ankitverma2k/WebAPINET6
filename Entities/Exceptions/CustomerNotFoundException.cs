using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CustomerNotFoundException:NotFoundException
    {
        public CustomerNotFoundException(Guid id) 
            : base($"The customer with id: {id} doesn't exist in the database.")
        {

        }
    }
}
