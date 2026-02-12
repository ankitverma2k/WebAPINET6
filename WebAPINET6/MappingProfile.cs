using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPINET6
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Customer, CustomerDto>();


            //   .ForCtorParam("FullAddress", opt =>
            //   opt.MapFrom((src, ctx) => $"{src.Address} {src.Country}"));

            //CreateMap<CompanyForCreationDto, Company>();

            //CreateMap<Employee, EmployeeDto>();
            //CreateMap<EmployeeForCreationDto, Employee>();
            //CreateMap<EmployeeForUpdateDto, Employee>();
            //CreateMap<Category, CategoryDto>();
            //CreateMap<CategoryDto, Category>();
        }

        
    }
}
