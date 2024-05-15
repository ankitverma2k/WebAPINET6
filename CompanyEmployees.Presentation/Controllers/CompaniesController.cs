using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;
        public CompaniesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {

            return Ok(_serviceManager.CompanyService.GetAllCompanies(trackChanges: false));

        }

        [HttpGet("{id:guid}", Name ="CompanyById")]

        public IActionResult GetCompanyById(Guid id)
        {
            return Ok(_serviceManager.CompanyService.GetCompanyById(id, false));
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if(company is null)
            {
                return BadRequest("CompanyForCreationDto object is null");

            }
            var createdCompany = _serviceManager.CompanyService.CreateCompany(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.Id }, createdCompany);
        }
    }
}
