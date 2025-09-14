
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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

        //Get api/customers
        [HttpGet]
        [Route("customers")]

        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _serviceManager.CustomerService.GetAllCustomersAsync());
        }


        //Get api/customer/{id}
        [HttpGet(Name = "GetCustomer")]
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

        // api/customer/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerDto customer)
        {
            if (customer is null)
                return BadRequest("Customer object is null");
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);


            var updatedCustomer = await _serviceManager.CustomerService.GetCustomerByIdAsync(id);
            if (updatedCustomer is null)
                return NotFound();


            // Update the customer

            await _serviceManager.CustomerService.UpdateCustomerAsync(id, customer);

            return NoContent();
        }

        // api/customer/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var customer = await _serviceManager.CustomerService.GetCustomerByIdAsync(id);
            if (customer is null)
                return NotFound();
            await _serviceManager.CustomerService.DeleteCustomerAsync(id);
            return NoContent();
        }
    }
}
