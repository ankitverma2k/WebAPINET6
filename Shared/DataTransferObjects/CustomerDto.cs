using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    [Serializable]
    public record CustomerDto(
     Guid Id,
     string FirstName,
     string LastName,
     string Email,
     string PhoneNumber,
     DateTime DateOfBirth,
     string Address,
     string City,
     string State,
     string ZipCode,
     string Country
             );
}