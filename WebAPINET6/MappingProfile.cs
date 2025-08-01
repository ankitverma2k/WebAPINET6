using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace WebAPINET6
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();

        }
    }
}
