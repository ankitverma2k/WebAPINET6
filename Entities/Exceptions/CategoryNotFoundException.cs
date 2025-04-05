using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class CategoryNotFoundException:NotFoundException
    {
        public CategoryNotFoundException(Guid id):base($"Category Id {id} Not Found in the database" )
        {
            
        }
    }
}
