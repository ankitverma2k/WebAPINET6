
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly IServiceManager _serviceManager;
        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [Route("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _serviceManager.CustomerService.GetAllCustomersAsync());
        }

        [HttpGet (Name = "GetCustomer")]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _serviceManager.CustomerService.GetCustomerByIdAsync(id);
            if (customer is null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        [Route("customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerDto customer)
        {
            if (customer is null)
                return BadRequest("Customer object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var Id = await _serviceManager.CustomerService.AddCustomerAsync(customer);
            return CreatedAtRoute("GetCustomer", new { id = Id });
        }
    }
}
